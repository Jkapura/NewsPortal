using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAM.Training.News.Models.DtoObjects
{
    public class ArticleDto
    {
        public int Id { get; set; }

        public string Head{get; set;}

        public string Content{get; set;}

        public int CategoryId{get; set;}

   

        public DateTime Date { get; set; } 

        public bool IsArchive{get; set;}

        public bool HotNews{get; set;}
    }
}