using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace RuntimeCsharp
{
    public static class RuntimeCsharpCompiler
    {
        public static CsharpCompilerResult Compiler(CsharpCompilerParameters parameters)
        {
            var loc = typeof(RuntimeCsharpCompiler)?.Assembly?.Location;
            using (var provider = new CSharpCodeProvider(new ProviderOptions() {
                CompilerFullPath = Path.Combine(Path.GetDirectoryName(loc), "Compiler\\csc.exe"), CompilerVersion = "v4.7.2" 
            })) {
                var compilerParameters = new CompilerParameters();
                compilerParameters.ReferencedAssemblies.Add(typeof(NUMC.Service)?.Assembly?.Location ?? "NUMC.exe");
                compilerParameters.ReferencedAssemblies.Add(loc ?? "RuntimeCsharp.dll");
                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
                compilerParameters.ReferencedAssemblies.Add("System.IO.Compression.dll");
                compilerParameters.ReferencedAssemblies.Add("System.IO.Compression.FileSystem.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Net.Http.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Runtime.Serialization.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Web.Extensions.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Xml.dll");
                compilerParameters.WarningLevel = 3;
                compilerParameters.CompilerOptions = "/optimize";
                //compilerParameters.OutputAssembly = Path.Combine(Path.GetDirectoryName(typeof(NUMC.Service)?.Assembly?.Location), "test1.dll");
                for (int i = 0; i < parameters.ReferencedAssemblies.Count; i++) {
                    if (!string.IsNullOrWhiteSpace(parameters.ReferencedAssemblies[i]) &&
                        !compilerParameters.ReferencedAssemblies.Contains(parameters.ReferencedAssemblies[i]))
                        compilerParameters.ReferencedAssemblies.Add(parameters.ReferencedAssemblies[i]);
                }
                compilerParameters.GenerateInMemory = true;
                compilerParameters.GenerateExecutable = false;
                var codes = new string[parameters.Codes.Count];
                parameters.Codes.CopyTo(codes, 0);
                var compileResults = provider.CompileAssemblyFromSource(compilerParameters, codes);
                var results = new CsharpCompilerResult() {
                    HasErrors = compileResults?.Errors?.HasErrors ?? false,
                    Outputs = new string[compileResults.Output.Count],
                    Errors = new CompilerError[compileResults.Errors.Count],
                    CompiledAssembly = compileResults?.Errors?.HasErrors == false ? compileResults.CompiledAssembly : null
                };
                compileResults.Output.CopyTo(results.Outputs, 0);
                compileResults.Errors.CopyTo(results.Errors, 0);
                return results;
            }
        }

        public class CsharpCompilerParameters
        {
            private StringCollection _codes;
            private StringCollection _referencedAssemblies;

            public StringCollection Codes { get => _codes ??
                    (_codes = new StringCollection()); set => _codes = value; }

            public StringCollection ReferencedAssemblies { get => _referencedAssemblies ?? 
                    (_referencedAssemblies = new StringCollection()); set => _referencedAssemblies = value; }
        }

        public class CsharpCompilerResult
        {
            public bool HasErrors { get; internal set; }
            public string[] Outputs { get; internal set; }
            public CompilerError[] Errors { get; internal set; }
            public Assembly CompiledAssembly { get; internal set; }
        }
    }
}
