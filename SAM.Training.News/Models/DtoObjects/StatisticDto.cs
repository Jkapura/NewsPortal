using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAM.Training.News.Models.DtoObjects
{
    public class StatisticDto
    {
        public int CountArchiveNews { get; set; }

        public int CountHotNews { get; set; }
        
        public int CountTotal { get; set; }

    }
}