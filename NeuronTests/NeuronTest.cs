using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Neuron;

namespace NeuronTests
{
    [TestFixture]
    public class NeuronTest
    {
        [TestCase(true, 1, 2, false)]
        [TestCase(true, 2, 1, true)]
        [TestCase(false, 2, 1, false)]
        public void single_input_neuron(bool input, int weight, int threshold, bool expectedOutput)
        {
            var simpleNeuron = new Neuron.Neuron(threshold);
            var output = simpleNeuron.Input(new Input(input, weight));
            Assert.That(output, Is.EqualTo(expectedOutput));
        }


        
        [TestCase(true, 1, true, 1, 1, true)]
        [TestCase(true, 5, true, 100, 106, false)]
        [TestCase(true, -1, true, 1, 0, false)]
        public void dual_input_neuron(bool input1, int weight1, bool input2, int weight2, int threshold,
                                      bool expectedOutput)
        {
            var simpleNeuron = new Neuron.Neuron(threshold);
            var inputs = new[] {new Input(input1, weight1), new Input(input2, weight2)};
            var output = simpleNeuron.Input(inputs);
            Assert.That(output, Is.EqualTo(expectedOutput));
        }
    }
}
