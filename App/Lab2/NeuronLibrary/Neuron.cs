namespace NeuronLibrary;

public abstract class Neuron
{
    public Neuron(IEnumerable<InputSignal> inputSignals)
    {
        InputSignals = inputSignals.ToList();
    }

    public IReadOnlyList<InputSignal> InputSignals { get; }
    public abstract OutputSignal OutputSignal { get; }

    public Neuron ChangeСoefficientsByDesireResponse(double desireResponse, double learnTime = 1)
    {
        var outputSignal = OutputSignal;
        foreach (InputSignal inputSignal in InputSignals)
        {
            inputSignal.Omega += NeuronFormulas.GetEpsilon(outputSignal, desireResponse) * inputSignal.X * learnTime;
        }

        return this;
    }

    public Neuron IncrementСoefficientsByX(double learnTime = 1)
    {
        foreach (InputSignal inputSignal in InputSignals)
        {
            inputSignal.Omega += inputSignal.X * learnTime;
        }

        return this;
    }

    public Neuron DecrementСoefficientsByX(double learnTime = 1)
    {
        foreach (InputSignal inputSignal in InputSignals)
        {
            inputSignal.Omega -= inputSignal.X * learnTime;
        }

        return this;
    }

    public abstract Neuron ChangeInputValues(IReadOnlyList<double> values);
    public abstract Neuron ChangeInputValue(int index, double value);
}