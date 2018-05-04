using Brainence2.Models;
using Brainence2.Repositories;
using Brainence2.Utilits;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Brainence2.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Entity> linkRepo;
        public HomeController():this( MyDIContainer.GetRepository() )
        {
             
        }
        public HomeController(IRepository<Entity> repository)
        {
            linkRepo = repository;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoadFile(HttpPostedFileBase postedFile, String seekingWord )
        {

            if (postedFile != null && !String.IsNullOrEmpty(seekingWord))
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                String filePath = path + postedFile.FileName;

                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                postedFile.SaveAs(filePath);
                //read the contents of file.
                String fileData = System.IO.File.ReadAllText(filePath);

                String[] sentences = fileData.Split('.');
                // parse text and save if it fit
                linkRepo.ParseSentences(sentences, seekingWord);

            }
            else
                ModelState.AddModelError("wrongInput" ,"input data were wrong");
            return View("Index");
        }
        public ActionResult ShowSavedSentences()
        {
            var inBase = linkRepo.GetSentences();
            List<Entity> toView = new List<Entity>();
            foreach (var en in inBase)
            {
                en.Sentence = Reverse(en.Sentence);
                toView.Add(en);
            }
            return PartialView("ShowSavedSentences", toView);
        }
        private String Reverse(String input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}