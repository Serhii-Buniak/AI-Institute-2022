using NeuronLibrary;

namespace NeuronLearningLibrary;

public class NetworkTeacher
{
    public NetworkTeacher(IReadOnlyList<NetworkSeed> seeds)
    {
        if (!seeds.Any())
        {
            throw new ArgumentException($"{seeds} cannot be empty", nameof(seeds));
        }

        Seeds = seeds;
    }

    public IReadOnlyList<NetworkSeed> Seeds { get; }
    public Action OnIteration { get; set; } = () => { };

    public NeuronNetwork TeachSigmoidal(NeuronNetwork network, double learnTime = 1)
    {
        #region Validation
        if (network.InputSignals.Count != Seeds[0].InputsValues.Count)
        {
            throw new ArgumentException($"{nameof(network.InputSignals)} and seeds inputs length don't have same length", nameof(network));
        }

        if (network.LastPerceptron.Neurons.Count != Seeds[0].DesireResponses.Count)
        {
            throw new ArgumentException($"{nameof(network.InputSignals)} and seeds inputs length don't have same length", nameof(network));
        }
        #endregion

        var list = GetListOfOutputSignalsBySeeds(network);
        var etta = NeuronFormulas.GetSigmoidalEtta(list);

        while (!(etta < 0.001))
        {
            Console.WriteLine(etta);
            OnIteration();

            for (int i = 0; i < list.Count; i++)
            {
                network.ChangeInputValues(Seeds[i].InputsValues.Select(v => v.X).ToList());
                network.ChangeSigmoidalСoefficients(list[i].Select(l => l.DesireResponse).ToList(), learnTime);
            }

            list = GetListOfOutputSignalsBySeeds(network);
            etta = NeuronFormulas.GetSigmoidalEtta(list);
        }

        return network;
    }

    private List<List<OutputSignalsAndDesireResponses>> GetListOfOutputSignalsBySeeds(NeuronNetwork network)
    {
        List<List<OutputSignalsAndDesireResponses>> listOutputSignals = new();

        foreach (NetworkSeed seed in Seeds)
        {
            network.ChangeInputValues(seed.InputsValues.Select(iv => iv.X).ToList());
            listOutputSignals.Add(network.OutputSigmoidalSignals.Select((s, i) => new OutputSignalsAndDesireResponses() { OutputSignal = s, DesireResponse = seed.DesireResponses[i] }).ToList());
        }

        return listOutputSignals;
    }
}