using NeuronLibrary;

namespace NeuronLearningLibrary;

public class PerceptronTeacher
{
    private readonly IEnumerable<PerceptronSeed> _seeds;

    public PerceptronTeacher(IEnumerable<PerceptronSeed> seeds)
    {
        _seeds = seeds;
    }

    public Perceptron Teach(double learnTime = 1)
    {
        List<Neuron> neurons = new();

        foreach (PerceptronSeed seed in _seeds)
        {
            List<NeuronSeed> neuronSeeds = seed.NeuronSeeds;
            NeuronTeacher neuronTeacher = new(neuronSeeds, (neuronSeeds.Select((ns) => 0.0), 0));
            Neuron neuron = neuronTeacher.Teach(learnTime);
            neurons.Add(neuron);
        }

        return new Perceptron(neurons);
    }
}