using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepositoryFolder
{
    public interface IRepository1<T> where T : taskStruct
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByUserName(string userName);
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int Id);
        void SaveChanges();
    }
}
