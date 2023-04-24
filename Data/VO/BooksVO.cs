using System;

namespace AspNetRest.Data.VO
{
    public class BooksVO
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
    }
}