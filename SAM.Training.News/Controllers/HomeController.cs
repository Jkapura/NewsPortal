using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAM.Training.News.Models;
using SAM.Training.News.Models.DtoObjects;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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
            var _result = MapToDto(db.GetHotNews().ToArray().Take(10));
            var _resultLength = _result.Count;
            return Json(new { result =_result,resultLength=_resultLength}, JsonRequestBehavior.AllowGet);
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
            
            List<ArticleDto> _result = MapToDto(db.GetByCategory(categoryId).ToArray().Take(count));
            int _resultLength = _result.Count;
            return Json(new { result = _result, resultLength =_resultLength}, JsonRequestBehavior.AllowGet);
        }
        //Return sorted by Date items
        //Pattern '2016-07-20'
        public JsonResult GetByDateCategoriesNews(string categoryId, DateTime? from, DateTime? to)
        {
            List<ArticleDto> _result = new List<ArticleDto>();
            var correctCategories = ParseCategoryString(categoryId);
            if (from != null && to != null)
            {               
               _result= GetDCPack (correctCategories, (DateTime)from, (DateTime)to);
            }
            else {
                
                if (from != null)
                {
                    _result = MapToDto(db.Articles.Where(x => correctCategories.Contains(x.categoryId) && x.date >= from).Select(x => x));
                }
                   
                else {
                    
                    _result = MapToDto(db.Articles.Where(x => correctCategories.Contains(x.categoryId) && x.date <= to).Select(x => x));
                }
            }
            int _resultLength = _result.Count;
            return Json(new { result = _result, resultLength=_resultLength}, JsonRequestBehavior.AllowGet);            
        }
        
        public JsonResult GetByCategoriesNews(string categoryId)
        {            
            var correctCategories = ParseCategoryString(categoryId);
            List<ArticleDto> _result = MapToDto(db.Articles.Where(x => correctCategories.Contains(x.categoryId)).Select(x => x));            
            int _resultLength = _result.Count;
            return Json(new { result = _result, resultLength = _resultLength }, JsonRequestBehavior.AllowGet);
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
            return new JsonResult();
        }

        public JsonResult ToArchive(Article data)
        {
            Article modif = Articles.First(i => i.id.Equals(data.id));
            modif.isArchive = data.isArchive;
            db.SubmitChanges();
            return new JsonResult();
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
                if (i.content == null)
                {
                    dtoObj.Add(new ArticleDto
                    {
                        Id = i.id,
                        CategoryId = i.categoryId,
                        Head = i.head,
                        Date = (DateTime)i.date,

                    });
                }
                else{
                dtoObj.Add(new ArticleDto
                    {
                        Id = i.id,
                        CategoryId = i.categoryId,
                        Head = i.head,
                        Date = (DateTime)i.date,
                        Content= i.content
                    });
                }
            
            }
            return dtoObj;
        }
        private List<int> ParseCategoryString(string line)
        {
            var regex = new Regex("[0-9]+");
            var strCategoriesIds = "";
            var correctCategories = new List<int>();
            var regexCategories = regex.Matches(line);
            foreach (Match match in regexCategories)
            {                
                correctCategories.Add(Int32.Parse(match.Value));
                
            }
             
             strCategoriesIds = string.Join(",", correctCategories);

             return correctCategories;
        }
        private List<ArticleDto> GetDCPack(List<int> correctCategories, DateTime from, DateTime to)
        {
            List<ArticleDto> _result = new List<ArticleDto>();
            var correctFrom = Convert.ToDateTime(from.ToString("u"));
            var correctTo = Convert.ToDateTime(to.ToString("u"));
            return _result = MapToDto(db.Articles.Where(x => correctCategories.Contains(x.categoryId) && x.date >= from && x.date <= to).Select(x => x));
        }
        #endregion
    }
}
