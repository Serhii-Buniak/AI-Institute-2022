using NeuronLibrary;

namespace NeuronLearningLibrary;

public class NeuronSeed
{
    public DesireResponse DesireResponse { get; set; } = null!;
    public List<InputSignal> InputsValues { get; set; } = new();
}