namespace task2.Models;

public class Projector : Equipment
{
    public int Brightness { get; set; }
    public int Resolution { get; set; }

    public Projector(string name, int brightness, int resolution)
        : base(name)
    {
        Brightness = brightness;
        Resolution = resolution;
    }
}