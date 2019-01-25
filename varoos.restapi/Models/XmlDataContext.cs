using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace varoos.restapi.Models
{
    public class XmlDataContext : DataContext
    {
        public XmlSerializer Serializer { get; private set; }
        private string _dataPath;
        public XmlDataContext()
        {
            _dataPath = HostingEnvironment.MapPath("~/App_Data/Data.xml");
            Serializer = new XmlSerializer(typeof(List<Person>));
        }
        public override List<Person> GetAllPeople()
        {
            var users = new List<Person>();
            // leer la base de datos
            using (var reader = new StreamReader(_dataPath))
            {
                users = (List<Person>)Serializer.Deserialize(reader);
            }
            return users;
        }

        public override void SavePeople(List<Person> people)
        {
            // actualizar base de datos
            using (var writer = new StreamWriter(_dataPath))
            {
                Serializer.Serialize(writer, people);
            }
        }
    }
}