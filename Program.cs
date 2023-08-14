namespace LinqSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> book = new List<Book>
            {
               new Book
               {
                    Title = "Harry Potter and the sorcerrers stone",
                    Author = "J K Rowlins",
                    PublishYear = 1997,
                    Genre = "Fantasy",
               },
               new Book
               {
                   Title="To kill a Monkey Bird",
                   Author = "Harper Lee",
                   PublishYear = 1960,
                   Genre = "Fiction"
               },
               new Book
               {
                   Title= "Pride and prejudice",
                   Author = "George Owell",
                   PublishYear = 1813,
                   Genre = "Romance"
               },
               new Book
               {
                   Title = "1984",
                   Author = "George Owell",
                   PublishYear = 1949,
                   Genre = "Science Fiction"
               },
               new Book
               {
                   Title = "The great gatsby",
                   Author = "F. Scott",
                   PublishYear = 1925,
                   Genre = "Classic"
               }

               
            };

            LongestTitle();



            void DisplayTitleAfterYear()
            {
                var targetedYear = from holder in book
                                   where holder.PublishYear > 1940
                                   select holder;

                foreach (var item in targetedYear)
                {
                    Console.WriteLine($"This are the titles whose year are greater than 1940{item.Title}");
                }
            }


            void AveragePublicationYear()
            {
                var filter = book.Average(x => x.PublishYear);
                Console.WriteLine($"The average of PublicationYear is {filter}");

                //Assignment: Do every thing above without the average method;
            }

            void GroupByAuthor()
            {
                var filter = book
                    .GroupBy(books => books.Author)
                    .Select(rend => new
                    {
                        Author = rend.Key,
                        Count = rend.Count()
                    });
                foreach (var item in filter)
                {
                    Console.WriteLine($"{item.Author}: {item.Count}");
                }

            }

            void LongestTitle()
            {
                var filter = book
                    .OrderByDescending(book => book.Title.Length).First();


                Console.WriteLine($"The longest Title of the books is {filter.Title}");
            }


        }

        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int PublishYear { get; set;}
            public string Genre { get; set; }
        }
    }
}