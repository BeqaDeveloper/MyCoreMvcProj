

using MyProj.Repository.Context;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;
using MyProject.Domain.Interfaces.Core;
using MyProject.Repository.Context;
using System.Collections.Generic;

namespace MyProject.Repositories
{
    public class ForumRepository : RepositoryBase<Forum>, IForumRepository
    {
        public ForumRepository(IUnitOfWork context) : base(context) { }
    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IUnitOfWork context) : base(context) { }
    }
    public class PostReplyRepository : RepositoryBase<PostReply>, IPostReplyRepository
    {
        public PostReplyRepository(IUnitOfWork context) : base(context) { }
    }

}