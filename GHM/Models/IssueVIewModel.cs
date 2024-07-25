namespace GHM.Models{
    public class IssueViewModel{
        public int Id { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string RecommendedSolution { get; set; }
        public string Status { get; set; }
        // public List<Issue> Issues { get; set; }
        // public int ResolvedIssuesCount { get; set; }
        // public int InProgressIssuesCount { get; set; }
        // public int ClosedIssuesCount { get; set; }
        // public int UnresolvedIssuesCount { get; set; }
        //public List<CategoryCountViewModel> Categories { get; set; }

    }

public class CategorySummary
{
    public string Category { get; set; }
    public int Count { get; set; }
     public int TCount { get; set; }
}

public class IssuesSummaryViewModel
{
    public int TotalIssues { get; set; }
    public int ResolvedIssuesCount { get; set; }
    public int PendingIssuesCount { get; set; }
    public int ClosedIssuesCount { get; set; }
    public List<CategorySummary> IssuesByCategory { get; set; }
}




    /// Resloved Issue View Model
    /// 
    public class ResolvedIssuesViewModel{
        public int Id { get; set; }
        public int IssueId { get; set; }
        public string Status { get; set; }
        public string IssueTitle { get; set; }


    }
}