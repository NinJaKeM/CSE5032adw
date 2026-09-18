using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static List<Book> books = new()
    {
        new Book { Id = 1, Title = "Clean Code", Author = "Robert Martin", Year = 2008 },
        new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Year = 1999 }
    };

    [HttpGet]
    public ActionResult<List<Book>> GetBooks()
    {
        return Ok(books);
    }

    [HttpPost]
    public ActionResult<Book> AddBook(Book book)
    {
        book.Id = books.Count == 0 ? 1 : books.Max(b => b.Id) + 1;
        books.Add(book);
        return Ok(book);
    }
}
