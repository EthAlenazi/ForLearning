using Microsoft.AspNetCore.Mvc;
using ModelBinding_Validations.Models;

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
        [Route("User")]
        public IActionResult Index([Bind(nameof(person.Name))]Person person)
        {
            if (!ModelState.IsValid) 
            {
                //var errors = new List<string>();
                //foreach(var value in ModelState.Values)
                //{
                //    foreach (var item in value.Errors)
                //    {
                //        errors.Add(item.ErrorMessage);
                //    }
                //}
                //return BadRequest(errors);

                // after use LINQ
                var error = ModelState.Values.SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage).ToList();
                return BadRequest(error); 
            }
            return Content($"{person}");
        }
    }
}
