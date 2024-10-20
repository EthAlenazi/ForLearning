using Microsoft.AspNetCore.Mvc;

namespace ControllersConcept.Controllers
{
    public class BookController : Controller
    {
        [Route("book")]
        public IActionResult index()
        {
            //book id can't be null// empty
            if (!Request.Query.ContainsKey("bookId"))
            {
                return BadRequest("book Id is not applied!");
            }
            //book id should be between 1 to 1000
            int bookId = Convert.ToInt32(ControllerContext.
                HttpContext.Request.Query["bookId"]);
            if (bookId <= 0)
            {
                return BadRequest("book Id can't be lees then 0");
            }

            if (bookId > 1000)
            {
                return NotFound("book Id can't br greater then 1000");
            }
            //isLoggedin should be true 
            if (Convert.ToBoolean(Request.Query["isLoggedin"]) == false)
            {
                return Unauthorized("User must be authenticated");
            }
            
            return File("/AtheerALenazi.pdf", "application/pdf");
            //if the type not apply correct the browser will not open file  

        }
    }
}
