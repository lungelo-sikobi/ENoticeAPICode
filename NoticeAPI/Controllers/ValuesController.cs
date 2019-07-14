using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoticeAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private DataAcess da = new DataAcess();
        
        [HttpPost]
        [Route("api/Values/Insert Catagory")]
        public void InsertCategory(Categories obj)
        {
            da.InsertCategory(obj);
        }
        [HttpGet]
        [Route("api/Values/GetAdmin")]
        public IHttpActionResult GetAdmin()
        {
            var list = da.GetAdmins();

            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }


        [HttpGet]
        [Route("api/Values/GetCatagory")]
        public IHttpActionResult GetCategory()
        {
            var list = da.GetCategories();
            
            if(list==null)
            {
                return NotFound();
            }
            return Ok(list);
        }
        
        [HttpPost]
        [Route("api/Values/Insert Admin")]
        public void InsertAdmin(Admin obj)
        {
            da.InsertAdmin(obj);
        }
        [HttpPost]
        [Route("api/Values/Insert Notice")]
        public void InsertNotice(aNotice obj)
        {
            da.InsertNotice(obj);
        }

        [HttpGet]
        [Route("api/Values/GetNoticeData")]
        public IHttpActionResult GetNoticeData()
        {
            var list = da.GetNoticeData();

            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }





        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
