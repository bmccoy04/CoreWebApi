using CoreWebApi.Core.Interfaces;
using CoreWebApi.Core.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreWebApi.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _appDbContext;

        public EfRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
            return _appDbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>() where T : BaseEntity
        {
            return _appDbContext.Set<T>().ToList();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _appDbContext.Set<T>().Add(entity);
            _appDbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _appDbContext.Set<T>().Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
