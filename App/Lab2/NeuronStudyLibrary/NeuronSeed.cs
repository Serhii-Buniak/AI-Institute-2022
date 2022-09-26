using NeuronLibrary;

namespace NeuronLearningLibrary;

public class NeuronSeed
{
    public bool ExpectedOutput { get; set; }
    public IEnumerable<bool> InputsValues { get; set; } = Enumerable.Empty<bool>();
}

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
        

        return _neuron;
    }
}