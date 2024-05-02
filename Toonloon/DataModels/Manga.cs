using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toonloon.DataModels
{
    public class Manga
    {
        public int MangaID { get; set; }
        public string MangaTitle { get; set; }
        public string MangaDescription { get; set; }
        public string CoverURL { get; set; }
        public string Rating {  get; set; }
        public string Author { get; set; } = "Unknown";
        public string[] Chapters { get; set; }
    }

    public class Chapter
    {
        public int ChapterID { get; set; }
        public string ChapterTitle { get; set; }
        public List<string> ChapterImages { get; set; }
    }
}