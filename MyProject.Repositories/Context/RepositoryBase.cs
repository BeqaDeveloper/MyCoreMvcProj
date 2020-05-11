
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Interfaces;
using MyProject.Domain.Interfaces.Core;
using MyProject.Repository.Context;
using System;
using System.Collections.Generic;
using static MyProject.Domain.Enumerations.Enumerations;

namespace MyProj.Repository.Context
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, new()
    {

        protected MyDbContext _context;

        public IUnitOfWork Context
        {
            get { return _context; }
        }

        internal RepositoryBase(IUnitOfWork context) : this(context as MyDbContext) { }

        internal RepositoryBase(MyDbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
            //Custom seed method need to change
            //(new SeedMigration()).SeedUpEntities(context);
        }

        public virtual T Fetch(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> Set()
        {
            return _context.Set<T>();
        }

        public virtual void Save(T entity)
        {
            Save(_context.Set<T>(), entity);
        }

        public virtual void Delete(long id)
        {
            Delete(Fetch(id));
        }

        public virtual void Delete(T entity)
        {
            Delete(_context.Set<T>(), entity);
        }

        protected virtual void Save(DbSet<T> set, T entity)
        {
            LogAction action;
            var entry = _context.Entry(entity);
            if (entry == null || entry.State == EntityState.Detached)
            {
                action = LogAction.Insert;
                set.Add(entity);
            }
            else
            {
                action = LogAction.Update;
            }
            if (entity is ILoggable) LogEntityAction(action);
        }

        protected virtual void Delete(DbSet<T> set, T entity)
        {
            set.Remove(entity);
            if (entity is ILoggable) LogEntityAction(LogAction.Delete);
        }

        protected virtual void LogEntityAction(LogAction action)
        {
            throw new NotImplementedException("LogAction is not iemented for ILoggable entity.");
        }
    }
}
