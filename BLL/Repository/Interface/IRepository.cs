using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<int> Count(Expression<Func<TEntity, bool>> predicate);
        Task<Dictionary<TKey, List<TEntity>>> GroupBy<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        Task<Dictionary<TKey, int>> GroupByCount<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetSingleIncluding(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IEnumerable<TEntity>> GetConditional(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetWithShaping(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IEnumerable<TEntity>> GetConditionalIncluding(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includeProperties);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAll();
    }
}
