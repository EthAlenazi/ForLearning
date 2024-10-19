using ControllersConcept.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersConcept.Controllers
{
    [Controller]// if we don't add Controller in class name we should add attribute
    public class HomeController :Controller
    {
        [Route("index")]
        public ContentResult Index_ContentResult()
        {
            //return new ContentResult() { Content = "oky", 
            //    ContentType = "Atheer" //can be anything 
            //};// old way without using inherited class controller  
           
            //return Content("oky","Atheer");  
            return Content("oky");
        }
        [Route("index2")]
        public JsonResult Index_JsonResult()
        {
            Person person = new Person() { 
            Id= Guid.NewGuid(),
            Name="Atheer",
            Age= 27};
            return Json(person);// this way or second one both work
           // return new JsonResult(person);
        }

        [Route("download-file")]//open file
        public VirtualFileResult Index_File()
        {
            return new VirtualFileResult("/AtheerALenazi.pdf", "application/pdf");
        }
        [Route("download-file1")]//open file
        public FileContentResult Index_File2()// for return file when we store it as byte in DB
        {
           byte[] fileBytes=  System.IO.File.
                ReadAllBytes("C:\\Sorce\\ForLearning\\WebApplication\\ControllersConcept\\wwwroot\\AtheerALenazi.pdf");
            return File(fileBytes, "application/pdf");
        }
        [Route("download-file2")]//open file
        public PhysicalFileResult Index_File3()//for return file if we don't have it in wwwroot 
        {
            return new PhysicalFileResult("C:\\Sorce\\ForLearning\\WebApplication\\ControllersConcept\\wwwroot\\AtheerALenazi.pdf",
                "application/pdf");
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
