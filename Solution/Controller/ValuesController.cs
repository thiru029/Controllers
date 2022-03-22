using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Models;
using System;
using Solution.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Solution;

namespace Solution.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UserRepository repository;
   
        public ValuesController()
        {
            this.repository = new UserRepository("User Id=postgres;Password=smile@ME;Host=localhost;Database=Solution");
        }
  
        [HttpGet]

        public ActionResult<IEnumerable<User>> Get()
        {
            var result=repository.GetAll();
            return Ok(result.Select(x => new
            {
                Id = x.Id,
                Email = x.Email,
                IsUpdated = x.IsUpdated,
                Password = x.Password
            }));
        }


        //[HttpGet("{id}")]

        //public ActionResult<User> Get(string id)
        //{
        //    repository.Get(id);
        //    return Ok(id);
        //}


        //[HttpPost]

        //public ActionResult<User> Post(object user)
        //{
        //    repository.Create(user);
        //    return Ok(user);
        //}


        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            repository.Create(user);
            return user;
        }


        [HttpPut]
        
        public ActionResult<User> Put(object user)
        {
            repository.Update(user);
            return Ok();
        }



        [HttpDelete]

        public ActionResult<User> Delete(string id)
        {
            var temp=repository.Get(id);
            repository.Delete(temp);
            return Ok(temp);
        }




    }
}
