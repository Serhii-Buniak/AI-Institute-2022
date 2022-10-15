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

    public static OutputSignal GetStepOutput(IEnumerable<InputSignal> inputSignals, double tetta = 0)
    {
        double weightedSum = GetWeightedSum(inputSignals);
        return new OutputSignal(weightedSum >= tetta ? 1 : 0);
    }

    public static OutputSignal GetSigmoidalOutput(IEnumerable<InputSignal> inputSignals)
    {
        double weightedSum = GetWeightedSum(inputSignals);
        double y = 1 / (1 + Math.Pow(Math.E, -weightedSum));

        return new OutputSignal(y);
    }

    public static double GetEpsilon(OutputSignal outputSignal, double desireResponse)
    {
        return desireResponse - outputSignal.Y;
    }

    public static double GetEpsilon2(IEnumerable<(Neuron Neuron, double desireResponse)> NeuronSeed)
    {
        double sum = 0;

        foreach (var seed in NeuronSeed)
        {
            sum += Math.Pow((seed.desireResponse - seed.Neuron.OutputSigmoidalSignal.Y), 2);
        }

        return (1 / 2) * sum;
    }

    public static double GetDelta(OutputSignal outputSignal, double desireResponse)
    {
        double y = outputSignal.Y;
        return y * (1 - y) * (desireResponse - y);
    }

    public static double GetDeltaStepOmega(OutputSignal outputSignal, InputSignal inputSignal, double desireResponse, double learnTime = 1)
    {
        return GetEpsilon(outputSignal, desireResponse) * inputSignal.X * learnTime;
    }

    public static double GetDeltaSigmoidalOmega(OutputSignal outputSignal, InputSignal inputSignal, double desireResponse, double learnTime = 1)
    {
        return GetDelta(outputSignal, desireResponse) * inputSignal.X * learnTime;
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