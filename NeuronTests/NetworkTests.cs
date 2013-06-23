using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Neuron;

namespace NeuronTests
{
    [TestFixture]
    public class NetworkTests
    {
        [Test]
        public void simple_three_neuron_network()
        {
            var neuron1 = new Neuron.Neuron(3);
            var neuron2 = new Neuron.Neuron(4);

            var neuron3 = new Neuron.Neuron(5);

            var actualOutput = neuron3.Process(
                MakeInputFrom(
                        neuron1.Process(MakeInputFrom(true, 3),
                                        MakeInputFrom(true, 5)),
                                        3)
               ,MakeInputFrom(
                        neuron2.Process(MakeInputFrom(true, 6),
                                        MakeInputFrom(false, 1)),
                                        2)
                        );

            Assert.That(actualOutput, Is.False);

        }

        [TestCase(false, false, true)]
        [TestCase(true, false, true)]
        [TestCase(false, true, true)]
        [TestCase(true, true, false)]
        public void NANDGate(bool a , bool b, bool output)
        {
            const int threshold = -2;
            var gate = new Neuron.Neuron(threshold);
            const int weightB = -1;
            const int weightA = -1;
            Assert.That(gate.Process(new Input(a, weightA),new Input(b, weightB)), Is.EqualTo(output));
        }
        

        private static Input MakeInputFrom(bool input, int weight)
        {
            return new Input(input, weight);
        }

        [TestCase(false, false, false)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(true, true, true)]
        public void ANDGate(bool a, bool b, bool output)
        {
            var neuron = new Neuron.Neuron(0);
            Assert.That(neuron.Process(new Input(a,-1),new Input(b,-1)), Is.EqualTo(output));
        }
    }
}               
