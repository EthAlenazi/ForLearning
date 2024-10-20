using Microsoft.AspNetCore.Mvc;

namespace ControllersConcept.Controllers
{
    public class StoreController : Controller
    {
        [Route("store")]
        public IActionResult Index()
        {
            ////RedirectToActionResult: in real world this is better 
            ///based on controller name and action name 

            //return new RedirectToActionResult("GetResult", "Store", new {});//302 Found 
            //return new RedirectToActionResult("GetResult", "Store", new {},permanent :true);//301 Moved Permanently
            //return RedirectToAction("GetResult", "Store", new { });//shortcut 302 Found 
            //return RedirectToActionPermanent("GetResult", "Store", new { });//shortcut 301 Moved Permanently

            ////LocalRedirectResult:  use direct url for local api
            ///based on local specified url

            //return new LocalRedirectResult("/store/book"); //302 Found
            //return new LocalRedirectResult("/store/book",true);//shortcut 301 Moved Permanently 
            //return LocalRedirect("/store/book");//302 Found
            //return LocalRedirectPermanent("/store/book");

            ////RedirectResult : use direct url for any url local or in outside the project 

            //return new RedirectResult("https://translate.google.com/?sl=en&tl=ar&op=translate");
            //return Redirect("https://translate.google.com/?sl=en&tl=ar&op=translate");
            //return RedirectPermanent("https://translate.google.com/?sl=en&tl=ar&op=translate");//shortcut 301 Moved Permanently 
            return new RedirectResult("https://translate.google.com/?sl=en&tl=ar&op=translate", true);//301 Moved Permanently
        }

        [Route("store/book")]
        public IActionResult GetResult()
        {
          return Content("<h1>Redirect Completed!<h1>","text/html");
        }
    }
}
