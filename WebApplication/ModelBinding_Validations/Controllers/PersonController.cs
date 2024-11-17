using Microsoft.AspNetCore.Mvc;

namespace ModelBinding_Validations.Controllers
{
    public class PersonController : Controller
    {
        //ModelBinding sort
        //query string -4
        /// <summary>
        /// [FromQuery] 
        /// data after ? in url 
        /// data?id=2
        /// </summary>
        //Route Data   -3
        ///<summary>
        ///[FromRoute]
        ///data applayed in url 
        ///data/6/female
        ///</summary>
        //Request body -2
        //from fields  -1
        ///<summary>
        ///data submitted by html forms
        ///</summary>
        ///
        [Route("User/{name?}")]
        public IActionResult Index(string name)
        {
            return View();
        }
    }
}
