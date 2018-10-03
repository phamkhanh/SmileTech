using System;

namespace SmileTech.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        SmileTechDbContext Init();
    }
}