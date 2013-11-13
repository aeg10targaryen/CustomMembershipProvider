using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Data.Infrastructure
{
    public class Repository<T> where T : class
    {
        private static IDbSet<T> _dbSet;
        private static readonly DatabaseFactory DatabaseFactory = new DatabaseFactory();

        public static T Get(int id)
        {
            T data;
            try
            {
                var dataContext = DatabaseFactory.Get();
                _dbSet = dataContext.Set<T>();
                data = _dbSet.Find(id);

                if (data == null)
                {
                    throw new Exception(typeof(T).Name + " not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }

        public static T Get(Expression<Func<T, bool>> where)
        {
            T data;
            try
            {
                var dataContext = DatabaseFactory.Get();
                _dbSet = dataContext.Set<T>();
                data = _dbSet.FirstOrDefault(where);

                if (data == null)
                {
                    throw new Exception(typeof(T).Name + " not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }

        public static List<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            List<T> data;
            try
            {
                var dataContext = DatabaseFactory.Get();
                _dbSet = dataContext.Set<T>();

                data = _dbSet.Where(predicate).ToList();

                if (data.Count == 0)
                    throw new Exception(typeof(T).Name + "s not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return data;
        }

        public static List<T> GetAll()
        {
            List<T> data;
            try
            {
                var dataContext = DatabaseFactory.Get();
                _dbSet = dataContext.Set<T>();
                data = _dbSet.ToList();
                if (data.Count == 0)
                {
                    throw new Exception(typeof(T).Name + "s not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }

        public static void Create(T createItem)
        {
            try
            {
                var dataContext = DatabaseFactory.Get();
                IUnitOfWork unitOfWork = new UnitOfWork(DatabaseFactory);
                _dbSet = dataContext.Set<T>();
                _dbSet.Add(createItem);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Edit(T editItem)
        {
            try
            {
                var dataContext = DatabaseFactory.Get();
                IUnitOfWork unitOfWork = new UnitOfWork(DatabaseFactory);
                _dbSet = dataContext.Set<T>();
                var entry = dataContext.Entry(editItem);
                _dbSet.Attach(editItem);
                entry.State = EntityState.Modified;
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(int id)
        {
            try
            {
                var dataContext = DatabaseFactory.Get();
                IUnitOfWork unitOfWork = new UnitOfWork(DatabaseFactory);
                _dbSet = dataContext.Set<T>();
                var deleteModel = _dbSet.Find(id);
                _dbSet.Remove(deleteModel);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(Expression<Func<T, bool>> where)
        {
            try
            {
                var dataContext = DatabaseFactory.Get();
                IUnitOfWork unitOfWork = new UnitOfWork(DatabaseFactory);
                _dbSet = dataContext.Set<T>();

                var deleteModel = _dbSet.FirstOrDefault(where);
                _dbSet.Remove(deleteModel);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
