

using MyProj.Repository.Context;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;
using MyProject.Domain.Interfaces.Core;

namespace MyProject.Repositories
{
    public class ForumRepository : RepositoryBase<Forum>, IForumRepository
    {
        public ForumRepository(IUnitOfWork context) : base(context) { }
    }
}
