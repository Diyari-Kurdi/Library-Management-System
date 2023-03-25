using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Management_System.ViewModels.MainViewModels;

public partial class LibraryViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<BookModel>? _books;
    [ObservableProperty]
    private BookModel? _selectedBook;

    public LibraryViewModel()
    {
        GetData();
    }

    private void GetData()
    {
        //var books = await DeeSql.SelectAsync<BookModel>(CancellationToken.None);
        ObservableCollection<BookModel> books = new()
        {
            new BookModel
            {
                ID = 1,
                Title = "The Catcher in the Rye",
                Picture = @"ms-appx:///Resources/Images/The Catcher in the Rye.jpg",
                Summary = "Holden Caulfield, a teenager from New York City, struggles to find his place in the world.",
                Language = "English",
                Pages = 224,
                Author = "J.D. Salinger",
                PublicationDate = new DateTime(1951, 7, 16),
                ISBN = "9780316769488",
                Edition = "First Edition",
                Genre = "Fiction",
                Price = 9.99m
            },

            new BookModel
            {
                ID = 2,
                Title = "To Kill a Mockingbird",
                Picture = @"ms-appx:///Resources/Images/To Kill a Mockingbird.png",
                Summary = "In the Deep South, a lawyer defends a black man against an undeserved rape charge, and his kids against prejudice.",
                Language = "English",
                Pages = 281,
                Author = "Harper Lee",
                PublicationDate = new DateTime(1960, 7, 11),
                ISBN = "9780446310789",
                Edition = "50th Anniversary Edition",
                Genre = "Fiction",
                Price = 14.99m
            },

            new BookModel
            {
                ID = 3,
                Title = "1984",
                Picture = @"ms-appx:///Resources/Images/1984.jpg",
                Summary = "In a dystopian society, Winston Smith tries to rebel against the oppressive government, but finds it difficult to do so.",
                Language = "English",
                Pages = 328,
                Author = "George Orwell",
                PublicationDate = new DateTime(1949, 6, 8),
                ISBN = "9780451524935",
                Edition = "Centennial Edition",
                Genre = "Fiction",
                Price = 11.99m
            },

            new BookModel
            {
                ID = 4,
                Title = "The Great Gatsby",
                Picture = @"ms-appx:///Resources/Images/The Great Gatsby.jpg",
                Summary = "A wealthy man tries to win back his lost love, but finds that his lavish lifestyle and parties are ultimately empty.",
                Language = "English",
                Pages = 180,
                Author = "F. Scott Fitzgerald",
                PublicationDate = new DateTime(1925, 4, 10),
                ISBN = "9780743273565",
                Edition = "First Edition",
                Genre = "Fiction",
                Price = 10.99m
            },

            new BookModel
            {
                ID = 5,
                Title = "Pride and Prejudice",
                Picture = @"ms-appx:///Resources/Images/Pride and Prejudice.jpg",
                Summary = "Elizabeth Bennet and Mr. Darcy overcome their initial prejudices and fall in love in Regency-era England.",
                Language = "English",
                Pages = 279,
                Author = "Jane Austen",
                PublicationDate = new DateTime(1813, 1, 28),
                ISBN = "9780486284736",
                Edition = "Reissue Edition",
                Genre = "Fiction",
                Price = 12.99m
            },

            new BookModel
            {
                ID = 6,
                Title = "The Hobbit",
                Picture = @"ms-appx:///Resources/Images/The Hobbit.jpg",
                Summary = "Bilbo Baggins, a hobbit, sets out on a quest to help a group of dwarves reclaim their treasure from a dragon.",
                Language = "English",
                Pages = 310,
                Author = "J.R.R. Tolkien",
                PublicationDate = new DateTime(1937, 9, 21),
                ISBN = "9780261102217",
                Edition = "75th Anniversary Edition",
                Genre = "Fantasy",
                Price = 8.99m
            },

            new BookModel
            {
                ID = 7,
                Title = "Harry Potter and the Philosopher's Stone",
                Picture = @"ms-appx:///Resources/Images/Harry Potter and the Philosopher's Stone.jpg",
                Summary = "Harry Potter, a young wizard, learns about his magical heritage and attends Hogwarts School of Witchcraft and Wizardry.",
                Language = "English",
                Pages = 223,
                Author = "J.K. Rowling",
                PublicationDate = new DateTime(1997, 6, 26),
                ISBN = "9781408855652",
                Edition = "Illustrated Edition",
                Genre = "Fantasy",
                Price = 19.99m
            },

            new BookModel
            {
                ID = 8,
                Title = "The Lord of the Rings",
                Picture = @"ms-appx:///Resources/Images/The Lord of the Rings.jpg",
                Summary = "Frodo Baggins, a hobbit, sets out on a quest to destroy the One Ring and defeat the evil Sauron.",
                Language = "English",
                Pages = 1216,
                Author = "J.R.R. Tolkien",
                PublicationDate = new DateTime(1954, 7, 29),
                ISBN = "9780544003415",
                Edition = "Boxed Set Edition",
                Genre = "Fantasy",
                Price = 49.99m
            },

            new BookModel
            {
                ID = 9,
                Title = "The Hitchhiker's Guide to the Galaxy",
                Picture = @"ms-appx:///Resources/Images/The Hitchhiker's Guide to the Galaxy.jpg",
                Summary = "Arthur Dent, an ordinary man, is taken on a wild adventure through space after Earth is destroyed.",
                Language = "English",
                Pages = 224,
                Author = "Douglas Adams",
                PublicationDate = new DateTime(1979, 10, 12),
                ISBN = "9780345391803",
                Edition = "25th Anniversary Edition",
                Genre = "Science Fiction",
                Price = 7.99m
            },

            new BookModel
            {
                ID = 10,
                Title = "The Da Vinci Code",
                Picture = @"ms-appx:///Resources/Images/The Da Vinci Code.jpg",
                Summary = "Robert Langdon, a symbologist, and Sophie Neveu, a cryptologist, unravel a mystery surrounding the Holy Grail.",
                Language = "English",
                Pages = 489,
                Author = "Dan Brown",
                PublicationDate = new DateTime(2003, 3, 18),
                ISBN = "9780307474278",
                Edition = "10th Anniversary Edition",
                Genre = "Mystery",
                Price = 13.99m
            }
        };

        Books = books;
    }
}
