using BLL.Repository.Interface;
using DAL.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public Repository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _dbSet = _context.Set<TEntity>();
            
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteAll()
        {
            var allData = await _dbSet.ToListAsync();
            _dbSet.RemoveRange(allData);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach(var includeproperty in includeProperties)
            {
                query = query.Include(includeproperty);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(int id) => await _dbSet.FindAsync(id);
        

        public async Task<IEnumerable<TEntity>> GetCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetConditionalIncluding(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includeproperties)
        {
            IQueryable < TEntity > query = _dbSet;

            if(condition != null)
            {
                query = query.Where(condition);
            }

            foreach(var includingproperty in includeproperties)
            {
                query = query.Include(includingproperty);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate) => await _dbSet.SingleOrDefaultAsync(predicate);
        

        public async Task<TEntity> GetSingleIncluding(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includingproperties)
        {
            IQueryable<TEntity> query = _dbSet; 
            if(condition != null)
            {
                query = query.Include(condition);
            }

            foreach(var includingproperty in includingproperties)
            {
                query = query.Include(includingproperty);
            }

            return await query.FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> GetWithShaping(params Expression<Func<TEntity, object>>[] includeproperties)
        {
            var query = _context.Set<TEntity>().AsNoTracking();
            return ShapeData(query, includeproperties).ToList();
        }

        private IEnumerable<TEntity> ShapeData(IEnumerable<TEntity> query, params Expression<Func<TEntity, object>>[] selectedproperties)
        {
            if(selectedproperties == null ||  selectedproperties.Length == 0)
            {
                return query;
            }

            var entityTypes = typeof(TEntity);  //Define Entity Type
            var shapeEntities= new List<TEntity>();

            foreach(var entity in query)
            {
                var shapedEntity = Activator.CreateInstance<TEntity>();

                //Handle Id property Saperately
                var idProperty = entityTypes.GetProperty("Id");
                if(idProperty != null)
                {
                    var idValue = idProperty.GetValue(entity);
                    idProperty.SetValue(shapedEntity, idValue);
                }

                foreach(var selectproperty in selectedproperties)
                {
                    var memberExpression = selectproperty.Body as MemberExpression;
                    if (memberExpression != null)
                    {
                        var propertyName = memberExpression.Member.Name;
                        var propertyValue = selectproperty.Compile()(entity);
                        if(propertyName != "Id") //Skip if the property is Id
                        {
                            entityTypes.GetProperty(propertyName)?.SetValue(shapedEntity, propertyValue);

                        }
                    }

                }

                shapeEntities.Add(shapedEntity);
            }
            return shapeEntities;

        }

        public async Task<Dictionary<TKey, List<TEntity>>> GroupBy<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            var query = _dbSet.GroupBy(keySelector).ToDictionary(g => g.Key, g => g.ToList());
            return query;
             
        }

        public async Task<Dictionary<TKey, int>> GroupByCount<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            var query = _dbSet.GroupBy(keySelector).Select(g => new { Key = g.Key, Count = g.Count() });

            var result = await query.ToDictionaryAsync(x => x.Key, x => x.Count);
            return result;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
