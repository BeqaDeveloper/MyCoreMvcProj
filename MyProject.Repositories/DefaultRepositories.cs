

using Microsoft.EntityFrameworkCore;
using MyProj.Repository.Context;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;
using MyProject.Domain.Interfaces.Core;
using MyProject.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Repositories
{
    public class ForumRepository : RepositoryBase<Forum>, IForumRepository
    {
        public List<Forum> GetForumWithPostAndUser(long forumId)
        {

            return (this._context as MyDbContext).Forums
                .Include(x => x.Posts)
                .ThenInclude(x => x.User)
                .AsQueryable()
                .Where(x => x.Id == forumId)
                .ToList();
        }
        public ForumRepository(IUnitOfWork context) : base(context) { }
    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public List<Post> GetPostsByForum(long forumId)
        {
            return (this._context as MyDbContext).Posts
                .Include(x => x.Forum)
                .AsQueryable()
                .Where(x => x.Forum.Id == forumId)
                .ToList();
        }
        public PostRepository(IUnitOfWork context) : base(context) { }
    }
    public class PostReplyRepository : RepositoryBase<PostReply>, IPostReplyRepository
    {
        public PostReplyRepository(IUnitOfWork context) : base(context) { }
    }

}