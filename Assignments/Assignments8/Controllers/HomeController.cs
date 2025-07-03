using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Assignments8.Controllers
{
    public class HomeController:Controller
    {
        [Route("Map")]
        public string Index()
        {
            return "This call from Home index method";
        }
        [Route("test")]
        public ContentResult Index2()
        {
            return Content("<h1> Welcome</h1>", "text/html");
        }
        [Route("/")]
        public ContentResult index()
        {
            return new ContentResult() {Content="Hello!",ContentType="Atheer" }; //without inherted from controller class 
        }
        [Route("contact-Us/{mobile:regex(^\\d{{10}})}")]//condition to insert 10 digits 
        public ContentResult contact()
        {
            return Content( $"Welcome from contact us ");
        }
    }
}
