﻿using FreshShop.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshShop.Business.AbstractStructure
{
    public interface ICategoryBs : IBusinessBase<Category>
    {
        List<Category> GetAllActiveMainCategories();
        List<Category> GetByMainCategoryId(int topCategoryId);
    }
}