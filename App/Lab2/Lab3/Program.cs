using Lab3;
using NeuronLearningLibrary;
using NeuronLibrary;

LearningLetters learningLetters = new(new List<List<double>>()
{
    Letters.A,
    Letters.B,
    Letters.C,
    Letters.D,
    Letters.E,
    Letters.F,
    Letters.G,
    Letters.H,
    Letters.I,
    Letters.J,
    Letters.K,
    Letters.L,
    Letters.M,
    Letters.N,
    Letters.O,
    Letters.P,
    Letters.Q,
    Letters.R,
    Letters.S,
    Letters.T,
    Letters.U,
    Letters.V,
    Letters.W,
    Letters.X,
    Letters.Y,
    Letters.Z,
});

var iter = 0;
PerceptronTeacher perceptronTeacher = new(learningLetters.PerceptronSeeds)
{
    OnIteration = () =>
    {
        Console.WriteLine($"Iter: {++iter}");
    }
};

LetterPerceptron perceptron = new(
    perceptronTeacher.Teach().Neurons,
    new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }
    );

perceptron.ChangeInputValues(Letters.F);

Dictionary<string, double> dict = perceptron.GetNamePercentPairs();

foreach (var key in dict.Keys)
{
    Console.WriteLine($"{key}: {dict[key]}%");
}