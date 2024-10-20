using Microsoft.AspNetCore.Mvc;

namespace ControllersConcept.Controllers
{
    public class StoreController : Controller
    {
        [Route("store")]
        public IActionResult Index()
        {
            ////RedirectToActionResult

            //return new RedirectToActionResult("GetResult", "Store", new {});//302 Found 
            //return new RedirectToActionResult("GetResult", "Store", new {},permanent :true);//301 Moved Permanently
            //return RedirectToAction("GetResult", "Store", new { });//shortcut 302 Found 
            return RedirectToActionPermanent("GetResult", "Store", new { });//shortcut 301 Moved Permanently
        }

        [Route("store/book")]
        public IActionResult GetResult()
        {
          return Content("<h1>Redirect Completed!<h1>","text/html");
        }
    }
}
