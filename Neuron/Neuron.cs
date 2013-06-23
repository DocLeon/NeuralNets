using System.Linq;

namespace Neuron
{
    public class Neuron
    {
        private readonly int _threshold;

        public Neuron(int threshold)
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