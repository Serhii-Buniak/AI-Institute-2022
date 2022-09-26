namespace NeuronLibrary;

public class Neuron
{
    private readonly double _tetta;

    public Neuron(IEnumerable<INeuronSignal> inputSignals, double tetta)
    {
        InputSignals = inputSignals
            .Select(ns => new InputSignal()
            {
                X = ns.Value,
                Omega = ns.Сoefficient
            }).ToList();
        _tetta = tetta;
    }

    public IReadOnlyList<InputSignal> InputSignals { get; set; }
    public OutputSignal OutputSignal => new(NeuronFormulas.GetOutput(InputSignals, _tetta), _tetta);

    public Neuron IncrementСoefficientsByX()
    {
        foreach (InputSignal inputSignal in InputSignals)
        {
            inputSignal.Omega += Convert.ToDouble(inputSignal.X);
        }

        return this;
    }
    public Neuron DecrementСoefficientsByX()
    {
        foreach (InputSignal inputSignal in InputSignals)
        {
            inputSignal.Omega -= Convert.ToDouble(inputSignal.X);
        }

        return this;
    }

    public static Neuron operator ++(Neuron neuron) => neuron.DecrementСoefficientsByX();
    public static Neuron operator --(Neuron neuron) => neuron.IncrementСoefficientsByX();

    public Neuron ChangeInputValues(IReadOnlyList<bool> values)
    {
        if (values.Count != InputSignals.Count)
        {
            throw new ArgumentException($"{nameof(InputSignals)} and {nameof(values)} don't have same length", nameof(values));
        }

        for (int i = 0; i < InputSignals.Count; i++)
        {
            InputSignals[i].X = values[i];
        }

        return this;
    }

    public Neuron ChangeInputValue(int index, bool value)
    {
        InputSignals[index].X = value;
        return this;
    }    
}