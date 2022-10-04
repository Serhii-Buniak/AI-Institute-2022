namespace NeuronLibrary;

public class OutputSignal
{
    private double y;
    public OutputSignal(double y, double tetta)
    {
        Y = y;
        Tetta = tetta;
    }

    public double Y
    {
        get
        {
            return y;
        }
        set
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentException($"{nameof(Y)} has to be 0<{nameof(Y)}<1", nameof(value));
            }
            y = value;
        }
    }
    public double Tetta { get; }
    public bool IsOne => Y == 1;
    public bool IsZero => Y == 0;
}