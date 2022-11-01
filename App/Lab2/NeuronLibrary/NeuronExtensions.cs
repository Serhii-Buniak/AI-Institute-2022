namespace NeuronLibrary;

public static class NeuronExtensions
{
    public static IEnumerable<InputSignal> ToInputSignals(this IEnumerable<OutputSignal> outputSignals)
    {
        return outputSignals.Select(os => (InputSignal)os);
    }

    public static List<InputSignal> ToInputSignalsList(this IEnumerable<OutputSignal> outputSignals)
    {
        return ToInputSignals(outputSignals).ToList();
    }
}