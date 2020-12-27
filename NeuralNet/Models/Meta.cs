using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Models
{
    public class NeuronMeta
    {
        public int Rounds { get; set; }
        public List<double> Errors { get; set; }

        public double Threshold { get; set; }
        public double Learning_Rate { get; set; }
        public int SIZE { get; set; }
        public int INPUTS_IN_SET { get; set; }
        public double Error { get; set; }
        public int BIAS { get; set; }
        public int MAX_ITERATIONS { get; set; }

        public double[] PreWeights { get; set; }
        public int[] Targets { get; set; }

        public Neuron Neuron { get; set; }
    }
}
