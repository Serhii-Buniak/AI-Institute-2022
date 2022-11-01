namespace NeuronLibrary;

public class NeuronNetwork
{
    public NeuronNetwork(IEnumerable<Perceptron> perceptrons)
    {
        Perceptrons = perceptrons.ToList();
    }

    public IReadOnlyList<Perceptron> Perceptrons { get; }
    public IReadOnlyList<InputSignal> InputSignals => FirstPerceptron.Neurons[0].InputSignals;
    public Perceptron FirstPerceptron => Perceptrons[0];
    public Perceptron LastPerceptron => Perceptrons[Perceptrons.Count - 1];
    public IReadOnlyList<OutputSignal> OutputSigmoidalSignals => LastPerceptron.OutputSigmoidalSignals;
    public IReadOnlyList<OutputSignal> OutputStepSignals => LastPerceptron.OutputStepSignals;

    public NeuronNetwork ChangeInputValues(IReadOnlyList<double> values)
    {
        FirstPerceptron.ChangeInputValues(values);

        for (int i = 1; i < Perceptrons.Count; i++)
        {
            var inputSignals = Perceptrons[i - 1].OutputSigmoidalSignals.ToInputSignalsList();
            Perceptrons[i].ChangeInputValues(inputSignals);
        }

        return this;
    }

    public NeuronNetwork ChangeSigmoidalСoefficients(List<DesireResponse> desireResponses, double learnTime = 1)
    {
        Perceptron perceptron = (Perceptron)LastPerceptron.Clone();
        List<Delta> deltaList = LastPerceptron.ChangeSigmoidalСoefficientsByDesireResponse(desireResponses, learnTime);

        for (int i = Perceptrons.Count - 2; i >= 0; i--)
        {
            Perceptron tempPerceptrons = (Perceptron)Perceptrons[i].Clone();
            deltaList = Perceptrons[i].ChangeSigmoidalСoefficientsByDeltaList(deltaList, perceptron, learnTime);
            perceptron = tempPerceptrons;
        }

        return this;
    }
}