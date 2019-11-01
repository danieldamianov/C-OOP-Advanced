using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder stringBuilder = new StringBuilder();
        Type type = Type.GetType(className);
        FieldInfo[] publicFieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        PropertyInfo[] allPropertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var publicField in publicFieldInfos)
        {
            stringBuilder.AppendLine($"{publicField.Name} must be private!");
        }
        foreach (var propsWithPrivateGetters in allPropertyInfos
            .Where(pr => pr.GetMethod != null && pr.GetMethod.IsPrivate))
        {
            stringBuilder.AppendLine($"{propsWithPrivateGetters.GetMethod.Name} have to be public!");
        }
        foreach (var propsWithPublicSetters in allPropertyInfos
            .Where(pr => pr.SetMethod != null && pr.SetMethod.IsPublic))
        {
            stringBuilder.AppendLine($"{propsWithPublicSetters.SetMethod.Name} have to be private!");
        }
        return stringBuilder.ToString().Trim();
    }

    public string StealFieldInfo(string nameOfClass, params string[] fields)
    {
        Type type = Type.GetType(nameOfClass);
        var obj = Activator.CreateInstance(type);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Class under investigation: {nameOfClass}");
        foreach (var fieldName in fields)
        {
            FieldInfo fieldInfo = type.GetField
                (fieldName, BindingFlags.Instance | BindingFlags.Static 
                | BindingFlags.NonPublic | BindingFlags.Public);

            stringBuilder.AppendLine($"{fieldName} = {fieldInfo.GetValue(obj)}");
        }

        return stringBuilder.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type type = Type.GetType(className);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"All Private Methods of Class: {className}");
        stringBuilder.AppendLine($"Base Class: {type.BaseType.Name}");
        foreach (var method in type.GetMethods
            (BindingFlags.Instance | BindingFlags.NonPublic))
        {
            stringBuilder.AppendLine(method.Name);
        }
        return stringBuilder.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type type = Type.GetType(className);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (var prop in type
            .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(prop => prop.GetMethod != null))
        {
            stringBuilder.AppendLine($"{prop.GetMethod.Name} will return {prop.GetMethod.ReturnType}");
            //Console.WriteLine(stringBuilder.Length);
        }

        foreach (var prop in type
            .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(prop => prop.SetMethod != null))
        {
            stringBuilder.AppendLine($"{prop.SetMethod.Name} will set field of {prop.SetMethod.GetParameters().First().ParameterType}");
            //Console.WriteLine(stringBuilder.Length);
        }

        return stringBuilder.ToString().Trim();
    }

    public string CollectGettersAndSettersError(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] classMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var method in classMethods.Where(m => m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return stringBuilder.ToString().Trim();
    }
}

