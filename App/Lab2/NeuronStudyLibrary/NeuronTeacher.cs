using NeuronLibrary;

namespace NeuronLearningLibrary;

public class NeuronTeacher
{
    public NeuronTeacher(IEnumerable<NeuronSeed> seeds)
    {
        if (!seeds.Any())
        {
            throw new ArgumentException($"{seeds} cannot be empty", nameof(seeds));
        }

        Seeds = seeds.ToList();
    }

    public IReadOnlyList<NeuronSeed> Seeds { get; set; }
    public Action OnIteration { get; set; } = () => { };

    public Neuron TeachStep(Neuron neuron, double learnTime = 1)
    {
        for (int i = 0; i < Seeds.Count; i++)
        {
            if (neuron.InputSignals.Count != Seeds[i].InputsValues.Count)
            {
                throw new ArgumentException($"{nameof(neuron.InputSignals)} and seeds inputs length don't have same length", nameof(neuron));
            }

            OnIteration();
            bool success = RunSeedStep(neuron, Seeds[i], learnTime);
            if (!success)
            {
                return TeachStep(neuron);
            }
        }

        return neuron;
    }    
    
    public Neuron TeachSigmoidal(Neuron neuron, double learnTime = 1)
    {
        for (int i = 0; i < Seeds.Count; i++)
        {
            if (neuron.InputSignals.Count != Seeds[i].InputsValues.Count)
            {
                throw new ArgumentException($"{nameof(neuron.InputSignals)} and seeds inputs length don't have same length", nameof(neuron));
            }

            OnIteration();
            bool success = RunSeedSigmoidal(neuron, Seeds[i], learnTime);
            if (!success)
            {
                return TeachStep(neuron);
            }
        }

        return neuron;
    }

    private bool RunSeedStep(Neuron neuron, NeuronSeed neuronSeed, double learnTime = 1)
    {
        var values = neuronSeed.InputsValues.Select(sig => sig.X).ToList();
        neuron.ChangeInputValues(values);

        if (neuron.StepOutputSignal.Y == neuronSeed.DesireResponse.D)
        {
            return true;
        }

        neuron.ChangeStepСoefficientsByDesireResponse(neuronSeed.DesireResponse, learnTime);
        return false;
    }    
    
    private bool RunSeedSigmoidal(Neuron neuron, NeuronSeed neuronSeed, double learnTime = 1)
    {
        var values = neuronSeed.InputsValues.Select(sig => sig.X).ToList();
        neuron.ChangeInputValues(values);

        if ((neuronSeed.DesireResponse.D - neuron.SigmoidalOutputSignal.Y) < 0.1)
        {
            return true;
        }

        neuron.ChangeSigmoidalСoefficientsByDesireResponse(neuronSeed.DesireResponse, learnTime);
        return false;
    }
}