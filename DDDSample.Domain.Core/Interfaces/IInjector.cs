using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Core.Interfaces
{
    public interface IInjector
    {
        T Get<T>();
    }
}
