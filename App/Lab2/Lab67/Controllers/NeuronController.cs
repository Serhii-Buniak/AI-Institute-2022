using Lab3;
using Lab67.Data;
using Lab67.Entities;
using Lab67.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeuronLearningLibrary;
using NeuronLibrary;

namespace Lab67.Controllers;

public class NeuronController : ApiControllerBase
{
    private readonly AppDbContext _context;
    private readonly NeuronService _service;

    public NeuronController(AppDbContext appDbContext, NeuronService neuronService)
    {
        _context = appDbContext;
        _service = neuronService;
    }

    [HttpPost]
    public async Task<IActionResult> Teach()
    {
        List<Seed> seeds = await _context.Seeds
            .Include(s => s.InputSignals)
            .Include(s => s.OutputSignals)
            .ToListAsync();

        List<NetworkSeed> networkSeeds = seeds
            .Select(s => new NetworkSeed()
            {
                InputsValues = s.InputSignals.Select(@is => new InputSignal(@is.Value)).ToList(),
                DesireResponses = s.OutputSignals.Select(@is => new DesireResponse(@is.Value)).ToList(),
            }).ToList();

        Perceptron perceptron1 = new(networkSeeds.Select(iv => new Neuron(networkSeeds[0].InputsValues.Count)));
        foreach (Neuron neuron in perceptron1.Neurons)
        {
            foreach (Сoefficient coefficient in neuron.RealSigmoidalСoefficients)
            {
                coefficient.W = NeuronFormulas.GetRandomСoefficient(-0.5, 0.5, 2);
            }
        }

        Perceptron perceptron2 = new(networkSeeds[0].DesireResponses.Select(iv => new Neuron(perceptron1.Neurons.Count)));
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
        NetworkTeacher networkTeacher = new(networkSeeds)
        {
            OnIteration = (etta) =>
            {
                Console.WriteLine($"Iter: {++iter}");
                Console.WriteLine(etta);
            }
        };
        networkTeacher.TeachSigmoidal(neuronNetwork);
        _service.NeuronNetwork = neuronNetwork;
        return Ok();
    }

    [HttpPut]
    public IActionResult SetInputs(List<SignalView> signalViews)
    {
        List<InputSignal> inputSignals = signalViews.Select(s => new InputSignal(s.Value)).ToList();
        _service.NeuronNetwork.ChangeInputValues(inputSignals.Select(s => s.X).ToList());

        return Ok(_service.NeuronNetwork.OutputSigmoidalSignals.Select(oss => oss.Y));
    }
}
