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

Perceptron perceptron1 = new(learningLetters.NetworkSeeds.Select(iv => new Neuron(learningLetters.NetworkSeeds[0].InputsValues.Count)));
foreach (Neuron neuron in perceptron1.Neurons)
{
    foreach (Сoefficient coefficient in neuron.RealSigmoidalСoefficients)
    {
        coefficient.W = NeuronFormulas.GetRandomСoefficient(-0.5, 0.5, 2);
    }
}

Perceptron perceptron2 = new(learningLetters.NetworkSeeds.Select(iv => new Neuron(perceptron1.Neurons.Count)));
foreach (Neuron neuron in perceptron2.Neurons)
{
    foreach (Сoefficient coefficient in neuron.RealSigmoidalСoefficients)
    {
        coefficient.W = NeuronFormulas.GetRandomСoefficient(-0.5, 0.5, 2);
    }
}


NeuronNetwork neuronNetwork = new(new List<Perceptron>()
{
    perceptron1,
    perceptron2
});

var iter = 0;
NetworkTeacher networkTeacher = new(learningLetters.NetworkSeeds)
{
    OnIteration = () =>
    {
        Console.WriteLine($"Iter: {++iter}");
    }
};


neuronNetwork = networkTeacher.TeachSigmoidal(neuronNetwork, 0.25);

LetterNetwork network = new(neuronNetwork.Perceptrons, new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });


Console.WriteLine();
Console.WriteLine("Letters.A");
network.ChangeInputValues(Letters.A);

Dictionary<string, double> dict = network.GetSigmoidalNameValuesPairs();

foreach (var key in dict.Keys)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"{key}: {dict[key]}");
}

Console.WriteLine();
Console.WriteLine("Letters.Fake");
network.ChangeInputValues(Letters.Fake);

 dict = network.GetSigmoidalNameValuesPairs();

foreach (var key in dict.Keys)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"{key}: {dict[key]}");
}

Console.WriteLine();
Console.WriteLine("Letters.O");
network.ChangeInputValues(Letters.O);

 dict = network.GetSigmoidalNameValuesPairs();

foreach (var key in dict.Keys)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"{key}: {dict[key]}");
}