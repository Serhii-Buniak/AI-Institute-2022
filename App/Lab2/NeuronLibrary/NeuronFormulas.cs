namespace NeuronLibrary;

public static class NeuronFormulas
{
    private static readonly Random random = new();

    public static double GetWeightedSum(IReadOnlyList<InputSignal> inputSignals, IReadOnlyList<Сoefficient> сoefficients)
    {
        if (inputSignals.Count != сoefficients.Count)
        {
            throw new ArgumentException($"{nameof(inputSignals)} and {nameof(сoefficients)} don't have same length", nameof(inputSignals));
        }

        double sum = 0;

        for (int i = 0; i < inputSignals.Count; i++)
        {
            sum += inputSignals[i].X * сoefficients[i].W;
        }

        return sum;
    }

    public static OutputSignal GetStepOutput(IReadOnlyList<InputSignal> inputSignals, IReadOnlyList<Сoefficient> сoefficients, SensitivityThreshold? threshold)
    {
        threshold ??= new SensitivityThreshold() { Tetta = 0 };
        double weightedSum = GetWeightedSum(inputSignals, сoefficients);
        return new OutputSignal(weightedSum >= threshold.Tetta ? 1 : 0);
    }

    public static OutputSignal GetSigmoidalOutput(IReadOnlyList<InputSignal> inputSignals, IReadOnlyList<Сoefficient> сoefficients)
    {
        double weightedSum = GetWeightedSum(inputSignals, сoefficients);
        double y = 1 / (1 + Math.Pow(Math.E, -weightedSum));

        return new OutputSignal(y);
    }

    public static double GetStepEtta(OutputSignal outputSignal, DesireResponse desireResponse)
    {
        return desireResponse.D - outputSignal.Y;
    }

    public static double GetSigmoidalEtta(OutputSignal outputSignal, DesireResponse desireResponse)
    {
        double sum = Math.Pow((desireResponse.D - outputSignal.Y), 2);
        return 0.5 * sum;
    }

    public static double GetSigmoidalEtta(List<OutputSignal> outputSignals, List<DesireResponse> desireResponses)
    {
        if (outputSignals.Count != desireResponses.Count)
        {
            throw new ArgumentException($"{nameof(outputSignals)} and {nameof(desireResponses)} don't have same length", nameof(desireResponses));
        }

        double sum = 0;
        for (int i = 0; i < desireResponses.Count; i++)
        {
            sum += Math.Pow((desireResponses[i].D - outputSignals[i].Y), 2);
        }

        return 0.5 * sum;
    }

    public static double GetSigmoidalEtta(List<List<OutputSignalsAndDesireResponses>> outputSignalsAndDesireResponses)
    {
        double count = 0;
        double sum = 0;
        foreach (var listQ in outputSignalsAndDesireResponses)
        {
            foreach (OutputSignalsAndDesireResponses pair in listQ)
            {
                sum += Math.Pow((pair.DesireResponse.D - pair.OutputSignal.Y), 2);
                Console.WriteLine(++count);
            }
        }

        double Q = outputSignalsAndDesireResponses.Count;
        double M = outputSignalsAndDesireResponses[0].Count;

        double QM1 = 1 / (Q * M);
        return QM1 * sum;
    }

    public static double GetDelta(OutputSignal outputSignal, DesireResponse desireResponse)
    {
        double y = outputSignal.Y;
        return y * (1 - y) * (desireResponse.D - y);
    }
    public static double GetDelta(OutputSignal outputSignal, List<Delta> deltaList, List<Сoefficient> сoefficients)
    {
        if (deltaList.Count != сoefficients.Count)
        {
            throw new ArgumentException($"{nameof(deltaList)} and {nameof(сoefficients)} don't have same length", nameof(deltaList));
        }

        double sum = 0;
        for (int i = 0; i < deltaList.Count; i++)
        {
            sum += deltaList[i].B * сoefficients[i].W;
        }

        double y = outputSignal.Y;
        return y * (1 - y) * sum;
    }

    public static double GetDeltaStepOmega(OutputSignal outputSignal, InputSignal inputSignal, DesireResponse desireResponse, double learnTime = 1)
    {
        return GetStepEtta(outputSignal, desireResponse) * inputSignal.X * learnTime;
    }

    public static double GetDeltaSigmoidalOmega(OutputSignal outputSignal, InputSignal inputSignal, DesireResponse desireResponse, double learnTime = 1)
    {
        return GetDelta(outputSignal, desireResponse) * inputSignal.X * learnTime;
    }

    public static double GetDeltaSigmoidalOmega(OutputSignal outputSignal, InputSignal inputSignal, List<Delta> deltaList, List<Сoefficient> сoefficients, double learnTime = 1)
    {
        return GetDelta(outputSignal, deltaList, сoefficients) * inputSignal.X * learnTime;
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