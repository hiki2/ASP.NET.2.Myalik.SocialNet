using DAL.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Mappers;
using static Binbin.Linq.PredicateBuilder;

namespace DAL.Classes
{
    public class Repository<T,U> : IRepository<T>
        where T : class, IDalEntity, new()
        where U : class, IOrmEntity, new()
    {

        private readonly SocialNetDB context;
        public Repository(SocialNetDB uow)
        {
            context = uow;
        }

        public T Create(T entity)
        {
            var retobject = context.Set<U>().Add(Mapper.ToOrm(entity) as U);
            context.SaveChanges();
            return Mapper.ToDal(retobject) as T;
        }

        public void Delete(T entity)
        {
            var ormEntity = Mapper.ToOrm(entity);
            ormEntity = context.Set<U>().Single(u => u.id == ormEntity.id);
            context.Set<U>().Remove((U) ormEntity);
        }

        public T Get(int id)
        {
            var retEntity = context.Set<U>().FirstOrDefault(entity => entity.id == id);
            return retEntity != null ? (T)Mapper.ToDal(retEntity) : null;
        }

        public IEnumerable<T> GetALL()
        {
            var elements = context.Set<U>().Select(entity => entity);
            var retElements = new List<T>();
            foreach (var entity in elements)
                retElements.Add((T)Mapper.ToDal(entity));    
            return retElements;
        }

        public T GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                var p = predicate.Compile();
                foreach (var elem in context.Set<U>().Select(e => e))
                {
                    var temp = Mapper.ToDal(elem) as T;
                    if (p(temp))
                        return temp;
                }
                return null;
            }
            throw new ArgumentNullException(nameof(predicate), "Predicate is null");
        }


        public IEnumerable<T> GetManyByPredicate(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                var p = predicate.Compile();
                foreach (var elem in context.Set<U>().Select(e => e))
                {
                    var temp = Mapper.ToDal(elem) as T;
                    if (p(temp))
                        yield return temp;
                }
                yield break;
            }
            throw new ArgumentNullException(nameof(predicate), "Predicate is null");
        }

        public void Update(T entity)
        {
            var ormEntity = context.Set<U>().Find(entity.id);
            if (ormEntity != null)
                context.Entry(ormEntity).CurrentValues.SetValues(entity);
        }
    }
}
