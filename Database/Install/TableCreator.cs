using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDBWebLibrary.Database.Domain;

namespace PDBWebLibrary.Database.Install
{
    public static class TableCreator
    {
        public static void CreateOrUpdateForType(string domainName, List<DatabaseProperty> fields)
        {
            //temp
        }
    }

    public class DatabaseProperty
    {
        public string PropertyName { get; private set; }
        public Persist Persistency { get; private set; }

        private DatabaseProperty(string propertyName, Persist persistency)
        {
            PropertyName = propertyName;
            Persistency = persistency;
        }

        public static DatabaseProperty Create(string propertyName, Persist persistency)
        {
            return new DatabaseProperty(propertyName,persistency);    
        }
    }
}
