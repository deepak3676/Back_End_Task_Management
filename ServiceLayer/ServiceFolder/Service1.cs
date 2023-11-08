using DomainLayer.Models;
using RepositoryLayer.IRepositoryFolder;
using ServiceLayer.IServiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceFolder
{
    public class Service1:IService<taskStruct>
    {
        private readonly IRepository1<taskStruct> _taskRepository;
        public Service1(IRepository1<taskStruct> taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public bool Delete(string Id)
        {
            try
            {
                _taskRepository.Delete(Convert.ToInt32(Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public taskStruct Get(int Id)
        {
            try
            {
                var obj = _taskRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<taskStruct> GetAll()
        {
            try
            {
                var obj = _taskRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Insert(taskStruct entity)
        {
            try
            {
                if (entity != null)
                {
                    _taskRepository.Insert(entity);
                    _taskRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public void Update(taskStruct entity)
        {
            try
            {
                if (entity != null)
                {
                    _taskRepository.Update(entity);
                    _taskRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
