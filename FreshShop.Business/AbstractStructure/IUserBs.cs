﻿using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Business.AbstractStructure
{
    public interface IUserBs:IBusinessBase<User>
    {
        User LogIn(string email, string password);
    }
}
