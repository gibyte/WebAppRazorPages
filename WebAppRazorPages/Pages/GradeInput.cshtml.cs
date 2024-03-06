using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using WebAppRazorPages.Model;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Pages
{
    public class GradeInputModel : PageModel
    {
        private readonly AppDbContext _context; // Замените YourDbContext на ваш контекст базы данных
        public GradeInputModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int StudentId { get; set; }

        [BindProperty]
        public int SubjectId { get; set; }

        [BindProperty]
        [Range(1, 10, ErrorMessage = "Grade must be between 1 and 10")]
        public int Grade { get; set; }

        public List<SelectListItem> StudentOptions { get; set; }
        public List<SelectListItem> SubjectOptions { get; set; }

        public void OnGet()
        {
            // Загрузка списка студентов и предметов
            StudentOptions = _context.Students.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
            SubjectOptions = _context.SubjectGrades.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Subject.Name }).ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var student = _context.Students.FirstOrDefault(s => s.Id == StudentId);
                if (student == null) return NotFound();
                //student.SubjectGrades.Add(new SubjectGrade { Name = SubjectId, Grade = Grade });
                _context.SaveChanges();

                // Перенаправление на страницу успеха
                return RedirectToPage("/Success");
            }
            return Page();
        }
    }
}
