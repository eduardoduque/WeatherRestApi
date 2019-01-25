using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Script.Serialization;
using System.Text;

namespace varoos.restapi.Models
{
    public class JsonDataContext : DataContext
    {
        JavaScriptSerializer Serializer { get; set; }
        private string _dataPath;
        public JsonDataContext()
        {
            _dataPath = HostingEnvironment.MapPath("~/App_Data/Data.json");
            Serializer = new JavaScriptSerializer();
        }

        public override List<Person> GetAllPeople()
        {
            var users = new List<Person>();
            // leer la base de datos
            var input = File.ReadAllText(_dataPath);
            users = (List<Person>)Serializer.Deserialize(input, typeof(List<Person>));
            return users == null ? new List<Person>() : users;
        }
        public override void SavePeople(List<Person> people)
        {
            // actualizar base de datos
            var output = "";
            var sb = new StringBuilder(output);
            Serializer.Serialize(people, sb);
            using (var writer = new StreamWriter(_dataPath))
            {
                writer.Write(sb.ToString());
            }
        }
       
    }
}