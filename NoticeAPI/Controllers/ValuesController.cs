using Notice.DAL;
using Notice.Models;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace NoticeAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private DataAcess da = new DataAcess();
        //Admin API's
        [HttpPost]
        [Route("api/Values/Insert Admin")]
        public void InsertAdmin(Admin obj)
        {
            da.InsertAdmin(obj);
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


        //Category API's
        [HttpPost]
        [Route("api/Values/Insert Catagory")]
        public void InsertCategory(Categories obj)
        {
            da.InsertCategory(obj);
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
        

       //Notice API's
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
            var list = da.GetNoticesData();

            if (list == null)
            {
                return NotFound();
            }
             return Ok(list);
        }



       
        //atttachment API's
        [HttpPost]
        [Route("api/Values/InsertAttachmnents")]
        public void InsertAttachments(ImageAttach obj)
        {
            da.InsertAttachment(obj);
        }


        [HttpGet]
        [Route("api/Values/GetAttachmnents")]
        public IHttpActionResult GetAttachmnents()
        {
            var list = da.GetAttachment();

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
