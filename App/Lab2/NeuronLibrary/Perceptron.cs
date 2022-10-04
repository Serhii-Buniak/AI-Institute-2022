namespace NeuronLibrary;

public class Perceptron
{
    public Perceptron(IEnumerable<Neuron> neurons)
    {
        Neurons = neurons.ToList();
    }

    public IReadOnlyList<Neuron> Neurons { get; }
    public IReadOnlyList<OutputSignal> OutputSignals => Neurons.Select(n => n.OutputSignal).ToList();

    public Perceptron ChangeInputValues(IReadOnlyList<double> values)
    {
        foreach (Neuron neuron in Neurons)
        {
            neuron.ChangeInputValues(values);
        }

        return this;
    }
}
