namespace GodHatesMe.Models
{
    public class ModuleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProgramViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SemesterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class IntakeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgramId { get; set; }
        public int IntakeId { get; set; }
        public int Level { get; set; }
        public int SemesterId { get; set; }
        public int Module1Id { get; set; }
        public int Module2Id { get; set; }
        public int Module3Id { get; set; }
        public int Module4Id { get; set; }
        public string ProgramName { get; set; }
        public string SemesterName { get; set; }
        public string IntakeName { get; set; }
        public string Module1Name { get; set; }
        public string Module2Name { get; set; }
        public string Module3Name { get; set; }
        public string Module4Name { get; set; }
    }

    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModuleName { get; set; }
        public int AverageScore { get; set; }
        public int ModuleId { get; set; }
    }

    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }
        public string Text6 { get; set; }
        public string Text7 { get; set; }
    }

    public class ScoreViewModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SectionId { get; set; }
        public int ModuleId { get; set; }
        public int ProgramId { get; set; }
        public int SemesterId { get; set; }
        public int Question1Score { get; set; }
        public int Question2Score { get; set; }
        public int Question3Score { get; set; }
        public int Question4Score { get; set; }
        public int Question5Score { get; set; }
        public int Question6Score { get; set; }
        public int Question7Score { get; set; }
        public int AverageScore { get; set; }
        public string SemesterName { get; set; }
        public string ProgramName { get; set; }
        public string ModuleName { get; set; }
        public string SectionName { get; set; }
        public string TeacherName { get; set; }
    }

}
