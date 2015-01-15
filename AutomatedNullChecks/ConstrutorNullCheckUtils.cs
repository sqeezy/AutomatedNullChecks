using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Memmexx.InterfaceImplementor;

namespace AutomatedNullChecks
{
    public static class ConstrutorNullCheckUtils
    {
        public static void TestAllNullArgumentExceptionsForConstructors(Type type)
        {
            IEnumerable<ConstructorInfo> constructors = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                TestForNullArgumentException(constructor);
            }
        }

        private static void TestForNullArgumentException(ConstructorInfo constructor)
        {
            IEnumerable<ParameterInfo> parameters = constructor.GetParameters();
            IEnumerable<object> validParams = parameters.Select(GetBasicImplementation);
            var x = constructor.Invoke(validParams.ToArray());
            x.GetHashCode();
        }

        private static object GetBasicImplementation(ParameterInfo parameter)
        {
            Type type = parameter.ParameterType;
            if (type.IsInterface)
            {
                return InterfaceObjectFactory.CreateInterfaceImplementation(type);
            }
            if (type.IsAbstract)
            {
                throw new InvalidOperationException("Abstract types are not supported.");
            }
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return Activator.CreateInstance(type);
        }
    }
}