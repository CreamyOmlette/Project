namespace Domain.Entities
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int Intensity { get; set; }
        public int Time { get; set; }
        
    }
}