using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDBWebLibrary.Tool;

namespace PDBWebLibrary.Database.Domain.Types
{
    public abstract class DatabaseType : PEnum
    {
        public static readonly DatabaseType Varchar255 = new DbVarchar255();
    }
}
