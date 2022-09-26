namespace NeuronLibrary;

public class OutputSignal : INeuronSignal
{
    public OutputSignal(bool y, double tetta)
    {
        Y = y;
        Tetta = tetta;
    }

    public bool Y { get; }
    public double Tetta { get; }
    bool INeuronSignal.Value { get => Y; }
    double INeuronSignal.Сoefficient { get => Tetta; }
}