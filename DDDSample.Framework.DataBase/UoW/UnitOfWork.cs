using DDDSample.Framework.DataBase.UoW.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase.UoW
{
    public class UnitOfWork: IUnitOfWork
    {
        private DbContext _context;
        public UnitOfWork(SampleDBContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChangesAsync().Wait();
        }
    }
}
