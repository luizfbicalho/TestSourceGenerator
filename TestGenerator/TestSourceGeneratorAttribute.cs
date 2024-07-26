using System;

namespace TestGenerator
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public class TestSourceGeneratorAttribute : Attribute;
}
