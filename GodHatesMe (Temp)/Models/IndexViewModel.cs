namespace GodHatesMe.Models
{
    // Models/IndexViewModel.cs
    public class IndexViewModel
    {
        public List<ModuleViewModel> Modules { get; set; }
        public List<SemesterViewModel> Semesters { get; set; }
        public List<IntakeViewModel> Intakes { get; set; }
        public List<ProgramViewModel> Programs { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }

}
