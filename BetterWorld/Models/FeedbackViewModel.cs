using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterWorld.Models
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        public string Program { get; set; }
        public string Intake { get; set; }
        public string Level { get; set; }
        public string Section { get; set; }
        public string Semester { get; set; }
        public string Points { get; set; }
        public string Tutor { get; set; }
        public string Module { get; set; }
        public string Misc { get; set; }

    }
    public class PaginatedFeedbackViewModel : PageModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int TotalPages => (int)Math.Ceiling(Decimal.Divide(Count, PageSize));
        public List<FeedbackViewModel> Data { get; set; }
    }
}
