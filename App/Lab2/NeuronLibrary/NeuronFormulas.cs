namespace NeuronLibrary;

public static class NeuronFormulas
{
    private static readonly Random random = new();

    public static double GetWeightedSum(IEnumerable<InputSignal> inputSignals)
    {
        double sum = 0;

        foreach (InputSignal signal in inputSignals)
        {
            sum += signal.X * signal.Omega;
        }

        return sum;
    }

    public static OutputSignal GetOutput(IEnumerable<InputSignal> inputSignals, double tetta = 0)
    {
        double weightedSum = GetWeightedSum(inputSignals);
        return new OutputSignal(weightedSum >= tetta ? 1 : 0, tetta) ;
    }

    public static double GetEpsilon(OutputSignal outputSignal, double desireResponse)
    {
        return desireResponse - outputSignal.Y;
    }

    public static IEnumerable<double> GetRandomСoefficients(double min, double max, int length, int numberDecimalPlaces = 0)
    {
        List<double> coefficients = new();
        for (int i = 0; i < length; i++)
        {
            double number = GetRandomСoefficient(min, max, numberDecimalPlaces);
            coefficients.Add(number);
        }
        return coefficients;
    }

    public static double GetRandomСoefficient(double min, double max, int numberDecimalPlaces = 0)
    {
        double number = random.NextDouble() * (max - min) + min;
        number = Math.Round(number, numberDecimalPlaces);
        return number;
    }
}