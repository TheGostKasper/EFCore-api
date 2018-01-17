using System.Collections.Generic;
using System.Linq;
using EFContext;
using EFContext.Models;
using EFContext.Unit;
using Microsoft.AspNetCore.Mvc;

namespace EFApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly UnitOfWork _context;
        public StudentController(SchoolContext context)
        {
            _context = new UnitOfWork(context);
        }
        // GET api/values
        [HttpGet]
        public IQueryable<Student> Get()
        {
            
            var res = _context.StudentRepository.GetAll();
            return res;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            var results = _context.StudentRepository.FindBy(e => e.ID == id).FirstOrDefault();
           

            return results;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            _context.StudentRepository.Add(student);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Student student)
        {
            //var results = _context.StudentRepository.FindBy(e => e.ID == id).FirstOrDefault();
            _context.StudentRepository.Edit(student);
            _context.Save();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _context.StudentRepository.FindBy(e => e.ID == id).FirstOrDefault();
            _context.StudentRepository.Delete(student);
        }
    }
}
