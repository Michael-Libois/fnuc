using Business;
using Common.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace fnuc.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            UserLogic user = new UserLogic();
            return Ok(user.RetrieveAll());
        }

        public IHttpActionResult GetById(int id)
        {

            UserLogic user = new UserLogic();
            return Ok(user.Retrieve(id));

        }

        public IHttpActionResult Post(UserBTO userBto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            UserLogic user = new UserLogic();
            var model = user.Create(userBto);

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        public IHttpActionResult Put(UserBTO userBto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            UserLogic user = new UserLogic();
            var existingUser = user.Retrieve(userBto.Id);

            if (existingUser != null)
            {
                user.Update(userBto);
            }
            else return NotFound();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            {
                if (id <= 0)
                    return BadRequest("Not a valid user id");

                UserLogic user = new UserLogic();
                user.Delete(id);

                return Ok("This user was deleted");
            }
        }
    }
}
