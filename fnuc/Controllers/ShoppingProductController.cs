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
    public class ShoppingProductController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ShoppingProductLogic shoppingProduct = new ShoppingProductLogic();
            return Ok(shoppingProduct.RetrieveAll());
        }

        public IHttpActionResult GetById(int id)
        {
            ShoppingProductLogic shoppingProduct = new ShoppingProductLogic();
            return Ok(shoppingProduct.Retrieve(id));
        }
        public IHttpActionResult Post(ShoppingProductBTO shoppingProductBTO)
        {

            ShoppingProductLogic shoppingProduct = new ShoppingProductLogic();
            var model = shoppingProduct.Create(shoppingProductBTO);

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        public IHttpActionResult Put(ShoppingProductBTO shoppingProductBTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            ShoppingProductLogic shoppingProduct = new ShoppingProductLogic();
            var existingShoppingProduct = shoppingProduct.Retrieve(shoppingProductBTO.Id);

            if (existingShoppingProduct != null)
            {
                shoppingProduct.Update(shoppingProductBTO);
            }
            else return NotFound();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            {
                if (id <= 0)
                    return BadRequest("Not a valid shoppingBasket id");

                ShoppingProductLogic shoppingProduct = new ShoppingProductLogic();
                shoppingProduct.Delete(id);

                return Ok("This shoppingBasket is deleted");
            }
        }
    }
}
