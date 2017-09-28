using SimpleTaskSystem.Vehicles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SimpleTaskSystem.WebSpaAngular.Controllers
{
    public class HomeController : SimpleTaskSystemControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }

        [HttpPost]
        public ActionResult SaveTutorial(TutorialModel tutorial)
        {
            foreach (string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    var inputStream = fileContent.InputStream;
                    var fileName = Path.GetFileName(file);
                    var path = Path.Combine(Server.MapPath("~/App/Main/images"), fileName);
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        inputStream.CopyTo(fileStream);
                    }
                }
            }
            return Json(Request.Files.AllKeys[0], JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteFileFromFolder(string myTest)
        {

            string strPhysicalFolder = Server.MapPath("~/App/Main/images");
            //Request.Files

            string strFileFullPath = strPhysicalFolder + "//" + myTest;

            if (System.IO.File.Exists(strFileFullPath))
            {
                System.IO.File.Delete(strFileFullPath);
                return Json(myTest, JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.AllowGet);

        }

        public ActionResult DeleteFiles(List<String> myTest = null)
        {

            string strPhysicalFolder = Server.MapPath("~/App/Main/images");
            //Request.Files
            if(myTest != null)
            {
                foreach (var image in myTest)
                {
                    string strFileFullPath = strPhysicalFolder + "//" + image;

                    if (System.IO.File.Exists(strFileFullPath))
                    {
                        System.IO.File.Delete(strFileFullPath);
                    }
                }
            }

            return Json("success", JsonRequestBehavior.AllowGet);


        }
    }

    public class TutorialModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
    }
}