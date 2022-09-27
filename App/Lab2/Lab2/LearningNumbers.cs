using NeuronLearningLibrary;

namespace Lab2;

public class LearningNumber
{
    private readonly bool[] points = new bool[35];

    public LearningNumber(IReadOnlyList<bool> values, bool isEven)
    {
        if (points.Length != values.Count)
        {
            throw new ArgumentException($"{nameof(values)} length not ${points.Length}", nameof(values));
        }

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = values[i];
        }

        IsEven = isEven;
    }

    public bool[] Points => points;
    public bool IsEven { get; }

    public NeuronSeed NeuronSeed => new() { InputsValues = points.ToList(), ExpectedOutput = IsEven };
}
