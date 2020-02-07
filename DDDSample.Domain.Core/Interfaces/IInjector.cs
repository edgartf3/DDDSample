namespace DDDSample.Domain.Core.Interfaces
{
    public interface IInjector
    {
        T Get<T>();
    }
}
