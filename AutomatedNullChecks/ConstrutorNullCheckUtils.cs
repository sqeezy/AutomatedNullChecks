using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Memmexx.InterfaceImplementor;

namespace AutomatedNullChecks
{
    public static class ConstrutorNullCheckUtils
    {
        public static void TestAllNullArgumentExceptionsForConstructors<T>(T type) where T : class
        {
            IEnumerable<ConstructorInfo> constructors = type.GetType().GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                TestForNullArgumentException(constructor);
            }
        }

        private static void TestForNullArgumentException(ConstructorInfo constructor)
        {
            IEnumerable<ParameterInfo> parameters = constructor.GetParameters();
        }

        //private static object GetBasicImplementation(ParameterInfo parameter)
        //{
        //    Type type = parameter.GetType();
        //    if (type.IsAbstract) { throw  new InvalidOperationException("Abstract types are not supported.");}
        //    if (type.IsInterface)
        //    {
        //    }
        //}
    }
}