using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using HelloWorld.Models;

namespace HelloWorld
{
    [DataContract]
    public class Service : IService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [DataMember]
        private List<string> users = new List<string>();

        public List<string> GetUsers()
        {
            foreach(var item in db.Users.ToList())
            {
                users.Add(item.UserName.ToString());
            }

            return users;
        }
    }
}
