﻿using NeuronLearningLibrary;

namespace Lab3;

public class LearningLetters
{
    private readonly List<List<double>> _letters;

    public LearningLetters(IEnumerable<IEnumerable<double>> letters)
    {
        _letters = letters.Select(l => l.ToList()).ToList();
    }

    public List<PerceptronSeed> PerceptronSeeds
    {
        get
        {
            List<PerceptronSeed> perceptronSeeds = new();
            var length = _letters.Count;
            for (int i = 0; i < length; i++)
            {
                PerceptronSeed perceptronSeed = new();

                for (int j = 0; j < length; j++)
                {
                    var neuronSeed = new NeuronSeed()
                    {
                        InputsValues = _letters[j],
                        DesireResponse = Convert.ToDouble(i == j)
                    };  

                    perceptronSeed.NeuronSeeds.Add(neuronSeed);
                }
                perceptronSeeds.Add(perceptronSeed);
            }

            return perceptronSeeds;
        }
    }
}