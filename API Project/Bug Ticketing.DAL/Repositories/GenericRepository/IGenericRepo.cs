﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL.Repositories.GenericRepository
{
    public interface IGenericRepo<T> where T :class
    {

        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        void Add(T entity);
        void Update(T entity);
        public void Delete(T entity);
    }
}
