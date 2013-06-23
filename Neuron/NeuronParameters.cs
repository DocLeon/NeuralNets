namespace Neuron
{
    public class NeuronParameters
    {
        public double Threshold { get; set; }

        public double Weight0 { get; set; }

        public double Weight1 { get; set; }

        public double Weight2 { get; set; }

        public override string ToString()
        {
            return string.Format("[Threshold: {0}, Weight0: {1}, Weight1: {2}, Weight2: {3}", Threshold, Weight0,
                                 Weight1, Weight2);
        }
    }
}