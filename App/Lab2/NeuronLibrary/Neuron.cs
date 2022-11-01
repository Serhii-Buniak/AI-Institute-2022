namespace NeuronLibrary;

public class Neuron : ICloneable
{
    private SensitivityThreshold? Threshold { get; } = null;

    public Neuron(int signalsCount)
    {
        var arr = new object[signalsCount];

        InputSignals = arr.Select(p => new InputSignal()).ToList();
        var realInputSignals = new List<InputSignal>() { new InputSignal() { X = 1 } };
        realInputSignals.AddRange(InputSignals);
        RealInputSignals = realInputSignals;

        StepСoefficients = arr.Select(p => new Сoefficient()).ToList();
        var realStepСoefficients = new List<Сoefficient>() { new Сoefficient() };
        realStepСoefficients.AddRange(StepСoefficients);
        RealStepСoefficients = realStepСoefficients;

        SigmoidalСoefficients = arr.Select(p => new Сoefficient()).ToList();
        var realSigmoidalСoefficients = new List<Сoefficient>() { new Сoefficient() };
        realSigmoidalСoefficients.AddRange(SigmoidalСoefficients);
        RealSigmoidalСoefficients = realSigmoidalСoefficients;
    }

    public Neuron(int signalsCount, SensitivityThreshold threshold)
    {
        Threshold = threshold;
        var arr = new object[signalsCount];
        InputSignals = arr.Select(p => new InputSignal()).ToList();
        RealInputSignals = InputSignals;

        StepСoefficients = arr.Select(p => new Сoefficient()).ToList();
        RealStepСoefficients = StepСoefficients;

        SigmoidalСoefficients = arr.Select(p => new Сoefficient()).ToList();
        RealSigmoidalСoefficients = SigmoidalСoefficients;
    }

    public IReadOnlyList<InputSignal> InputSignals { get; }
    public IReadOnlyList<InputSignal> RealInputSignals { get; }
    public int SignalsCount => InputSignals.Count;
    public int RealSignalsCount => RealInputSignals.Count;


    public IReadOnlyList<Сoefficient> StepСoefficients { get; }
    public IReadOnlyList<Сoefficient> RealStepСoefficients { get; }
    public OutputSignal StepOutputSignal => NeuronFormulas.GetStepOutput(RealInputSignals, RealStepСoefficients, Threshold);


    public IReadOnlyList<Сoefficient> SigmoidalСoefficients { get; }
    public IReadOnlyList<Сoefficient> RealSigmoidalСoefficients { get; }
    public OutputSignal SigmoidalOutputSignal => NeuronFormulas.GetSigmoidalOutput(RealInputSignals, RealSigmoidalСoefficients);

    public Neuron ChangeStepСoefficientsByDesireResponse(DesireResponse desireResponse, double learnTime = 1)
    {
        var outputSignal = StepOutputSignal;

        for (int i = 0; i < RealSignalsCount; i++)
        {
            RealStepСoefficients[i].W += NeuronFormulas.GetStepEtta(outputSignal, desireResponse) * RealInputSignals[i].X * learnTime;
        }

        return this;
    }

    public Delta ChangeSigmoidalСoefficientsByDesireResponse(DesireResponse desireResponse, double learnTime = 1)
    {
        var outputSignal = SigmoidalOutputSignal;
        var delta = NeuronFormulas.GetDelta(outputSignal, desireResponse);
        for (int i = 0; i < RealSignalsCount; i++)
        {
            RealSigmoidalСoefficients[i].W += NeuronFormulas.GetDeltaSigmoidalOmega(outputSignal, RealInputSignals[i], desireResponse, learnTime);
        }

        return new Delta(delta);
    }

    public Delta ChangeSigmoidalСoefficientsByDeltaList(List<Delta> deltaList, List<Сoefficient> сoefficients, double learnTime = 1)
    {
        var outputSignal = SigmoidalOutputSignal;
        var delta = NeuronFormulas.GetDelta(outputSignal, deltaList, сoefficients);

        for (int i = 0; i < RealSignalsCount; i++)
        {
            RealSigmoidalСoefficients[i].W += NeuronFormulas.GetDeltaSigmoidalOmega(outputSignal, RealInputSignals[i], deltaList, сoefficients, learnTime);
        }

        return new Delta(delta);
    }

    public Neuron IncrementStepСoefficientsByX(double learnTime = 1)
    {
        for (int i = 0; i < RealSignalsCount; i++)
        {
            RealStepСoefficients[i].W += RealInputSignals[i].X * learnTime;
        }

        return this;
    }

    public Neuron DecrementStepСoefficientsByX(double learnTime = 1)
    {
        for (int i = 0; i < RealSignalsCount; i++)
        {
            RealStepСoefficients[i].W -= RealInputSignals[i].X * learnTime;
        }

        return this;
    }

    public Neuron IncrementSigmoidalСoefficientsByX(double learnTime = 1)
    {
        for (int i = 0; i < RealSignalsCount; i++)
        {
            RealSigmoidalСoefficients[i].W += RealInputSignals[i].X * learnTime;
        }

        return this;
    }

    public Neuron DecrementSigmoidalСoefficientsByX(double learnTime = 1)
    {
        for (int i = 0; i < RealSignalsCount; i++)
        {
            RealSigmoidalСoefficients[i].W -= RealInputSignals[i].X * learnTime;
        }

        return this;
    }

    public Neuron ChangeInputValues(IReadOnlyList<double> values)
    {
        if (values.Count != SignalsCount)
        {
            throw new ArgumentException($"{nameof(InputSignals)} and {nameof(values)} don't have same length", nameof(values));
        }

        for (int i = 0; i < SignalsCount; i++)
        {
            ChangeInputValue(i, values[i]);
        }

        return this;
    }

    public Neuron ChangeInputValue(int index, double value)
    {
        InputSignals[index].X = value;
        return this;
    }

    public object Clone()
    {
        Neuron neuron;
        if (Threshold is null)
        {
            neuron = new(SignalsCount);
        }
        else
        {
            neuron = new(SignalsCount, Threshold);
        }


        for (int i = 0; i < RealSignalsCount; i++)
        {
            neuron.RealInputSignals[i].X = RealInputSignals[i].X;
            neuron.RealStepСoefficients[i].W = RealStepСoefficients[i].W;
            neuron.RealSigmoidalСoefficients[i].W = RealSigmoidalСoefficients[i].W;
        }

        return neuron;
    }
}