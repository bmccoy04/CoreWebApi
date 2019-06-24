using CoreWebApi.Core.Shared;
using System.Collections.Generic;

namespace CoreWebApi.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : BaseEntity;

        IEnumerable<T> List<T>() where T : BaseEntity;
        
        T Add<T>(T entity) where T : BaseEntity;

        void Update<T>(T entity) where T : BaseEntity;

        void Delete<T>(T entity) where T : BaseEntity;
    }
}