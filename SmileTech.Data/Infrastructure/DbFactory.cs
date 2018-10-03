namespace SmileTech.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SmileTechDbContext dbContext;

        public SmileTechDbContext Init()
        {
            return dbContext ?? (dbContext = new SmileTechDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}