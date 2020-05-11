using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces.Core;
using System;

namespace MyProject.Repository.Context
{
    public class MyDbContext : DbContext, IUnitOfWork
    {
        #region Unitwork
        public void Commit()
        {
            try
            {
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
        #endregion


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Test2> Test2s { get; set; }


    }
}



