﻿using FreshShop.Model.Domain;
using InfraStructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.DataAccess.AbstractStructure
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        
    }
}
