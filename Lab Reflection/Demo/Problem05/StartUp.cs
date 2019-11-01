﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Problem05
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lionType = Type.GetType("Problem05.Animal.Lion");

            foreach (var field in lionType)
            {
                global::System.Console.WriteLine(field.Name);
            }

            //var interfaces = lionType.BaseType.GetProperties();

            //foreach (var interfaceInfo in interfaces)
            //{
            //    Console.WriteLine(interfaceInfo.Name);
            //}
        }
    }
}
