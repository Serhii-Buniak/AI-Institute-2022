using NeuronLibrary;

namespace NeuronLearningLibrary;

public class NetworkSeed
{
    public List<InputSignal> InputsValues { get; set; } = new();
    public List<DesireResponse> DesireResponses { get; set; } = new();
}