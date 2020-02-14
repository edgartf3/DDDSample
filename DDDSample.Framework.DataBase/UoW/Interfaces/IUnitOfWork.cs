using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase.UoW.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
