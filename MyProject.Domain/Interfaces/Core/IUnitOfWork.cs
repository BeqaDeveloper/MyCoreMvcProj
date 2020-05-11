using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Domain.Interfaces.Core
{
   public interface  IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
