using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Model.Domain
{
    public class Role : BaseDomain
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
