using NeuronLibrary;

namespace NeuronLearningLibrary;

public class NeuronTeacher
{
    private readonly Neuron _neuron;
    private readonly IReadOnlyList<NeuronSeed> _seeds;

    public NeuronTeacher(IEnumerable<NeuronSeed> seeds, IEnumerable<double> сoefficients, double tetta)
    {
        _seeds = seeds.ToList();
        var InputSignals = сoefficients.Select(cof => new InputSignal() { Omega = cof });
        _neuron = new NeuronTetta(InputSignals, tetta);
    }

    public NeuronTeacher(IEnumerable<NeuronSeed> seeds, (IEnumerable<double> other, double zero) сoefficietns)
    {
        _seeds = seeds.ToList();
        var InputSignals = сoefficietns.other.Select(cof => new InputSignal() { Omega = cof });
        _neuron = new NeuronZero(InputSignals, сoefficietns.zero);
    }

    public Action OnIteration { get; set; } = () => { };

    public Neuron Teach(double learnTime = 1)
    {
        for (int i = 0; i < _seeds.Count; i++)
        {
            OnIteration();
            bool success = RunNeuronSeed(_seeds[i], learnTime);
            if (!success)
            {
                return Teach();
            }
        }

        return _neuron;
    }

    private bool RunNeuronSeed(NeuronSeed neuronSeed, double learnTime = 1)
    {
        _neuron.ChangeInputValues(neuronSeed.InputsValues);
        Console.WriteLine(_neuron.OutputSigmoidalSignal.Y);
        if ((neuronSeed.DesireResponse -_neuron.OutputSigmoidalSignal.Y) < 0.1)
        {
            return true;
        }

        _neuron.ChangeСoefficientsByDesireResponse(neuronSeed.DesireResponse, learnTime);
        return false;
    }
}