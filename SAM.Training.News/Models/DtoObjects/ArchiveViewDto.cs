using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using LINQtoCSV;
namespace SAM.Training.News.Models.DtoObjects
{
    //[CsvColumn(Name = "Article", FieldIndex = 1)]
    public class ArchiveViewDto
    {
        [CsvColumn(Name = "Id", FieldIndex = 2)]
        public int Id { get; set; }
        [CsvColumn(Name="Head", FieldIndex = 3)]
        public string Head { get; set; }
        [CsvColumn(Name = "Content", FieldIndex = 4)]
        public string Content { get; set; }
        [CsvColumn(Name = "Date", FieldIndex = 5)]
        public DateTime Date { get; set; }
        [CsvColumn(Name = "AuthorName", FieldIndex = 6)]
        public string AuthorName { get; set; }
        [CsvColumn(Name = "CategoryName", FieldIndex = 7)]
        public string CategoryName { get; set; }

        //public IEnumerator GetEnumerator()
        //{
        //    for (var i = 0; i < container.Length; i++)
        //        yield return container[i];
        //    //          return ((IEnumerable<T>) container).GetEnumerator();
        //}
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
