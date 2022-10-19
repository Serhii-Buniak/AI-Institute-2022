using NeuronLibrary;

namespace NeuronLearningLibrary;

public class NeuronTeacher
{
    private readonly Neuron _neuron;
    private readonly IReadOnlyList<NeuronSeed> _seeds;

    public NeuronTeacher(IEnumerable<NeuronSeed> seeds)
    {
        _seeds = seeds.ToList();
        _neuron = new Neuron(_seeds.First().InputsValues.Count);
    }


    public NeuronTeacher(IEnumerable<NeuronSeed> seeds, SensitivityThreshold threshold)
    {
        _seeds = seeds.ToList();
        _neuron = new Neuron(_seeds.First().InputsValues.Count, threshold);
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
        var values = neuronSeed.InputsValues.Select(sig => sig.X).ToList();
        _neuron.ChangeInputValues(values);

        if (_neuron.StepOutputSignal.Y == neuronSeed.DesireResponse.D)
        {
            return true;
        }

        _neuron.ChangeStepСoefficientsByDesireResponse(neuronSeed.DesireResponse, learnTime);
        return false;
    }
}