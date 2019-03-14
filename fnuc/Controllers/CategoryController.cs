using Business;
using Common.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Business.Extensions;

namespace fnuc.Controllers
{
    public class CategoryController : ApiController
    {
        //private DatabaseContext context = new DatabaseContext();


        ///api/Category/?id=1
        //public IHttpActionResult GetById(int id)
        //{
        //    CategoryLogic categ = new CategoryLogic();
        //    return Ok(categ.Retrieve(id));
        //}

        //public IHttpActionResult GetById(int id)
        //{
        //    using (CategoryRepo repo = new CategoryRepo(context))
        //    {
        //        //De la Logique... 
        //        var obj = repo.Retrieve(id);

        //        //return Ok(JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })) ;

        //        //var temp = JsonConvert.SerializeObject(obj,
        //        //    Formatting.Indented,
        //        //    new JsonSerializerSettings()
        //        //    {
        //        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //        //    });

        //        return Ok(obj);
        //    }
        //}
        public IHttpActionResult GetAllWithChildren()
        {
            CategoryLogic categ = new CategoryLogic();
            return Ok(categ.RetrieveAllWithChildren());
        }

        public IHttpActionResult GetAll()
        {
            CategoryLogic categ = new CategoryLogic();
            return Ok(categ.RetrieveAllWithoutChildren());
        }



        public IHttpActionResult GetById(int idParent)
        {
            //using (CategoryRepo repo = new CategoryRepo(context))
            //{
            //    //De la Logique... 
            //    var obj = repo.Retrieve(idParent);

            //    //return Ok(JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })) ;

            //    //var temp = JsonConvert.SerializeObject(obj,
            //    //    Formatting.Indented,
            //    //    new JsonSerializerSettings()
            //    //    {
            //    //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //    //    });

            //    var Response = obj.CategoryToCategoryBTO();
            //    Response.Children = repo.RetrieveChildren(idParent)
            //        .Select(x => x.CategoryToCategoryBTO()).ToList();

            CategoryLogic categ = new CategoryLogic();
            return Ok(categ.Retrieve(idParent));

        }

        public IHttpActionResult Post(CategoryBTO categBto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            CategoryLogic categ = new CategoryLogic();
            var model = categ.Create(categBto);

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        public IHttpActionResult Put(CategoryBTO categBto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            CategoryLogic categ = new CategoryLogic();
            var existingCateg = categ.Retrieve(categBto.Id);

            if (existingCateg != null)
            {
                categ.Update(categBto);
            }
            else return NotFound();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            {
                if (id <= 0)
                    return BadRequest("Not a valid category id");

                //using (DishRepo repo = new DishRepo(databaseContext))
                //{
                //    repo.Delete(id);
                //}

                CategoryLogic categ = new CategoryLogic();
                categ.Delete(id);

                return Ok("This category is deleted");
            }
        }





        //public IHttpActionResult PostCreate(CategoryBTO bto)
        //{
        //    CategoryLogic categ = new CategoryLogic();
        //    return Ok(categ.Create(bto));
        //}

    }
}
