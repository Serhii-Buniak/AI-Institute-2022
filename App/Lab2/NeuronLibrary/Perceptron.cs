namespace NeuronLibrary;

public class Perceptron
{
    public Perceptron(IEnumerable<Neuron> neurons)
    {
        Neurons = neurons.ToList();
    }

    public IReadOnlyList<Neuron> Neurons { get; }
    public IReadOnlyList<OutputSignal> OutputStepSignals => Neurons.Select(n => n.OutputStepSignal).ToList();
    public IReadOnlyList<OutputSignal> OutputSigmoidalSignals => Neurons.Select(n => n.OutputSigmoidalSignal).ToList();

    public Perceptron ChangeInputValues(IReadOnlyList<double> values)
    {
        foreach (Neuron neuron in Neurons)
        {
            neuron.ChangeInputValues(values);
        }

        return this;
    }
}
