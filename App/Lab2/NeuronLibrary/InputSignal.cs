namespace NeuronLibrary;

public class InputSignal : INeuronSignal
{
    public bool X { get; set; }
    public double Omega { get; set; }
    bool INeuronSignal.Value { get => X;  }
    double INeuronSignal.Сoefficient { get => Omega; }
}