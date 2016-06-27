using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.Interface
{
    public interface IRepository<TEntity> 
        where TEntity : IDalEntity
    {
        IEnumerable<TEntity> GetALL();

        TEntity Get(int id);

        TEntity GetByPredicate(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> GetManyByPredicate(Expression<Func<TEntity, bool>> expression);
         
        TEntity Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

    }
}
