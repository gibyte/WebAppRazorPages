using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAppRazorPages.Hubs;
using WebAppRazorPages.Model;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Pages
{
    public class GradeInputModel : PageModel
    {
        private readonly AppDbContext _context; // �������� YourDbContext �� ��� �������� ���� ������
        private readonly IHubContext<ChatHub> _hubContext;
        public GradeInputModel(AppDbContext context, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        //[BindProperty]
        //public GradeInputModel GradeInput { get; set; }

        public List<Subject> Subjects { get; set; }
        [BindProperty]
        public int StudentId { get; set; }
        
        public Student Student { get; set; }

        [BindProperty] 
        public int SubjectId {  get; set; }
        [BindProperty] 
        public int Grade {  get; set; }
        [BindProperty] 
        public DateTime Date { get; set; }

        public IActionResult OnGet(int studentId)
        {
            Student = _context.Students.FirstOrDefault(x => x.Id == studentId);
            if (Student == null) { return NotFound(); }
            StudentId = studentId;
            Subjects = _context.Subjects.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // ������� �������� � ���� ������
            var student = _context.Students.FirstOrDefault(s => s.Id == StudentId);

            if (student == null)
            {
                return NotFound();
            }

            var subject = _context.Subjects.FirstOrDefault(s => s.Id == SubjectId);
            if (subject == null)
            {
                return NotFound();
            }
            // ������� ����� ������
            var newGrade = new SubjectGrade
            {
                Subject = subject,
                Grade = Grade,
                Date = Date
            };

            // ��������� ������ � ��������
            student.SubjectGrades.Add(newGrade);

            // ��������� ��������� � ���� ������
            _context.SaveChanges();

            _hubContext.Clients.All.SendAsync("UpDateSubjectGrades", StudentId, subject.Name, Grade);
            //return Page();
            return RedirectToPage("/Student", new { studentId = StudentId });
        }
    }
}
