using Business;
using Common.BTO;
using DAL.Context;
using DAL.Repository;
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
        private DatabaseContext context = new DatabaseContext();


        ///api/Category/?id=1
        //public IHttpActionResult GetById(int id)
        //{
        //    CategoryLogic categ = new CategoryLogic();
        //    return Ok(categ.Retrieve(id));
        //}

        public IHttpActionResult GetById(int id)
        {
            using (CategoryRepo repo = new CategoryRepo(context))
            {
                //De la Logique... 
                var obj = repo.Retrieve(id);

                //return Ok(JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })) ;

                var temp = JsonConvert.SerializeObject(obj,
                    Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                return Ok(obj);
            }
        }

        public IHttpActionResult GetByIdWithChildren(int idParent)
        {
            using (CategoryRepo repo = new CategoryRepo(context))
            {
                //De la Logique... 
                var obj = repo.Retrieve(idParent);

                //return Ok(JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })) ;

                var temp = JsonConvert.SerializeObject(obj,
                    Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                var Response = obj.CategoryToCategoryBTO();
                Response.Children = repo.RetrieveChildren(idParent)
                    .Select(x => x.CategoryToCategoryBTO()).ToList();

                return Ok(Response);
            }
        }



        //public IHttpActionResult PostCreate(CategoryBTO bto)
        //{
        //    CategoryLogic categ = new CategoryLogic();
        //    return Ok(categ.Create(bto));
        //}

    }
}
