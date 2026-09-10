using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private static readonly List<Student> students = new()
    {
        new Student { Id = 1, Name = "Ayan", Age = 20 },
        new Student { Id = 2, Name = "Dana", Age = 21 }
    };

    [HttpGet]
    public ActionResult<List<Student>> GetStudents()
    {
        return Ok(students);
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetById(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public ActionResult<Student> AddStudent(Student student)
    {
        student.Id = students.Count == 0 ? 1 : students.Max(s => s.Id) + 1;
        students.Add(student);
        return Ok(student);
    }
}

