using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedNullChecks.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            TesterClass o;
            ConstrutorNullCheckUtils.TestAllNullArgumentExceptionsForConstructors(typeof (TesterClass));
        }

        public class TesterClass
        {
            private readonly int _number;
            private readonly ArgumentClass _simpleClass;
            private readonly IDisposable _someInterface;
            private readonly ArgumentClassComplex _complexClass;

            public TesterClass(int number,ArgumentClass simpleClass,IDisposable someInterface,ArgumentClassComplex complexClass)
            {
                _number = number;
                _simpleClass = simpleClass;
                _someInterface = someInterface;
                _complexClass = complexClass;
            }

            public int Number
            {
                get { return _number; }
            }

            public ArgumentClass SimpleClass
            {
                get { return _simpleClass; }
            }

            public IDisposable SomeInterface
            {
                get { return _someInterface; }
            }

            public ArgumentClassComplex ComplexClass
            {
                get { return _complexClass; }
            }
        }

        public class ArgumentClass
        {
            public int SomeProperty { get; set; }
        }

        public class ArgumentClassComplex
        {
            public ArgumentClassComplex(int y)
            {
                //something
            }
        }
    }
}
