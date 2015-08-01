using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PDBWebLibrary.Database.Domain;
using PDBWebLibrary.Database.Domain.Types;

namespace PDBWebLibrary.Database.Install
{
    public class AssemblyInspector
    {
        public Assembly Assembly { get; set; }

        public AssemblyInspector(Assembly assembly)
        {
            Assembly = assembly;
        }

        public void Start()
        {
            var types = Assembly.GetTypes();

            foreach (Type type in types)
            {
                var baseType = type.BaseType;

                if (baseType == typeof(PersistentIdDomain))
                {
                    var fields = new List<DatabaseProperty>();
                    var properties = type.GetProperties();

                    foreach (var property in properties)
                    {
                        //Can only hvae one persist attribue
                        var attribute = property.GetCustomAttribute<Persist>();

                        if (attribute != null)
                        {
                            var test = attribute.Nullable;
                            fields.Add(DatabaseProperty.Create(property.Name,attribute));
                        }

                        //Persist p = (Persist)property.GetCustomAttribute()
//
                        TableCreator.CreateOrUpdateForType(type.Name,fields);

//                        DeveloperAttribute MyAttribute =
//            (DeveloperAttribute)Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute));

                        //var test = attribute.GetType().GetProperties();

                        
                        TableCreator.CreateOrUpdateForType(baseType.Name,fields);
                    }
                }


                
            }
        }

        

    }
}
