﻿using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public interface ICategoryService
    {
        
        void Add(Category c);
        void Remove(Category c);
        IEnumerable<Category> GetAll();
        void Commit();

    }
}

