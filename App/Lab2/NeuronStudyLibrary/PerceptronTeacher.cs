using NeuronLibrary;

namespace NeuronLearningLibrary;

public class PerceptronTeacher
{
    public PerceptronTeacher(IReadOnlyList<PerceptronSeed> seeds)
    {
        if (!seeds.Any())
        {
            throw new ArgumentException($"{seeds} cannot be empty", nameof(seeds));
        }

        Seeds = seeds;
    }

    public IReadOnlyList<PerceptronSeed> Seeds { get; set; }
    public Action OnIteration { get; set; } = () => { };

    public Perceptron TeachStep(Perceptron perceptron, double learnTime = 1)
    {
        List<Neuron> neurons = new();

        for (int i = 0; i < perceptron.Neurons.Count; i++)
        {
            if (perceptron.Neurons.Count != Seeds[i].NeuronSeeds.Count)
            {
                throw new ArgumentException($"{nameof(perceptron.Neurons)} and seeds inputs length don't have same length", nameof(perceptron));
            }

            List<NeuronSeed> neuronSeeds = Seeds[i].NeuronSeeds;
            Neuron neuron = perceptron.Neurons[i];
            NeuronTeacher neuronTeacher = new(neuronSeeds) { OnIteration = OnIteration };
            neuronTeacher.TeachStep(neuron, learnTime);
            neurons.Add(neuron);
        }

        return new Perceptron(neurons);
    }
}