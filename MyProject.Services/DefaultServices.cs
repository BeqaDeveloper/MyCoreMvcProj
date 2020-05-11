

using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;
using MyProject.Domain.Interfaces.Core;
using MyProject.Repository.Context;

namespace MyProject.Services
{

    public class TestService : ServiceBase<Test, ITestRepository>, ITestService
    {

        private ITestRepository _testRepository;

        public TestService(IUnitOfWork context, ITestRepository TestRepository) : base(context, TestRepository)
        {
            _testRepository = TestRepository;
        }
    }

    public class Test2Service : ServiceBase<Test2, ITest2Repository>, ITest2Service
    {

        private ITest2Repository _Test2Repository;

        public Test2Service(IUnitOfWork context, ITest2Repository Test2Repository) : base(context, Test2Repository)
        {
            _Test2Repository = Test2Repository;
        }
    }


}
