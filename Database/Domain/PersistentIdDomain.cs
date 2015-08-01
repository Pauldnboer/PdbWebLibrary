using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDBWebLibrary.Database.Domain.Types;

namespace PDBWebLibrary.Database.Domain
{
    public abstract class PersistentIdDomain
    {
        [Persist(typeof(DbInt), true)]
        public int? Id { get; set; }
    }
}
