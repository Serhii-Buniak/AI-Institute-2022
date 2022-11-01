namespace NeuronLibrary;

public class Perceptron : ICloneable
{
    public Perceptron(IEnumerable<Neuron> neurons)
    {
        Neurons = neurons.ToList();
    }

    public IReadOnlyList<Neuron> Neurons { get; }
    public IReadOnlyList<OutputSignal> OutputStepSignals => Neurons.Select(n => n.StepOutputSignal).ToList();
    public IReadOnlyList<OutputSignal> OutputSigmoidalSignals => Neurons.Select(n => n.SigmoidalOutputSignal).ToList();

    public Perceptron ChangeInputValues(IReadOnlyList<double> values)
    {
        foreach (Neuron neuron in Neurons)
        {
            neuron.ChangeInputValues(values);
        }

        return this;
    }

    public Perceptron ChangeInputValues(IReadOnlyList<InputSignal> values)
    {
        foreach (Neuron neuron in Neurons)
        {
            neuron.ChangeInputValues(values.Select(v => v.X).ToList());
        }

        return this;
    }

    public List<Delta> ChangeSigmoidalСoefficientsByDesireResponse(List<DesireResponse> desireResponses, double learnTime = 1)
    {
        if (desireResponses.Count != Neurons.Count)
        {
            throw new ArgumentException($"{nameof(desireResponses)} and {nameof(Neurons)} length don't have same length", nameof(desireResponses));
        }

        List<Delta> deltas = new();

        for (int i = 0; i < OutputSigmoidalSignals.Count; i++)
        {
            Delta delta = Neurons[i].ChangeSigmoidalСoefficientsByDesireResponse(desireResponses[i], learnTime);
            deltas.Add(delta);
        }

        return deltas;
    }

    public List<Delta> ChangeSigmoidalСoefficientsByDeltaList(List<Delta> deltaList, Perceptron perceptron, double learnTime = 1)
    {
        List<Delta> deltas = new();

        for (int i = 0; i < OutputSigmoidalSignals.Count; i++)
        {
            Delta delta = Neurons[i].ChangeSigmoidalСoefficientsByDeltaList(deltaList, perceptron.GetListOfNeuronsСoefficients(i), learnTime);
            deltas.Add(delta);
        }

        return deltas;
    }

    public List<Сoefficient> GetListOfNeuronsСoefficients(int index)
    {
        List<Сoefficient> сoefficients = Neurons.Select(n => n.SigmoidalСoefficients[index]).ToList();
        return сoefficients;
    }

    public object Clone()
    {
        return new Perceptron(Neurons.Select(n => (Neuron)n.Clone()));
    }
}
