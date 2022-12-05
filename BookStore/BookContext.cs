using System;
using System.Collections.Generic;

namespace BookStore
{
    public class BookContext
    {

        public static List<Book> Books = new List<Book>(){

            new Book{
                Id=1,
                Title="Lord Of The Rings",
                GenreId=1,
                PageCount=1000,
                PublishDate=new DateTime(2001,06,12),
                AuthorId=1,
                
            },
             new Book{
                Id=2,
                Title="Harry Potter",
                GenreId=2,
                PageCount=780,
                PublishDate=new DateTime(2010,05,15),
                AuthorId=2,
                 
            },
             new Book{
                Id=3,
                Title="Olasiliksiz",
                GenreId=2,
                PageCount=650,
                PublishDate=new DateTime(2001,06,12),
                AuthorId =5,
            },
        };
    }
}
