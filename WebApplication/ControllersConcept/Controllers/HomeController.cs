using Microsoft.AspNetCore.Mvc;

namespace ControllersConcept.Controllers
{
    [Controller]// if we don't add Controller in class name we should add attribute
    public class HomeController   {
        [Route("Data")]
        [Route("/")]
        public string Data()
        {
            return "Hello from HomeController.Data()!";
        }
        [Route("contact/{moblile:regex(^\\d{{10}}$)}")]// (/d) just accept digets 
        public string Data(int moblile)//the rout shoul be contact/1234567890
        {
            return "Hello from HomeController.Data()!";
        }
    }
}
