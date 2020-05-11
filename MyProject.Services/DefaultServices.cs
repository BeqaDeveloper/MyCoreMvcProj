

using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;
using MyProject.Domain.Interfaces.Core;
using MyProject.Repository.Context;
using System.Collections.Generic;

namespace MyProject.Services
{

    public class ForumService : ServiceBase<Forum, IForumRepository>, IForumService
    {

        private IForumRepository _ForumRepository;

        public ForumService(IUnitOfWork context, IForumRepository ForumRepository) : base(context, ForumRepository)
        {
            _ForumRepository = ForumRepository;
        }
        public ICollection<Forum> GetForumWithPostAndUser(long forumId)
        {
            return _ForumRepository.GetForumWithPostAndUser(forumId);
        }
    }

    public class PostService : ServiceBase<Post, IPostRepository>, IPostService
    {

        private IPostRepository _PostRepository;

        public PostService(IUnitOfWork context, IPostRepository PostRepository) : base(context, PostRepository)
        {
            _PostRepository = PostRepository;
        }
        public ICollection<Post> GetPostsByForum(long forumId)
        {
            return _PostRepository.GetPostsByForum(forumId);
        }
    }

    public class PostReplyService : ServiceBase<PostReply, IPostReplyRepository>, IPostReplyService
    {

        private IPostReplyRepository _PostReplyRepository;

        public PostReplyService(IUnitOfWork context, IPostReplyRepository PostReplyRepository) : base(context, PostReplyRepository)
        {
            _PostReplyRepository = PostReplyRepository;
        }
    }

}
