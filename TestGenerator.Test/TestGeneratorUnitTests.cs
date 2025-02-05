﻿using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TestGenerator.Test;

[TestClass]
public class TestGeneratorUnitTest
{
    [TestMethod]
    public async Task Test123()
    {
        // Arrange
        var source = """
            using System;

            namespace TestGenerator.Test
            {
                [TestSourceGenerator]
                public partial class MyClass
                {

                }
            }
            """;

        var expectedGeneratedCode = """
            //<auto-generated/>
            #nullable enable
            using System;

            /// MyClass              
            """;

        var test = new CSharpSourceGeneratorTest<TestGenerator, DefaultVerifier>
        {
            TestState =
            {
                Sources = { source },
                GeneratedSources =
                {
                    (typeof(TestGenerator), "MyClass.g.cs", expectedGeneratedCode)
                }
            }
        };

        // Act & Assert
        await test.RunAsync();
    }
}
