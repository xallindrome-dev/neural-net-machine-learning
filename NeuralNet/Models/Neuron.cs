using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Neuron
    {
        public int[,] Inputs { get; set; }
        public double[] Weights { get; set; }

        public Neuron(int[,] inputs, double[] weights)
        {
            Inputs = inputs;
            Weights = weights;
        }
    }
}
