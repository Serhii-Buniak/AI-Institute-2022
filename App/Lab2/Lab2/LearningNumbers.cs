using NeuronLearningLibrary;

namespace Lab2;

public class LearningNumber
{
    private readonly double[] _points = new double[35];

    public LearningNumber(IReadOnlyList<double> values, bool isEven)
    {
        if (_points.Length != values.Count)
        {
            throw new ArgumentException($"{nameof(values)} length not ${_points.Length}", nameof(values));
        }

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = values[i];
        }

        IsEven = isEven;
    }

    public double[] Points => _points;
    public bool IsEven { get; }

    public NeuronSeed NeuronSeed => new() { InputsValues = Points.ToList(), DesireResponse = Convert.ToDouble(IsEven) };
}
