namespace NeuronLibrary;

public class NeuronZero : Neuron
{
    public NeuronZero(IEnumerable<InputSignal> inputSignals, double zeroSignalCofficient) : base(GetInputSignalsWithZero(inputSignals, zeroSignalCofficient))
    {
        List<InputSignal> signals = new()
        {
            new InputSignal() { X = 1, Omega = zeroSignalCofficient }
        };
        signals.AddRange(inputSignals);
    }

    public IReadOnlyList<InputSignal> InputSignalsWithoutZero
    { 
        get
        {
            return InputSignals.Skip(1).ToList();
        }
    }

    public override OutputSignal OutputSignal => NeuronFormulas.GetOutput(InputSignals);

    public override Neuron ChangeInputValues(IReadOnlyList<double> values)
    {
        if (values.Count != InputSignalsWithoutZero.Count)
        {
            throw new ArgumentException($"{nameof(InputSignalsWithoutZero)} and {nameof(values)} don't have same length", nameof(values));
        }

        for (int i = 0; i < InputSignalsWithoutZero.Count; i++)
        {
            ChangeInputValue(i, values[i]);
        }

        return this;
    }

    public override Neuron ChangeInputValue(int index, double value)
    {
        InputSignals[index + 1].X = value;
        return this;
    }

    private static IEnumerable<InputSignal> GetInputSignalsWithZero(IEnumerable<InputSignal> inputSignals, double zeroSignalCofficient)
    {
        List<InputSignal> signals = new()
        {
            new InputSignal() { X = 1, Omega = zeroSignalCofficient }
        };
        signals.AddRange(inputSignals);
        return signals;
    }
}
