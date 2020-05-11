using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces.Core;
using System;

namespace MyProject.Repository.Context
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
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


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers{ get; set; }
        public virtual DbSet<Post> Posts{ get; set; }
        public virtual DbSet<PostReply> PostReplies{ get; set; }

    }
}



