using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeuralNetwork;
using NeuralNetwork.Models;

namespace MachineLearningAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<NeuronMeta> Get()
        {
            Setup s = new Setup();

            NeuronMeta nm = new NeuronMeta();

            Neuron neuron = new Neuron(s.Inputs, s.Weights);

            nm.PreWeights = new double[s.Weights.Length];
            Array.Copy(s.Weights, nm.PreWeights, s.Weights.Length);
            nm.Learning_Rate = s.Learning_Rate;
            nm.Threshold = s.Threshold;
            nm.SIZE = s.SIZE;
            nm.INPUTS_IN_SET = s.INPUTS_IN_SET;
            nm.Error = s.Error;
            nm.BIAS = s.BIAS;
            nm.Targets = s.Targets;
            nm.Errors = new List<double>();
            nm.MAX_ITERATIONS = s.MAX_ITERATIONS;

            Perceptron_Training pt = new Perceptron_Training(neuron, s.Learning_Rate, s.Targets);

            while (s.Error > s.Threshold && s.MAX_ITERATIONS > nm.Rounds)
            {
                s.Error = 0;
                for (var input_index = 0; input_index < s.SIZE; input_index++)
                {
                    var error = pt.GradientDescentActivation(input_index);

                    //s.Error += Math.Abs(error);
                    s.Error += error;
                }
                nm.Rounds++;
                var newError = Math.Round(s.Error, 6);
                if(!nm.Errors.Where(a => Math.Round(a, 6) == newError).Any())
                {
                    nm.Errors.Add(newError);
                }
            }

            nm.Neuron = neuron;

            return new NeuronMeta[] { nm };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
