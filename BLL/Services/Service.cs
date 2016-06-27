using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities.Interface;
using BLL.Services.Interface;
using DAL.DTO;
using DAL.Interface;
using BLL.Mappers;

namespace BLL.Services
{
    public class Service<T, U> : IService<T>
        where T : class, IBllEntity
        where U : class, IDalEntity
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<U> repository;
        public Service(IUnitOfWork uow, IRepository<U> repository)
        {
            this.uow = uow;
            this.repository = repository;
        }

        public T CreateEntity(T entity)
        {
            var retEntity = Mapper.ToBll(repository.Create(Mapper.ToDal(entity) as U)) as T;
            uow.Commit();
            return retEntity;
        }

        public void DeleteEntity(T entity)
        {
            repository.Delete(Mapper.ToDal(entity) as U);
            uow.Commit();
        }

        public IEnumerable<T> GetALLEntities()
        {
            return repository.GetALL().Select(element => (T) Mapper.ToBll(element));
        }

        public T GetEntity(int id)
        {
            return Mapper.ToBll(repository.Get(id)) as T;
        }

        public T GetEntityByPredicate(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(T entity)
        {
            repository.Update(Mapper.ToDal(entity) as U);
            uow.Commit();
        }
    }
}
