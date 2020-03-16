using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Topology
    {
        public int InputCount { get; }
        public int OutpunCount { get; }
        public List<int> HiddenLayers { get; }

        public Topology(int inputCount, int outputCoutn, params int[] layers )
        {
            InputCount = inputCount;
            OutpunCount = outputCoutn;
            HiddenLayers = new List<int>();
            HiddenLayers.AddRange(layers);
        }
    }
}
