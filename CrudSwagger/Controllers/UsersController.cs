using CrudSwagger.Context;
using CrudSwagger.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly CRUDContext _CRUDContext;

        public UsersController(CRUDContext CRUDContext)
        {
            _CRUDContext = CRUDContext;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _CRUDContext.Users;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return _CRUDContext.Users.SingleOrDefault(x=>x.userId==id);
        }     

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Users users)
        {
            var item = _CRUDContext.Users.FirstOrDefault(x => x.DocumentCi == users.DocumentCi);

            if (item == null)
            {
                _CRUDContext.Users.Add(users);
                _CRUDContext.SaveChanges();
            }
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users users)
        {
            users.userId = id;
            _CRUDContext.Users.Update(users);
            _CRUDContext.SaveChanges();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CRUDContext.Users.FirstOrDefault(x=>x.userId==id);
            if(item != null)
            {
                _CRUDContext.Users.Remove(item);
                _CRUDContext.SaveChanges();
            }
        }
    }
}
