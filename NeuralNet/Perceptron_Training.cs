using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Perceptron_Training
    {
        public Neuron NeuronNode { get; set; }
        public double LearningRate { get; set; }
        public int[] Targets { get; set; }
        public double[] Weights { get; set; }
        public int[,] Inputs { get; set; }

        public Perceptron_Training(Neuron neuron, double learning_rate, int[] targets)
        {
            NeuronNode = neuron;
            Weights = neuron.Weights;
            Inputs = neuron.Inputs;

            LearningRate = learning_rate;
            Targets = targets;
        }

        public double Activation(int input_index)
        {
            var activation = CalculateOutput(input_index);

            double output = activation.Key;

            double error = Targets[input_index] - output;

            CalculateWeights(error, input_index);

            return error;
        }

        public double GradientDescentActivation(int input_index)
        {
            var activation = CalculateOutput(input_index);

            double output = activation.Value;

            double error = Targets[input_index] - output;

            CalculateWeights(error, input_index);

            return 0.5 * Math.Pow(error, 2);
        }

        public KeyValuePair<int, double> CalculateOutput(int input_index)
        {
            double sum = 0;
            var inputs_in_set = Inputs.GetLength(1);

            for (int k = 0; k < inputs_in_set; k++)
            {
                sum += Weights[k] * Inputs[input_index, k];
            }

            var activation = sum >= 0 ? 1 : 0;

            return new KeyValuePair<int, double>(activation, sum);
        }

        public void CalculateWeights(double error, int input_index)
        {
            var inputs_in_set = Inputs.GetLength(1);

            for (int j = 0; j < inputs_in_set; j++)
            {
                Weights[j] += LearningRate * error * Inputs[input_index, j];
            }
        }
    }
}
