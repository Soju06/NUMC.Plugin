using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RuntimeCsharp
{
    public class RuntimeCsharpCore
    {
        static RuntimeCsharpCore() {
            CereateDirectory();
        }

        public static void CereateDirectory() {
            if (!ScriptDirectory.Exists) ScriptDirectory.Create();
        }

        public static readonly DirectoryInfo ScriptDirectory = new DirectoryInfo(
            Path.Combine(Path.GetDirectoryName(typeof(RuntimeCsharpCore).Assembly.Location), "Scripts"));

        public static FileInfo[] GetScriptFileInfos() { 
            CereateDirectory(); return ScriptDirectory.GetFiles(); 
        }

        public static RuntimeCsharpCompiler.CsharpCompilerParameters GetScripts() => 
            GetScripts(GetScriptFileInfos());

        public static RuntimeCsharpCompiler.CsharpCompilerParameters GetScripts(FileInfo[] files)
        {
            var ps = new RuntimeCsharpCompiler.CsharpCompilerParameters();
            for (int i = 0; i < files.Length; i++)
                if (files[i].Exists) {
                    if (files[i].Name == "refs.txt")
                        ps.ReferencedAssemblies.AddRange(File.ReadAllLines(files[i].FullName));
                    else if(files[i].Extension == ".cs")
                        ps.Codes.Add(File.ReadAllText(files[i].FullName));
                }
            return ps;
        }
    }

}
