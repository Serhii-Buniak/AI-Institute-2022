using Lab2;
using NeuronLearningLibrary;
using NeuronLibrary;

IEnumerable<NeuronSeed> neuronSeeds = new List<NeuronSeed>()
{
    new LearningNumber(Numbers.One,     isEven: false ).NeuronSeed,
    new LearningNumber(Numbers.Two,     isEven: true ).NeuronSeed,
    new LearningNumber(Numbers.Three,   isEven: false ).NeuronSeed,
    new LearningNumber(Numbers.Four,    isEven: true ).NeuronSeed,
    new LearningNumber(Numbers.Five,    isEven: false ).NeuronSeed,
    new LearningNumber(Numbers.Six,     isEven: true ).NeuronSeed,
    new LearningNumber(Numbers.Seven,   isEven: false ).NeuronSeed,
    new LearningNumber(Numbers.Eight,   isEven: true ).NeuronSeed,
    new LearningNumber(Numbers.Nine,    isEven: false ).NeuronSeed,
};

NeuronTeacher neuronTeacher = new(
    seeds: neuronSeeds,
    сoefficients: new List<double>()
    {
        2, 4, 5, 1, 2, 
        -1, 6, 5, 3, 5,
        6, 4, 0, 0, 3,
        5, 1, 31, 1, 1,
        3, 0, 215, 0, 1,
        1, 4, 0, 6, 1,
        1, 2, 1, 1, 5,
    },
    tetta: 0);

Neuron neuron = neuronTeacher.Teach();

neuron.ChangeInputValues(Numbers.One);
if (neuron.OutputSignal.Y)
{
    Console.WriteLine("Numbers.One Even");
}
else
{
    Console.WriteLine("Numbers.One Not Even");
}

neuron.ChangeInputValues(Numbers.Three);
if (neuron.OutputSignal.Y)
{
    Console.WriteLine("Numbers.Three Even");
}
else
{
    Console.WriteLine("Numbers.Three Not Even");
}

neuron.ChangeInputValues(Numbers.Four);
if (neuron.OutputSignal.Y)
{
    Console.WriteLine("Numbers.Four Even");
}
else
{
    Console.WriteLine("Numbers.Four Not Even");
}

neuron.ChangeInputValues(Numbers.Seven);
if (neuron.OutputSignal.Y)
{
    Console.WriteLine("Numbers.Seven Even");
}
else
{
    Console.WriteLine("Numbers.Seven Not Even");
}

neuron.ChangeInputValues(Numbers.Eight);
if (neuron.OutputSignal.Y)
{
    Console.WriteLine("Numbers.Eight Even");
}
else
{
    Console.WriteLine("Numbers.Eight Not Even");
}

neuron.ChangeInputValues(Numbers.Nine);
if (neuron.OutputSignal.Y)
{
    Console.WriteLine("Numbers.Nine Even");
}
else
{
    Console.WriteLine("Numbers.Nine Not Even");
}