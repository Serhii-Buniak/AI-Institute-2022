namespace NeuronLibrary;

public class NeuronTetta : Neuron
{
    private readonly double _tetta;

    public NeuronTetta(IEnumerable<InputSignal> inputSignals, double tetta) : base(inputSignals)
    {
        _tetta = tetta;
    }

    public override OutputSignal OutputSignal => NeuronFormulas.GetOutput(InputSignals, _tetta);

    public override Neuron ChangeInputValues(IReadOnlyList<double> values)
    {
        if (values.Count != InputSignals.Count)
        {
            throw new ArgumentException($"{nameof(InputSignals)} and {nameof(values)} don't have same length", nameof(values));
        }

        for (int i = 0; i < InputSignals.Count; i++)
        {
            ChangeInputValue(i, values[i]);
        }

        return this;
    }

    public override Neuron ChangeInputValue(int index, double value)
    {
        InputSignals[index].X = value;
        return this;
    }
}
