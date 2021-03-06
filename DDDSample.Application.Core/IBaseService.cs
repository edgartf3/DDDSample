﻿using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace DDDSample.Application.Core
{
    public interface IBaseService<T> where T: EntidadeBase
    {
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        void Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}
