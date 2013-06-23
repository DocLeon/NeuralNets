using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Neuron;

namespace NeuronTests
{
    [TestFixture]
    public class FindDivisabilities
    {
        [TestCase(false, false, false, true)]
        [TestCase(false,false,true,false)]
        [TestCase(false, true, false, true)]
        [TestCase(false, true, true,  false)]
        [TestCase(true, false, false, true)]
        [TestCase(true, false, true,  false)]
        [TestCase(true, true, false,  true)]
        [TestCase(true, true, true, false)]
        public void FindDivisableByTwo(bool input1, bool input2, bool input3, bool threshold)
        {
            var neuronValues = new []{input1, input2, input3};
            var neuronParameters = DivisibilitySolver.FindDivisableBy(neuronValues, threshold);
            Assert.Pass("Neuron Parameters: " + neuronParameters);
        }

        
    }
}
