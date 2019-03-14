using Business;
using Common.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace fnuc.Controllers
{
    public class ShoppingBasketController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ShoppingBasketLogic shoppingBasket = new ShoppingBasketLogic();
            return Ok(shoppingBasket.RetrieveAll());
        }

        public IHttpActionResult GetById(int id)
        {
            ShoppingBasketLogic shoppingBasket = new ShoppingBasketLogic();
            return Ok(shoppingBasket.Retrieve(id));
        }

        public IHttpActionResult Post(ShoppingBasketBTO shoppingBasketBTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            ShoppingBasketLogic shoppingBasket = new ShoppingBasketLogic();
            var model = shoppingBasket.Create(shoppingBasketBTO);

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        public IHttpActionResult Delete(int id)
        {
            {
                if (id <= 0)
                    return BadRequest("Not a valid shoppingBasket id");

                ShoppingBasketLogic shoppingBasket = new ShoppingBasketLogic();
                shoppingBasket.Delete(id);

                return Ok("This shoppingBasket is deleted");
            }
        }
    }
}
