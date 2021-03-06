﻿
using MyProject.Domain.Entities;
using System.Collections.Generic;

namespace MyProject.Domain.Interfaces
{
    public interface IService<T> where T : class, new()
    {
        T Fetch(long id);
        IEnumerable<T> Set();
        void Save(T entity);
        void Delete(long id);
        void Delete(T entity);
    }

    public interface IForumService : IService<Forum>
    {
        ICollection<Forum> GetForumWithPostAndUser(long forumId);
    }
    public interface IPostService : IService<Post>
    {
        ICollection<Post> GetPostsByForum(long forumId);
    }
    public interface IPostReplyService : IService<PostReply>
    {
    }
}
