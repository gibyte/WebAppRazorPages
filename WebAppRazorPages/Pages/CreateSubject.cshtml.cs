using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Model;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Pages
{
    public class CreateSubjectModel : PageModel
    {
        private readonly AppDbContext _db; // Замените YourDbContext на ваш контекст базы данных

        [BindProperty]
        public List<Subject> Subjects { get; set; }

        [BindProperty]
        public Subject Subject { get; set; }
        public CreateSubjectModel(AppDbContext db)
        {
            _db = db;
            Subjects = _db.Subjects.ToList();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Проверяем, существует ли уже предмет с таким именем
            var existingSubject = _db.Subjects.FirstOrDefault(s => s.Name == Subject.Name);
            if (existingSubject != null)
            {
                ModelState.AddModelError("Subject.Name", "Предмет с таким именем уже существует.");
                return Page();
            }

            _db.Subjects.Add(Subject);
            _db.SaveChanges();
            Subjects = _db.Subjects.ToList();

            return RedirectToPage("/CreateSubject");
        }
    }
}
