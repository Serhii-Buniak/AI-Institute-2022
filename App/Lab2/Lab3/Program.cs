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

Perceptron perceptron = new(learningLetters.PerceptronSeeds.Select((ps, i) => new Neuron(ps.NeuronSeeds[i].InputsValues.Count)));

perceptronTeacher.TeachStep(perceptron);
perceptronTeacher.TeachSigmoidal(perceptron);

LetterPerceptron letterPerceptron = new(
    perceptron.Neurons,
    new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }
    );

letterPerceptron.ChangeInputValues(Letters.A);

Dictionary<string, double> dict = letterPerceptron.GetSigmoidalNameValuesPairs();

foreach (var key in dict.Keys)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"{key}: {dict[key]}");
}

Dictionary<string, double> dict2 = letterPerceptron.GetStepNameValuesPairs();

foreach (var key in dict2.Keys)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"{key}: {dict2[key]}");
}