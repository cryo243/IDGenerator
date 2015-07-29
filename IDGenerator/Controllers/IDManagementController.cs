using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IDGenerator.Models;
using System.Web;


namespace IDGenerator.Controllers
{
    public class IDManagementController : ApiController
    {
        // GET api/idmanagement
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };


        }

        // GET api/idmanagement/5
        public string Get(int id)
        {
           
            return "value";
        }

        // POST api/idmanagement
        public ResponseObject Post([FromBody]User u)
        {
          
            
            if (String.IsNullOrEmpty(u.country) || String.IsNullOrEmpty(u.gender) || String.IsNullOrEmpty(u.dateOfBirth))
            {
               
                return new ResponseObject
                {
                    message = "Some of the required fields were empty"
                };
            }
            
               var user = new User
               {
                country = u.country,
                dateOfBirth = u.dateOfBirth,
                gender = u.gender

             };
            return new ResponseObject
            {
                id = user.getGeneratedID(),
                message = (user.getGeneratedID()!=null)?"success":"Some of the data supplied were invalid"
            };
            
          
               
        }

        // PUT api/idmanagement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/idmanagement/5
        public void Delete(int id)
        {
        }
        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
