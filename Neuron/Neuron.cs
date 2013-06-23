using System.Linq;

namespace Neuron
{
    public class Neuron
    {
        private readonly double _threshold;

        public Neuron(double threshold)
        {
            _threshold = threshold;
        }


        public bool Process(params Input[] inputs)
        {
            return inputs.Sum(input => input.WeightedValue) > _threshold;
            return true; //input.WeightedValue > _threshold;
        }
    }
}