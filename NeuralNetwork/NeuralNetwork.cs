using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        public Topology Topology { get; }
        public List<Layer> Layers{get;}

        public NeuralNetwork(Topology topology)
        {
            Topology = topology;
            Layers = new List<Layer>();

            CreateInputLayer();
            CreateHiddenLayer();
            CreateOutputLayer();
        }

        private void CreateInputLayer()
        {
            List<Neuron> inputNeurons = new List<Neuron>();
            for (int i = 0; i < Topology.InputCount; i++)
            {
                Neuron neuron = new Neuron(1, NeuronType.Input);
                inputNeurons.Add(neuron);
            }
            Layer inputLayr = new Layer(inputNeurons, NeuronType.Input);
            Layers.Add(inputLayr);
        }
        private void CreateHiddenLayer()
        {

            for (int i= 0; i < Topology.HiddenLayers.Count; i++)
            {
                List<Neuron> hiddenNeurons = new List<Neuron>();
                Layer lastLayers = Layers.Last();
                for (int j = 0; j < Topology.HiddenLayers[i]; j++)
                {
                    Neuron neuron = new Neuron(lastLayers.Count);
                    hiddenNeurons.Add(neuron);
                }
                Layer hiddenLayr = new Layer(hiddenNeurons);
                Layers.Add(hiddenLayr);
            }
        }
        private void CreateOutputLayer()
        {
            List<Neuron> outputNeurons = new List<Neuron>();
            Layer lastLayers = Layers.Last();
            for (int i = 0; i < Topology.OutpunCount; i++)
            {
                Neuron neuron = new Neuron(lastLayers.Count, NeuronType.Output);
                outputNeurons.Add(neuron);
            }
            Layer outputLayr = new Layer(outputNeurons, NeuronType.Output);
            Layers.Add(outputLayr);
        }

            
        public Neuron FeedForward(List<double> inputSignals)
        {
            SendSignalsToInputNeurons(inputSignals);
            SendSignalsAllLayersAfterInput();

            if (Topology.OutpunCount == 1) return Layers.Last().Neurons[0];
            else
            {
                return Layers.Last().Neurons.OrderByDescending(n => n.Output).First();
            }
        }



        private void SendSignalsToInputNeurons(List<double> inputSignals)
        {
            for (int i = 0; i < inputSignals.Count; i++)
            {
                var signal = new List<double>() { inputSignals[i] };
                var neyron = Layers[0].Neurons[i];
                neyron.FeedForward(signal);
            }
        }

        private void SendSignalsAllLayersAfterInput()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                var layer = Layers[i];
                var previousLayerSignals = Layers[i - 1].GetSignals();

                foreach (var neuron in layer.Neurons)
                {
                    neuron.FeedForward(previousLayerSignals);
                }
            }
        }
    }
}
