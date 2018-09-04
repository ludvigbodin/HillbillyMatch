using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Datalayer.Repositories
{
    public abstract class Repository<TValue, TKey> where TValue : class, IEntity<TKey>
    {
        private readonly DataContext context = new DataContext();

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public DbSet<TValue> Items => context.Set<TValue>();

        public TValue Get(TKey id)
        {
            return Items.Find(id);
        }

        public List<TValue> GetAll()
        {
            return Items.ToList();
        }

        public void Add(TValue item)
        {
            Items.Add(item);
        }

        public void Remove(TKey id)
        {
            var item = Get(id);
            Items.Remove(item);
        }

        public void Edit(TValue item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
