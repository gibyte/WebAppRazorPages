using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Pages
{
    public class SubjectGradesModel : PageModel
    {

        private readonly AppDbContext _db; // �������� YourDbContext �� ��� �������� ���� ������

        public SubjectGradesModel(AppDbContext db)
        {
            _db = db;
        }

        public List<SubjectGradeViewModel> SubjectGrades { get; set; }
        public void OnGet()
        {

            SubjectGrades = _db.SubjectGrades
                .Include(s => s.Subject)
                .GroupBy(s => s.Subject.Name) // ���������� �� ����� ��������
                .Select(g => new SubjectGradeViewModel
                {
                    SubjectName = g.Key, // �������� ��� �������� �� ����� �����������
                    AverageGrade = g.Average(s => s.Grade) // ��������� ������� ������ �� ��������
                })
                .ToList();
        }

        public class SubjectGradeViewModel
        {
            public string SubjectName { get; set; }
            public double AverageGrade { get; set; }
        }
    }
}
