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
    public class ProductController : ApiController
    {
        
        public IHttpActionResult GetAll()
        {
            ProductLogic categ = new ProductLogic();
            return Ok(categ.RetrieveAll());
        }

        [Route("api/product/{id}")]
        public IHttpActionResult GetById(int id)
        {
            
            ProductLogic categ = new ProductLogic();
            return Ok(categ.Retrieve(id==1?9:id));

        }

        //TODO : getByName
        //TODO : getByCategory


        public IHttpActionResult Post(ProductBTO productBto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            ProductLogic categ = new ProductLogic();
            var model = categ.Create(productBto);

            return CreatedAtRoute("DefaultApi", new { id = model.id }, model);
        }

        public IHttpActionResult Put(ProductBTO productBto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            ProductLogic categ = new ProductLogic();
            var existingCateg = categ.Retrieve(productBto.id);

            if (existingCateg != null)
            {
                categ.Update(productBto);
            }
            else return NotFound();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            {
                if (id <= 0)
                    return BadRequest("Not a valid category id");
                
                ProductLogic categ = new ProductLogic();
                categ.Delete(id);

                return Ok("This category is deleted");
            }
        }


    }
}
