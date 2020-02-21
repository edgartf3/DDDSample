using DDDSample.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Core.Helpers
{
    public interface ISqlHelper
    {
        void Execute(string commandtext);
        IEnumerable<dynamic> Query(string sql);

        dynamic Get<TEntity>(Guid id, string[] fields) where TEntity : EntidadeBase;
    }
}
