using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities.Interface;

namespace BLL.Services.Interface
{
    public interface IService<TBllEntity> 
        where TBllEntity : IBllEntity
    {
        IEnumerable<TBllEntity> GetALLEntities();

        TBllEntity GetEntity(int id);

        TBllEntity GetEntityByPredicate(Expression<Func<TBllEntity, bool>> expression);

        TBllEntity CreateEntity(TBllEntity entity);

        void DeleteEntity(TBllEntity entity);

        void UpdateEntity(TBllEntity entity);

    }
}
