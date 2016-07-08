using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAM.Training.News.Models;

namespace SAM.Training.News.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        mapclassDataContext db = new mapclassDataContext();

        IEnumerable<Article> _articles { get; set; }
        IEnumerable<Article> Articles
        {
            get
            {
                if (_articles == null)
                {
                    _articles = db.Articles;
                }

                return _articles;
            }
        }

        //ArticleContext db = new ArticleContext();
        public ActionResult Index()
        {
            
               db.Articles.InsertOnSubmit(new Article()
              {
                   authorId = 1,
                  categoryId = 1,
                  head = "asd"
               });
             

              db.SubmitChanges();
                          
                ViewBag.Articles = Articles;
            
            return View();
        }

    }
}
