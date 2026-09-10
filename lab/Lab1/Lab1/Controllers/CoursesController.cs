using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private static readonly List<Course> courses = new()
    {
        new Course { Id = 1, Name = "Web Services", Teacher = "Ivan Ivanov", Credits = 5 },
        new Course { Id = 2, Name = "Databases", Teacher = "Anna Petrova", Credits = 4 }
    };

    // GET /api/courses
    [HttpGet]
    public ActionResult<List<Course>> GetAll()
    {
        return Ok(courses);
    }

    // GET /api/courses/{id}
    [HttpGet("{id}")]
    public ActionResult<Course> GetById(int id)
    {
        var course = courses.FirstOrDefault(x => x.Id == id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    // POST /api/courses
    [HttpPost]
    public ActionResult<Course> Create(Course course)
    {
        course.Id = courses.Count == 0 ? 1 : courses.Max(c => c.Id) + 1;
        courses.Add(course);
        return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
    }

    // PUT /api/courses/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Course updatedCourse)
    {
        var course = courses.FirstOrDefault(x => x.Id == id);
        if (course == null)
        {
            return NotFound();
        }

        course.Name = updatedCourse.Name;
        course.Teacher = updatedCourse.Teacher;
        course.Credits = updatedCourse.Credits;

        return NoContent();
    }

    // DELETE /api/courses/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var course = courses.FirstOrDefault(x => x.Id == id);
        if (course == null)
        {
            return NotFound();
        }

        courses.Remove(course);
        return NoContent();
    }
}

