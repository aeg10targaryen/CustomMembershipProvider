using System;

namespace Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        DataContext Get();
    }
}
