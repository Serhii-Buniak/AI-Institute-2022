namespace NeuronLibrary;

public class InputSignal
{
    private double x;
    public double X
    {
        get
        {
            return x;
        }
        set
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentException($"{nameof(X)} has to be 0<{nameof(X)}<1", nameof(value));
            }
            x = value;
        }
    }
    public double Omega { get; set; }
    public bool IsOne => X == 1;
    public bool IsZero => X == 0;
}