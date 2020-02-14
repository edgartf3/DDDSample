using DDDSample.Framework.DataBase.UoW.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DDDSample.Framework.DataBase.UoW
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private DbContext _context;
        private IDbContextTransaction _dbContextTransaction;
        public UnitOfWork(SampleDBContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            if (_dbContextTransaction == null)
            {
                throw new Exception("Transação não iniciada");
            }
           
            _context.SaveChangesAsync().Wait();
            _dbContextTransaction.CommitAsync().Wait();
        }

        public void Dispose()
        {
            _dbContextTransaction.DisposeAsync();
        }

        public void Rollback()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.RollbackAsync().Wait();
            }            
        }
    }
}
