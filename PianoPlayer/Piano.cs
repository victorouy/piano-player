using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoPlayer
{
    /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * Class to simulate a piano that holds a List of the IMusicalInstrument interface to get the piano wires
        */
    public class Piano
    {
        public string keys;
        public int samplingRate;
        public double[] fn;
        public List<IMusicalInstrument> wires;

        /*
         * @Author: Rahul Anton and Victor Ouy
         * @Date: 18/02/2020
         * @Param: keys, samplingRate
         * 
         * 
         * The constructor for the Piano class
         */
        public Piano(string keys, int samplingRate)
        {
            this.keys = keys;
            this.samplingRate = samplingRate;
            fn = new double[keys.Length];
            this.wires = new List<IMusicalInstrument>();

            for (int i = 0; i < fn.Length; i++)
            {
                this.fn[i] = findFrequency(i);
                wires.Add(new PianoWire(this.samplingRate, this.fn[i]));
            }
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * @Param: index
        * 
        * A helper method that is used by the constructor in order to find the frequency
        */
        private double findFrequency(int index)
        {
            double exp = (index - 24);
            exp = exp / 12;
            double frequency = Math.Pow(2, exp);
            frequency = frequency * 440;
            frequency = Math.Round(frequency, 2);
            return frequency;
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * @Param: key
        * 
        * This method uses the strike method in the PianoWire  class on the char provided as a param
        */
        public void StrikeKey(char key)
        {
            int index = this.keys.IndexOf(key);
            try
            {
                wires[index].Strike();
            }
            catch (Exception e)
            {
            }
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * @Return: sum
        * 
        * Returns the sum of all the samples of the wires in the PianoWire array.
        */
        public double Play()
        {
            double sum = 0;
            double sampleReturn;

            // for (int i = 0; i < wires.Length; i++)
            for (int i = 0; i < wires.Count; i++)
            {
                sampleReturn = this.wires[i].Sample(0.996);
                sum += sampleReturn;
            }
            return sum;
        }
    }
}