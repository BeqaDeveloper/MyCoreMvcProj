

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

  


}
