using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAM.Training.News.Models;
using SAM.Training.News.Models.DtoObjects;

namespace SAM.Training.News.Controllers
{
    public class HomeController : Controller
    {        
        mapclassDataContext db = new mapclassDataContext();        

        #region Properties
        IEnumerable<Article> _articles { get; set; }
        IEnumerable<Author> _authors { get; set; }
        IEnumerable<Category> _categories { get; set; }
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
        IEnumerable<Author> Authors
        {
            get
            {
                if (_authors == null)
                {
                    _authors = db.Authors;
                }

                return _authors;
            }
        }
        IEnumerable<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = db.Categories;
                }

                return _categories;
            }
        }
        #endregion

        #region GetSortedObjects

        
        public ActionResult Index()
        {
            ViewBag.Categories = Categories.First();
            ViewBag.Articles = db.GetHotNews().ToArray();            
            return View("Index");
        }
        //Return sorted by category
        public ActionResult GetCategory(int category)
        {
            ViewBag.category = Categories.First(i => i.id.Equals(category));

            return View("CategoryNews");
        }
        //Return single item
        public ActionResult ArticleView(int id)
        {
            ViewBag.article = Articles.First(i => i.id.Equals(id));            
            if (ViewBag.article.authorId == null)
            {
                ViewBag.article.authorId = 0;
            }
            return View("ArticleView"); 
        }
        [HttpGet]
        public JsonResult GetHotJson()
        {
            var articles = MapToDto(db.GetHotNews().ToArray().Take(10));
            return Json(articles, JsonRequestBehavior.AllowGet);
        }
        //Return Hot
        public ActionResult GetHotNews()
        {
            var pack = Categories.ToArray();
            ViewBag.Categories = pack;
            ViewBag.Articles = db.GetHotNews().ToArray();
            return View("Index");
        }
        //Hendler for ajax
        public JsonResult GetByCategoryNews(int categoryId, int count)
        {
            
            //var count2 = new Random().Next(0, 7);
            List<ArticleDto> _result = MapToDto(db.GetByCategory(categoryId).ToArray().Take(count));
            int _resultLength = _result.Count;
            return Json(new { result = _result, resultLength =_resultLength}, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult ToStatistic()
        {
            var stTotalData = db.GetTotalStatistic().ToArray().FirstOrDefault();
            var stWeekData = db.GetWeekStatistic().ToArray().FirstOrDefault();
            ViewBag.totalStatistic = new StatisticDto
            {
                CountArchiveNews = stTotalData.CountArchiveNews,
                CountHotNews = stTotalData.CountHotNews,
                CountTotal = stTotalData.CountTotal
            };
            ViewBag.weekStatistic = new StatisticDto
            {
                CountArchiveNews = stWeekData.CountArchiveNews,
                CountHotNews = stWeekData.CountHotNews,
                CountTotal = stWeekData.CountTotal
            };
            return View("ToStatistic");
        }
        #endregion

        #region ChangeBDDataMethods

        public JsonResult DeleteArticle(Article data) {
            Article delArticle = Articles.First(i => i.id.Equals(data.id));
            db.Articles.DeleteOnSubmit(delArticle);
            db.SubmitChanges();
            return Json("true"); 
        }
 
        [HttpGet]
        public JsonResult EditItem(int id)
        {
            Article item = Articles.First(i => i.id.Equals(id));
            //ViewBag.edited = item;

            var result = MapToDto(item);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ToHotItem(Article data)
        {
            Article modif = Articles.First(i => i.id.Equals(data.id));
            modif.hotNews = data.hotNews;
            db.SubmitChanges();
            return Json("true");
        }

        public JsonResult ToArchive(Article data)
        {
            Article modif = Articles.First(i => i.id.Equals(data.id));
            modif.isArchive = data.isArchive;
            db.SubmitChanges();
            return Json("true");
        }
        #endregion

        #region ConvertToDtoObject
       
        private ArticleDto MapToDto(Article item)
        {
            return new ArticleDto { 
                Id = item.id, 
                CategoryId = item.categoryId, 
                Head = item.head, 
                Content = item.content, 
                IsArchive = item.isArchive, 
                HotNews = item.hotNews 
            };
            
        }
        private StatisticDto MapStatistic(IEnumerable<int> i)
        {
            Statistics j = (Statistics)i;
            return new StatisticDto
            {
                CountArchiveNews = j.CountArchiveNews,
                CountHotNews = j.CountHotNews,
                CountTotal = j.CountTotal
            };
        }
        private List<ArticleDto> MapToDto(IEnumerable<Article> items)
        {
            List<ArticleDto> dtoObj = new List<ArticleDto>();
            foreach (var i in items)
            {
                dtoObj.Add(new ArticleDto
                {
                    Id = i.id,
                    CategoryId = i.categoryId,
                    Head = i.head,
                    
                    Date = (DateTime)i.date,

                });
            }
            return dtoObj;
        }
        #endregion
    }
}
