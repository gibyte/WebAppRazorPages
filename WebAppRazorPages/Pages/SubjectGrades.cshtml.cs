using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Pages
{
    public class SubjectGradesModel : PageModel
    {

        private readonly AppDbContext _db; // Замените YourDbContext на ваш контекст базы данных

        public SubjectGradesModel(AppDbContext db)
        {
            _db = db;
        }

        public List<SubjectGradeViewModel> SubjectGrades { get; set; }
        public void OnGet()
        {

            SubjectGrades = _db.SubjectGrades
                .Include(s => s.Subject)
                .GroupBy(s => s.Subject.Name) // Группируем по имени предмета
                .Select(g => new SubjectGradeViewModel
                {
                    SubjectName = g.Key, // Получаем имя предмета из ключа группировки
                    AverageGrade = g.Average(s => s.Grade) // Вычисляем среднюю оценку по предмету
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
