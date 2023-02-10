using System.Collections.Generic;

namespace WebApplication3
{
    public class Author
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public byte age { get; set; }
        public  List<Book>books { get; set; }



    }
}
