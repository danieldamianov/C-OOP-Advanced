using CustomDependencyInjection.Attributes;
using CustomDependencyInjection.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomDependencyInjection.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        protected void CreateMapping<TInter,TImpl>()
        {
            if (this.implementations.ContainsKey(typeof(TInter)) == false)
            {
                this.implementations[typeof(TInter)] = new Dictionary<string, Type>();
            }
            this.implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }

        public object GetInstance(Type type)
        {
            this.instances.TryGetValue(type, out object value);
            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this.implementations[currentInterface];

            Type type = null;

            if (attribute is InjectAttribute)
            {
                if (currentImplementation.Count > 0)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException("No available mapping for class: "
                         + currentInterface.FullName);
                }
            }
            else if(attribute is NamedAttribute)
            {
                NamedAttribute namedAttribute = attribute as NamedAttribute;

                string dependencyName = namedAttribute.Name;

                type = currentImplementation[dependencyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (this.instances.ContainsKey(implementation) == false)
            {
                this.instances.Add(implementation, instance);
            }
        }
    }
}
