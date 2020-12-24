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
        * Class to represent a piano wire that implements IMusicalInstrument interface and uses a CircularArray object
        */
    public class PianoWire : IMusicalInstrument
    {
        public double frequencyNote;
        private double sampleRate;
        private int N;
        private static Random random = new Random();
        public CircularArray cirArr { get; private set; }

       /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * @Param: sampleRate, frequencyNote
        * 
        * The constructor for the PianoWire class
        */
        public PianoWire(double sampleRate, double frequencyNote)
        {
            this.sampleRate = sampleRate;
            this.frequencyNote = frequencyNote;
            this.N = (int)(Math.Round(sampleRate / frequencyNote, 0));
            this.cirArr = new CircularArray(this.N);
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        *
        * This method creates an array filled with random variables between -0.5 and 0.5. It then calls the Fill method in the CircularArray class in order to make a deep copy of it
        */
        public void Strike()
        {
            double filler;
            double[] tempArray = new double[cirArr.Length];
            for (int i = 0; i < cirArr.Length; i++)
            {
                filler = random.NextDouble () * (0.5 - (-0.5)) - 0.5;
                filler = Math.Round(filler, 1);
                tempArray[i] = filler;
            }

            cirArr.Fill(tempArray);
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * @Param: decay
        * @Return : cirArr.Shift(avg);
        * 
        * This method takes the values found in the first and second index. These values are added, divided by 2 and multiplied by the decay factor.
        * The shift method is called in order to replace it with the variable avg.
        */
        public double Sample(double decay)
        {
            double avg = (this.cirArr[0] + this.cirArr[1]);
            avg = avg / 2;
            avg = avg * decay;
            return this.cirArr.Shift(avg);
        }
    }
}
