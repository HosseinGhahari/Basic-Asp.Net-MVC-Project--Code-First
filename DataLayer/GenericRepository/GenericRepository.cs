using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    // in this GenericRepository class , we create those actions 
    // that wanna be repeated many times 
    // also this class take a entity type for every type we want 

    // also we give a constructor to this class for doing our opreation 
    // in unit of work method

    public class GenericRepository<TEntity> where TEntity : class
    {

        private OurContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(OurContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();        
        }


        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity,bool>> where = null , Func<IQueryable<TEntity> , IOrderedQueryable<TEntity>> orderby = null , string Includes = "")
        {

            IQueryable<TEntity> query = _dbSet;

            if (where  != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (Includes != "")
            {
                foreach(var item in Includes.Split(','))
                {
                    query = query.Include(item);
                }
            }

            return query.ToList();

        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);      
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual void Delete(object id) 
        {
            var entry = GetById(id);
            Delete(entry);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }


    }
}
