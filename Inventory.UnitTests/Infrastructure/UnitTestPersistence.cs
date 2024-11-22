using Microsoft.EntityFrameworkCore;

namespace DBB.Unit.Tests.Infrastructure
{
    public class UnitTestPersistence<TContext> where TContext : DbContext, IDisposable
    {
        public TContext Context { get; }
        public TContext ReadDataContext { get; }

        public UnitTestPersistence()
        {
            var db = new EFInMemoryDatabase<TContext>();
            Context = db.CreateDataContext();
            ReadDataContext = db.CreateDataContext();
        }

        protected void Save<T>(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Context.Manipulate(_ => _.Add(entity));
        }

        public void Dispose()
        {
            Context.Dispose();
            ReadDataContext.Dispose();
        }
    }

}
