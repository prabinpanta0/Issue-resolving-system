/// The View Model To show the no of teachers, modules and feedback questions, and the feedbacks
/// 
namespace GHM.Models
{
    /// Represents the index view model.
    public class IndexViewModel
    {
        
        /// Gets or sets the list of modules.
        public List<ModuleViewModel>? Modules { get; set; }

        
        /// Gets or sets the list of teachers.
        public List<TeacherViewModel>? Teachers { get; set; }

        
        /// Gets or sets the list of feedback questions.
        public List<FeedbackQuestionViewModel>? FeedbackQuestions { get; set; }

        
        /// Gets or sets the list of feedbacks.
        public List<FeedbackViewModel>? Feedbacks { get; set; }
    }
}