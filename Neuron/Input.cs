using System;

namespace Neuron
{
    public class Input
    {
        private readonly bool _input;
        private readonly int _weight;

        public Input(bool input, int weight)
        {
            _input = input;
            _weight = weight;
        }

        public int WeightedValue
        {
            get { return Convert.ToInt32(_input) * _weight; }
        }
    }
}