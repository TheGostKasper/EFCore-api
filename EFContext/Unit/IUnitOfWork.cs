using EFContext.GenericRepo;
using EFContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFContext.Unit
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> StudentRepository { get; }
        void Save();
    }
}
