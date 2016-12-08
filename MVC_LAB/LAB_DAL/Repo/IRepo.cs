﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace LAB_DAL.Repo
{
    public interface IRepo<T>
    {
        void Add(T entity);
        void Delete(Guid ID);

        IEnumerable<T> All();

        T Find(Expression<Func<T, bool>> predicate);
    }
}
