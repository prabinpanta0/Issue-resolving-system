namespace GHM.Models
{
    
    /// Represents a module view model.
    public class ModuleViewModel
    {
        
        /// Gets or sets the module ID.
        public int Id { get; set; }

        
        /// Gets or sets the module name.
        public string Name { get; set; }
    }

    
    /// Represents a teacher view model.
    public class TeacherViewModel
    {
        
        /// Gets or sets the teacher ID.
        public int Id { get; set; }

        
        /// Gets or sets the teacher name.
        public string Name { get; set; }

        
        /// Gets or sets the module ID.
        public int ModuleId { get; set; }

        /// Gets or sets the module name
        public string Module { get; set; }
    }

    
    /// Represents a feedback question view model.
    public class FeedbackQuestionViewModel
    {
        
        /// Gets or sets the feedback question ID.
        public int Id { get; set; }

        
        /// Gets or sets the question 1.
        public string Q1 { get; set; }

        
        /// Gets or sets the question 2.
        public string Q2 { get; set; }

        
        /// Gets or sets the question 3.
        public string Q3 { get; set; }

        
        /// Gets or sets the question 4.
        public string Q4 { get; set; }
    }

    
    /// Represents a feedback view model.
    public class FeedbackViewModel
    {
        
        /// Gets or sets the feedback ID.
        public int Id { get; set; }

        
        /// Gets or sets the module ID 1.
        public int ModuleId1 { get; set; }

        
        /// Gets or sets the module ID 2.
        public int ModuleId2 { get; set; }

        
        /// Gets or sets the module ID 3.
        public int ModuleId3 { get; set; }

        
        /// Gets or sets the module name 1.
        public string Module1 { get; set; }

        
        /// Gets or sets the module name 2.
        public string Module2 { get; set; }

        
        /// Gets or sets the module name 3.
        public string Module3 { get; set; }

        
        /// Gets or sets the teacher ID.
        public int TeacherId1 { get; set; }

        
        /// Gets or sets the second teacher ID.
        public int TeacherId2 { get; set; }

        
        /// Gets or sets the third teacher ID.
        public int TeacherId3 { get; set; }

        
        /// Gets or sets the teacher name 1.
        public string Teacher1 { get; set; }

        
        /// Gets or sets the teacher name 2.
        public string Teacher2 { get; set; }

        
        /// Gets or sets the teacher name 3.
        public string Teacher3 { get; set; }

        
        /// Gets or sets the feedback question ID 1.
        public int FeedbackQuestionId1 { get; set; }

        
        /// Gets or sets the feedback question ID 2.
        public int FeedbackQuestionId2 { get; set; }

        
        /// Gets or sets the feedback question ID 3.
        public int FeedbackQuestionId3 { get; set; }

        
        /// Gets or sets the feedback question ID 4.
        public int FeedbackQuestionId4 { get; set; }

        
        /// Gets or sets the feedback question 1.
        public string FeedbackQuestion1 { get; set; }

        
        /// Gets or sets the feedback question 2.
        public string FeedbackQuestion2 { get; set; }

        
        /// Gets or sets the feedback question 3.
        public string FeedbackQuestion3 { get; set; }

        
        /// Gets or sets the feedback question 4
        public string FeedbackQuestion4 { get; set; }

        
        /// Gets or sets the answer to question 1.
        public string Answer1 { get; set; }

        
        /// Gets or sets the answer to question 2.
        public string Answer2 { get; set; }

        
        /// Gets or sets the answer to question 3.
        public string Answer3 { get; set; }

        
        /// Gets or sets the answer to question 4.
        public string Answer4 { get; set; }
        
        public List<ModuleViewModel> Modules { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
        public List<FeedbackQuestionViewModel> FeedbackQuestions { get; set; }
    }
}