using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Framework.DataBase.Mappings
{
    public interface IMapping
    {
        void OnModelCreating(ModelBuilder modelBuilder);
    }
}
