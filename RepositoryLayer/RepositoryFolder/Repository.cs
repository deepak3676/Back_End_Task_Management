using DomainLayer.ApplicationDbContext;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepositoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.RepositoryFolder
{
    public class Repository<T>:IRepository1<T> where T : taskStruct
    {
        #region property
        private readonly appDbContext _applicationDbContext;
        private DbSet<T> entities;
        #endregion
        #region Constructor
        public Repository(appDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        #endregion
        public void Delete(int Id)
        {
            var result=_applicationDbContext.taskTable.FirstOrDefault(l=>l.Id == Id);

            if (result!= null)
            {
                _applicationDbContext.taskTable.Remove(result);
                _applicationDbContext.SaveChanges();
            }
        }
        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }
    }
}
