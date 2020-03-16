using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Layer
    {
        public List<Neuron> Neurons { get; }

        public int Count => Neurons?.Count ?? 0;

        public Layer(List<Neuron> neurons, NeuronType type=NeuronType.Normal)
        {
            if (Neurons.Count != neurons.Count) throw new System.Exception("не совпадает количество нейронов в слое");

            // TODO : проверить все входные нейроны на соотвестрвие типу;

            Neurons = neurons;
        }

        public List<double> GetSignals()
        {
            var rez = new List<double>();
            foreach(var neuron in Neurons)
            {
                rez.Add(neuron.Output);
            }
            return rez;
        }
    }
}
