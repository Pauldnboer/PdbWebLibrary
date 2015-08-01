using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBWebLibrary.Database.Domain
{
    
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class Persist : System.Attribute
    {
        public Type DatabaseType { get; set; }
        public bool Nullable { get; set; }

        public Persist(Type databaseType, bool nullable)
        {
            DatabaseType = databaseType;
            Nullable = nullable;
        }
    }
}
