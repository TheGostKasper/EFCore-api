using EFContext.GenericRepo;
using EFContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFContext.Unit
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SchoolContext _bloggingContext;
        private IGenericRepository<Student> _studentRepository;
        private IGenericRepository<VngDepartment> _departmentRepository;
        public UnitOfWork(SchoolContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        public IGenericRepository<Student> StudentRepository
        {
            get
            {
                return _studentRepository = _studentRepository ?? new GenericRepository<Student>(_bloggingContext);
            }
        }
        public IGenericRepository<VngDepartment> DepartmentRepository
        {
            get
            {
                return _departmentRepository = _departmentRepository ?? new GenericRepository<VngDepartment>(_bloggingContext);
            }
        }

        public void Dispose()
        {
            _bloggingContext.Dispose();
        }

        public void Save()
        {
            _bloggingContext.SaveChanges();
        }
    }
}
