using NeuronLibrary;

namespace NeuronLearningLibrary;

public class PerceptronTeacher
{
    private readonly IEnumerable<PerceptronSeed> _seeds;

    public PerceptronTeacher(IEnumerable<PerceptronSeed> seeds)
    {
        _seeds = seeds;
    }

    public Action OnIteration { get; set; } = () => { };

    public Perceptron Teach(double learnTime = 1)
    {
        List<Neuron> neurons = new();

        foreach (PerceptronSeed seed in _seeds)
        {
            List<NeuronSeed> neuronSeeds = seed.NeuronSeeds;
            NeuronTeacher neuronTeacher = new(neuronSeeds) { OnIteration = OnIteration };
            Neuron neuron = neuronTeacher.Teach(learnTime);
            neurons.Add(neuron);
        }

        return new Perceptron(neurons);
    }
}