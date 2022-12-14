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

NeuronTeacher neuronTeacher = new(seeds: neuronSeeds);

int iterNumber = 0;
neuronTeacher.OnIteration = () =>
{
    iterNumber++;
    Console.WriteLine($"Iter: {iterNumber}");
};

Neuron neuron = new(35);
neuronTeacher.TeachStep(neuron);

neuron.ChangeInputValues(Numbers.One);
if (neuron.StepOutputSignal.IsOne)
{
    Console.WriteLine("Numbers.One Even");
}
else
{
    Console.WriteLine("Numbers.One Not Even");
}

neuron.ChangeInputValues(Numbers.Two);
if (neuron.StepOutputSignal.IsOne)
{
    Console.WriteLine("Numbers.Two Even");
}
else
{
    Console.WriteLine("Numbers.Two Not Even");
}

neuron.ChangeInputValues(Numbers.Four);
if (neuron.StepOutputSignal.IsOne)
{
    Console.WriteLine("Numbers.Four Even");
}
else
{
    Console.WriteLine("Numbers.Four Not Even");
}

neuron.ChangeInputValues(Numbers.Seven);
if (neuron.StepOutputSignal.IsOne)
{
    Console.WriteLine("Numbers.Seven Even");
}
else
{
    Console.WriteLine("Numbers.Seven Not Even");
}

neuron.ChangeInputValues(Numbers.Eight);
if (neuron.StepOutputSignal.IsOne)
{
    Console.WriteLine("Numbers.Eight Even");
}
else
{
    Console.WriteLine("Numbers.Eight Not Even");
}

neuron.ChangeInputValues(Numbers.Nine);
if (neuron.StepOutputSignal.IsOne)
{
    Console.WriteLine("Numbers.Nine Even");
}
else
{
    Console.WriteLine("Numbers.Nine Not Even");
}