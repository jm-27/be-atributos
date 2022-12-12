using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace be_atributos.Models
{
    public interface IDBContext
    {
        DbContext dbContext { get; }
    }

    public class MyDBContextFactory: IDBContext     
    {
        public DbContext dbContext { get; }

        public MyDBContextFactory(MyDBContext dbContext)
        {
            this.dbContext= dbContext;
        }
    }

    public class MyLogContextFactory : IDBContext
    {
        public DbContext dbContext { get; }
        public MyLogContextFactory(MyLogContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }

    public class DbContexts

    {
        private Dictionary<string,IDBContext> _dbContextFactories = 
            new Dictionary<string, IDBContext>();

        public DbContexts(IServiceProvider serviceProvider)
        {
            foreach (var type in typeof(IDBContext).Assembly.GetTypes())
            {
                if (typeof(IDBContext).IsAssignableFrom(type)
                    && !type.IsInterface)
                {
                    _dbContextFactories.Add(
                        type.Name.Replace("Factory", string.Empty),
                        (IDBContext)ActivatorUtilities.CreateInstance(serviceProvider,type) );
                }
            }
        }
        public DbContext this[string index] => _dbContextFactories[index].dbContext;
    }




}
