using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Model;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Pages
{
    public class CreateSubjectModel : PageModel
    {
        private readonly AppDbContext _db; // �������� YourDbContext �� ��� �������� ���� ������

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

            // ���������, ���������� �� ��� ������� � ����� ������
            var existingSubject = _db.Subjects.FirstOrDefault(s => s.Name == Subject.Name);
            if (existingSubject != null)
            {
                ModelState.AddModelError("Subject.Name", "������� � ����� ������ ��� ����������.");
                return Page();
            }

            _db.Subjects.Add(Subject);
            _db.SaveChanges();
            Subjects = _db.Subjects.ToList();

            return RedirectToPage("/CreateSubject");
        }
    }
}
