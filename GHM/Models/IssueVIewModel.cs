namespace GHM.Models{
    public class IssueViewModel{
        public int Id { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string RecommendedSolution { get; set; }
        public string Status { get; set; }

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