using System;

namespace Neuron
{
    public class Input
    {
        private readonly bool _input;
        private readonly double _weight;

        public Input(bool input, double weight)
        {
            _input = input;
            _weight = weight;
        }

        public double WeightedValue
        {
            get { return Convert.ToInt32(_input) * _weight; }
        }
    }
}