using System.Collections.Generic;

namespace BookStore
{
    public class AuthorContext
    {

        public static List<Author> authorList = new List<Author>()
        {

            new Author{Id=1,Name="J.R.R" ,SurName="Tolkien"},
            new Author{Id=2,Name="J.K",SurName="Rowling"},
            new Author{Id=3,Name="Adam",SurName="Fawer"}
        };


    }
}
