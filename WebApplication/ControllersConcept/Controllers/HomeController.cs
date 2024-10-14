using Microsoft.AspNetCore.Mvc;

namespace ControllersConcept.Controllers
{
    public class HomeController
    {
        [Route("Data")]
        public string Data()
        {
            return "Hello from HomeController.Data()!";
        }
    }
}
