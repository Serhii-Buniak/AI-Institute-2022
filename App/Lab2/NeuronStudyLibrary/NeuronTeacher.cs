using NeuronLibrary;

namespace NeuronLearningLibrary;

public class NeuronTeacher
{
    private readonly Neuron _neuron;
    private readonly IEnumerable<NeuronSeed> _seeds;

    public NeuronTeacher(IEnumerable<NeuronSeed> seeds, IEnumerable<double> сoefficients, double tetta)
    {
        _seeds = seeds;
        var InputSignals = сoefficients.Select(cof => new InputSignal() { Omega = cof });
        _neuron = new Neuron(InputSignals, tetta);
    }

    public Neuron Teach()
    {
        foreach (NeuronSeed seed in _seeds)
        {
            Console.WriteLine("Iteration");
            bool success = RunNeuronSeed(seed);
            if (!success)
            {
                return Teach();
            }
        }
        return _neuron;
    }

    private bool RunNeuronSeed(NeuronSeed neuronSeed)
    {
        _neuron.ChangeInputValues(neuronSeed.InputsValues);

        if (_neuron.OutputSignal.Y == neuronSeed.ExpectedOutput)
        {
            return true;
        }

        if (_neuron.OutputSignal.Y == true && neuronSeed.ExpectedOutput == false)
        {
            _neuron.DecrementСoefficientsByX();
        }
        else
        {
            _neuron.IncrementСoefficientsByX();
        }

        return false;
    }
}