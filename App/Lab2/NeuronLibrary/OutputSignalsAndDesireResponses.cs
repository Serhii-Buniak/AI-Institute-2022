namespace NeuronLibrary;

public struct OutputSignalsAndDesireResponses
{
    public OutputSignalsAndDesireResponses()
    {

    }

    public OutputSignalsAndDesireResponses(OutputSignal outputSignal, DesireResponse desireResponse) : this()
    {
        OutputSignal = outputSignal;
        DesireResponse = desireResponse;
    }

    public OutputSignal OutputSignal = null!;
    public DesireResponse DesireResponse = null!;
}
