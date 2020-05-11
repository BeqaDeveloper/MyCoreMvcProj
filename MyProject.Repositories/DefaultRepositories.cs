

using MyProj.Repository.Context;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;
using MyProject.Domain.Interfaces.Core;

namespace MyProject.Repositories
{
    public class TestRepository : RepositoryBase<Test>, ITestRepository
    {
        public TestRepository(IUnitOfWork context) : base(context) { }
    }
    public class Test2Repository : RepositoryBase<Test2>, ITest2Repository
    {
        public Test2Repository(IUnitOfWork context) : base(context) { }
    }

}
