using CustomDependencyInjection.Attributes;
using CustomDependencyInjection.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CustomDependencyInjection.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            bool hasConstructorAttribute = CheckForConstructorIjection<TClass>();
            bool hasFieldAttribute = CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");
            }

            if (hasConstructorAttribute)
            {
                return CreateConstructorInjection<TClass>();
            }
            if (hasFieldAttribute)
            {
                return CreateFieldInjection<TClass>();
            }

            return default(TClass);
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(f => f.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private bool CheckForConstructorIjection<TClass>()
        {
            return typeof(TClass).GetConstructors()
                .Any(ctor => ctor.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            Type desireType = typeof(TClass);
            if (desireType == null)
            {
                return default(TClass);

            }
            ConstructorInfo[] constructors = desireType.GetConstructors();

            foreach (var constructor in constructors)
            {
                if (this.CheckForConstructorIjection<TClass>() == false)
                {
                    continue;
                }

                InjectAttribute injectAttribute = (InjectAttribute)constructor
                    .GetCustomAttributes(typeof(InjectAttribute), true)
                    .FirstOrDefault();

                ParameterInfo[] paramsTypes = constructor.GetParameters();
                object[] constructorParameters = new object[paramsTypes.Length];

                int i = 0;

                foreach (ParameterInfo parameter in paramsTypes)
                {
                    NamedAttribute namedAttribute = (NamedAttribute)parameter
                        .GetCustomAttribute(typeof(NamedAttribute));

                    Type dependency = null;

                    if (namedAttribute == null)
                    {
                        dependency = this.module.GetMapping(parameter.ParameterType, injectAttribute);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(parameter.ParameterType, namedAttribute);
                    }

                    if (parameter.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);

                        if (instance != null)
                        {
                            constructorParameters[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParameters[i++] = instance;
                            this.module.SetInstance(parameter.ParameterType, instance);
                        }
                    }
                }
                return (TClass)Activator.CreateInstance(desireType, constructorParameters);
            }
            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            Type desireClass = typeof(TClass);
            var desireClassInstance = this.module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance);
            }

            FieldInfo[] fields = desireClass.GetFields((BindingFlags)62);
            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(InjectAttribute),true).Any())
                {
                    Type dependency = null;
                    Type fieldType = field.FieldType;

                    InjectAttribute injectAttribute = (InjectAttribute)field
                        .GetCustomAttributes(typeof(InjectAttribute), true)
                        .FirstOrDefault();

                    NamedAttribute namedAttribute = (NamedAttribute)field
                        .GetCustomAttribute(typeof(NamedAttribute), true);

                    if (namedAttribute == null)
                    {
                        dependency = this.module.GetMapping(fieldType, injectAttribute);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(fieldType, namedAttribute);
                    }

                    if (fieldType.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(dependency, instance);
                        }
                        field.SetValue(desireClassInstance, instance);
                    }
                }
            }
            return (TClass)desireClassInstance;
           
        }
    }
}
