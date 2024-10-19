using Microsoft.AspNetCore.Mvc;

namespace ControllersConcept.Controllers
{
    [Controller]// if we don't add Controller in class name we should add attribute
    public class HomeController :Controller
    {
        [Route("index")]
        public ContentResult Index()
        {
            //return new ContentResult() { Content = "oky", 
            //    ContentType = "Atheer" //can be anything 
            //};// old way without using inherited class controller  
           
            //return Content("oky","Atheer");  
            return Content("oky");
        }
        [Route("Data")]
        [Route("/")]
        public string Data()
        {
            return "Hello from HomeController.Data()!";
        }
        [Route("contact/{moblile:regex(^\\d{{10}}$)}")]// (/d) just accept digits 
        public string Data(int moblile)//the rout should be contact/1234567890
        {
            return "Hello from HomeController.Data()!";
        }
    }
}
