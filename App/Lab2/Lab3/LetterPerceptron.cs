using NeuronLibrary;

namespace Lab3;

public class LetterPerceptron : Perceptron
{
    private readonly IReadOnlyList<string> _names;

    public LetterPerceptron(IEnumerable<Neuron> neurons, IEnumerable<string> names) : base(neurons)
    {
        if (Neurons.Count != names.Count())
        {
            throw new ArgumentException($"{nameof(Neurons)} and {nameof(names)} don't have same length", nameof(names));
        }
        _names = names.ToList();
    }

    public Dictionary<string, double> GetNameValuesPairs()
    {
        IReadOnlyList<OutputSignal> signals = OutputSigmoidalSignals;
        Dictionary<string, double> keyValuePairs = new();
        for (int i = 0; i < Neurons.Count; i++)
        {
            keyValuePairs[_names[i]] = signals[i].Y;
        }

        return keyValuePairs;
    }

    public Dictionary<string, double> GetNamePercentPairs()
    {
        IReadOnlyList<OutputSignal> signals = OutputSigmoidalSignals;
        
        int oneCount = OutputSigmoidalSignals.Count(s => s.IsOne);
        double onePercent = 0;
        if (oneCount != 0)
        {
            onePercent = 100 / oneCount;
        }
        Dictionary<string, double> keyValuePairs = new();
        for (int i = 0; i < Neurons.Count; i++)
        {
            keyValuePairs[_names[i]] = (signals[i].IsOne ? onePercent : Math.Round(signals[i].Y, 2)) * 100;
        }

        return keyValuePairs;
    }
}
