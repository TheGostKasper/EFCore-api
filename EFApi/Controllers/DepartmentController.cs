using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFContext;
using EFContext.Helper;
using EFContext.Models;
using EFContext.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFApi.Controllers
{
    [Produces("application/json")]
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        private readonly UnitOfWork _context;
        public DepartmentController(SchoolContext context)
        {
            _context = new UnitOfWork(context);
        }
        // GET api/Department
        [HttpGet]
        public IQueryable<VngDepartment> Get()
        {

            var res = _context.DepartmentRepository.GetAll();
            return res;
        }

        [HttpPost]
        [Route("pages")]
        public IQueryable<VngDepartment> GetPages([FromBody]RequestObj req)
        {

            var res = _context.DepartmentRepository.GetPages(req.PageNumber, req.PageSize);
            return res;
        }

        // GET/Department/5
        [HttpGet("{id}")]
        public VngDepartment Get(int id)
        {
            var results = _context.DepartmentRepository.FindBy(e => e.Id == id).FirstOrDefault();


            return results;
        }

        // POST/Department
        [HttpPost]
        public void Post([FromBody]VngDepartment Department)
        {
            _context.DepartmentRepository.Add(Department);
        }

        // PUT/Department/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]VngDepartment Department)
        {
            //var results = _context.DepartmentRepository.FindBy(e => e.ID == id).FirstOrDefault();
            _context.DepartmentRepository.Edit(Department);
            _context.Save();
        }

        // DELETE/Department/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Department = _context.DepartmentRepository.FindBy(e => e.Id == id).FirstOrDefault();
            _context.DepartmentRepository.Delete(Department);
        }
    }
}
