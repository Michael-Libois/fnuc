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
    public class CategoryController : ApiController
    {
        ///api/Category/?id=1
        public IHttpActionResult GetById(int id)
        {
            CategoryLogic categ = new CategoryLogic();
            return Ok(categ.Retrieve(id));
        }

        //public IHttpActionResult PostCreate(CategoryBTO bto)
        //{
        //    CategoryLogic categ = new CategoryLogic();
        //    return Ok(categ.Create(bto));
        //}

    }
}
