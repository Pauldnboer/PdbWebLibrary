using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PDBWebLibrary.Database.MsSql;

namespace PDBWebLibrary.Database.Install
{
    public class DatabaseInstaller
    {
        public AssemblyInspector AssemblyInspector { get; set; }

        public DatabaseInstaller(Assembly assembly)
        {
            AssemblyInspector = new AssemblyInspector(assembly);
        }

        public void Start()
        {
            AssemblyInspector.Start();
        }

    }
}
