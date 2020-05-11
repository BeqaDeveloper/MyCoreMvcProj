
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces.Core;
using System.Collections.Generic;

namespace MyProject.Domain.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        IUnitOfWork Context { get; }
        T Fetch(long id);
        IEnumerable<T> Set();
        void Save(T entity);
        void Delete(long id);
        void Delete(T entity);
    }
    public interface IForumRepository : IRepository<Forum>
    {
        List<Forum> GetForumWithPostAndUser(long forumId);
    }
    public interface IPostReplyRepository : IRepository<PostReply>
    {

    }
    public interface IPostRepository : IRepository<Post>
    {

    }
   

}
