namespace ExerciseTracker.Models;

internal class Running
{
    public int RunningId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public TimeSpan Duration { get; set; }
    public float Distance { get; set; }
    public string Comments { get; set; } = null!;
}
