namespace NeuronLibrary;

public static class NeuronFormulas
{
    public static double GetWeightedSum(IEnumerable<InputSignal> inputSignals)
    {
        double sum = 0;

        foreach (InputSignal signal in inputSignals)
        {
            sum += Convert.ToDouble(signal.X) * signal.Omega;
        }

        return sum;
    }

    public static bool GetOutput(IEnumerable<InputSignal> inputSignals, double tetta)
    {
        double weightedSum = GetWeightedSum(inputSignals);
        return weightedSum >= tetta;
    }
}