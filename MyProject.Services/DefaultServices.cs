

using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;
using MyProject.Domain.Interfaces.Core;
using MyProject.Repository.Context;

namespace MyProject.Services
{

    public class ForumService : ServiceBase<Forum, IForumRepository>, IForumService
    {

        private IForumRepository _ForumRepository;

        public ForumService(IUnitOfWork context, IForumRepository ForumRepository) : base(context, ForumRepository)
        {
            _ForumRepository = ForumRepository;
        }
    }

    public class PostService : ServiceBase<Post, IPostRepository>, IPostService
    {

        private IPostRepository _PostRepository;

        public PostService(IUnitOfWork context, IPostRepository PostRepository) : base(context, PostRepository)
        {
            _PostRepository = PostRepository;
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
