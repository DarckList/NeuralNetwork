using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }

        public Neuron(int inputCount, NeuronType type=NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();

            for(int i = 0; i < inputCount; i++)
            {
                Weights.Add(1);
            }
        }

        public double FeedForward(List<double> inputs)
        {
            if (Weights.Count != inputs.Count) throw new Exception("не совпадает количество весов");

            double sum = 0.0;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }
            Output = Sigmoid(sum);
            return Output;
        }

        private double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Pow(Math.E, -x));
        }

        // thet method - to more comfortable debuging
        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
