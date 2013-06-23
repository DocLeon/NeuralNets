using System;

namespace Neuron
{
    public class DivisibilitySolver
    {
        public static NeuronParameters FindDivisableBy(bool[] neuronValues, bool expectedResult)
        {
            var neuronParameters = GetRandomNeuronParameters();

            var neuronOutput = GetNeuronOutput(neuronParameters, neuronValues, expectedResult);
            var iterator = 0;
            int loopLimit = 1000000000;
            while ((neuronOutput != expectedResult) && (iterator < loopLimit))
            {
                var direction = Convert.ToInt32(expectedResult) - Convert.ToInt32(neuronOutput);
                neuronParameters = GetAdjustedWeights(neuronParameters,direction, neuronValues);
                neuronParameters.Threshold = GetAdjustedThreshold(neuronParameters.Threshold, direction);
                neuronOutput = GetNeuronOutput(neuronParameters, neuronValues, expectedResult);
                iterator++;
            }
            if (iterator == loopLimit)
                throw new Exception("I dunno wot it is.");
            neuronParameters.Attempts = iterator;
            return neuronParameters;
        }

        private static double GetAdjustedThreshold(double threshold, int direction)
        {
            const double stepsize = 0.1;
            return (threshold + stepsize)*direction;
        }

        private static NeuronParameters GetAdjustedWeights(NeuronParameters neuronParameters, int direction, bool[] neuronValues)
        {
            var stepSize = 0.1;
            return new NeuronParameters
                {
                    Weight0 = neuronParameters.Weight0 + (stepSize * direction * Convert.ToInt32(neuronValues[0])),
                    Weight1 = neuronParameters.Weight1 + (stepSize * direction * Convert.ToInt32(neuronValues[1])),
                    Weight2 = neuronParameters.Weight2+ (stepSize * direction * Convert.ToInt32(neuronValues[2])),
                    Threshold = neuronParameters.Threshold                    
                };
        }

        private static NeuronParameters GetRandomNeuronParameters()
        {
            return new NeuronParameters
                {
                    Weight0 = generateRandom(),
                    Weight1 = generateRandom(),
                    Weight2 = generateRandom(),
                    Threshold = generateRandom()
                };
        }

        private static bool GetNeuronOutput(NeuronParameters neuronParameters, bool[] neuronValues, bool expectedResult)
        {
            var neuron = new global::Neuron.Neuron(neuronParameters.Threshold);
            var output = neuron.Process(new Input(neuronValues[0], neuronParameters.Weight0),
                                        new Input(neuronValues[1], neuronParameters.Weight1),
                                        new Input(neuronValues[2], neuronParameters.Weight2));
            return output == expectedResult;
        }

        private static int generateRandom()
        {
            var randomSeed = new Random();
            return (randomSeed.Next(-50,50));
        }
    }
}