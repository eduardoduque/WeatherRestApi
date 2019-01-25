using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;
using varoos.restapi.Models;

namespace varoos.restapi.Controllers
{
    public class UserController : ApiController
    {
        public DataContext Context { get; private set; }
        
        public UserController()
        {
            Context = new XmlDataContext();
        }

        [HttpPost]
        public void AddUser([FromBody] Person user)
        {
            Context.AddUser(user);
        }

        [HttpGet]
        public IList<Person> GetAllUsers()
        {
            return Context.GetAllPeople();
        }

        [HttpDelete]
        public void DeleteUser(int id)
        {
            Context.DeleteUser(id);
        }
    }
}
