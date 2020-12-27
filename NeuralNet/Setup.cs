using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Setup
    {
        Random r = new Random();

        public double Threshold { get; set; }
        public double Learning_Rate { get; set; }
        public int SIZE { get; set; }
        public int INPUTS_IN_SET { get; set; }
        public double Error { get; set; }
        public int BIAS { get; set; }
        public int MAX_ITERATIONS { get; set; }

        public int[,] Inputs { get; set; }
        public int[] Targets { get; set; }
        public double[] Weights { get; set; }

        public Setup()
        {
            Threshold = 0.5;
            Learning_Rate = 0.00005;
            Error = 1;
            SIZE = 100;
            INPUTS_IN_SET = 3;
            BIAS = 1;
            MAX_ITERATIONS = 10000;

            CreateInputsAndTargets();

            InitializeWeights();
        }

        public void CreateInputsAndTargets()
        {
            Inputs = new int[SIZE, INPUTS_IN_SET];
            Targets = new int[SIZE];

            for(var i = 0; i < SIZE / 2; i++)
            {
                for (var j = 0; j < INPUTS_IN_SET - 1; j++)
                {
                    var input = (i + 1) * -1;
                    Inputs[i, j] = input;
                }

                Inputs[i, INPUTS_IN_SET - 1] = BIAS;

                Targets[i] = 1;
            }

            for (var i = SIZE / 2; i < SIZE; i++)
            {
                for (var j = 0; j < INPUTS_IN_SET - 1; j++)
                {
                    var input = ((i - SIZE / 2) + 1);
                    Inputs[i, j] = input;
                }

                Inputs[i, INPUTS_IN_SET - 1] = BIAS;

                Targets[i] = 0;
            }
        }

        public void InitializeWeights()
        {
            Weights = new double[INPUTS_IN_SET];
            for (var i = 0; i < INPUTS_IN_SET; i++)
            {
                var randomDouble = r.NextDouble();
                Weights[i] = randomDouble;
            }
        }
    }
}
