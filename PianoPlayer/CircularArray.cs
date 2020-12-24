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
        * Class implementing IRingBuffer simulating a circular array
        */
    public class CircularArray : IRingBuffer
    {
        private double[] arr;
        public int first { get; private set; }
        public int Length { get; private set; }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * @Param: Len
        * 
        * The constructor for the CircularArray class
        */
        public CircularArray(int Len)
        {
            if (Len <= 1)
            {
                throw new System.ArgumentException();
            }
            arr = new double[Len];
            this.Length = Len;
            this.first = 0;
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * @Return: arr[realIndex]
        * 
        * The indexer used to iterate through the double array arr
        */
        public double this[int index]
        {
            get
            {
                if (index >= arr.Length)
                {
                    throw new System.ArgumentOutOfRangeException();
                }

                int realIndex = first + index;
                if (realIndex >= this.arr.Length)
                {
                    realIndex = realIndex - this.arr.Length;
                }
                return this.arr[realIndex];
            }
            set 
            {
                if (index >= arr.Length)
                {
                    throw new System.ArgumentOutOfRangeException();
                }

                int realIndex = first + index;
                if (realIndex >= this.arr.Length)
                {
                    realIndex = realIndex - this.arr.Length;
                }
                this.arr[realIndex] = value;
            }
        }

        /*
         * @Author: Rahul Anton and Victor Ouy
         * @Date: 18/02/2020
         * @Param: value
         * @Retrun: removed
         * 
         * Method shifts the values in the double array arr and removes the first element
         */
        public double Shift(double value)
        {
            double removed = this.arr[this.first];
            this.arr[this.first] = value;
            this.first++;

            if (this.first == this.arr.Length)
            {
                this.first = 0;
            }
            return removed;
        }

        /*
         * @Author: Rahul Anton and Victor Ouy
         * @Date: 18/02/2020
         * @Param: Array
         * 
         * Makes a deep copy of the array that was given as a parameter
         */
        public void Fill(double[] Array)
        {
            if (Array.Length != arr.Length)
            {
                throw new System.ArgumentException();
            }

            for (int i = 0; i < this.arr.Length; i++)
            {
                this.arr[i] = Array[i];
            }
        }
    }
}
