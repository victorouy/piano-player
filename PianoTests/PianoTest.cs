using System;
using PianoPlayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PianoTests
{
    /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * Unit test of production class Piano
        */
    [TestClass]
    public class PianoTest
    {
        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the constructor for the Piano class. Checks if the length of the array matches the number of keys and that the array doesnt have any null values
        */
        
        [TestMethod]
        public void ConstructorTest()
        {
            String keys = "q2we4r5ty7u8i9op-[=zxdcfvgbnjmk,.;/' ";
            int sampleRate = 44100;

            Piano p = new Piano(keys, sampleRate);

            Assert.AreEqual(p.fn.Length, 37, "Test failed: the number of keys dont match the length of the array note frequency");


            //checks if all values in the array are doubles and not null
            for(int i = 0; i < p.fn.Length; i++)
            {
                Assert.IsTrue(p.fn[i] >= 0 || p.fn[i] <= 0);
            }
            
        }


        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the constructor for the Piano class. Checks if the length of the array matches the number of keys and that the array doesnt have any null values
        */
        [TestMethod]
        public void ConstructorTest2()
        {
            String keys = "xyz";
            int sampleRate = 44100;

            Piano p = new Piano(keys, sampleRate);

            Assert.AreEqual(p.fn.Length, 3, "Test failed: the number of keys dont match the length of the array note frequency");


            //checks if all values in the array are doubles and not null
            for (int i = 0; i < p.fn.Length; i++)
            {
                Assert.IsTrue(p.fn[i] >= 0 || p.fn[i] <= 0);
            }

        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the constructor for the Piano class. Checks that the values in the arrayare properly set
        */
        [TestMethod]
        public void ConstructorTest3()
        {
            //checks if the frequency is being calculated properly
            Piano p = new Piano("abcdef", 44100);
            double[] tests = { 110, 116.54, 123.47, 130.81, 138.59, 146.83 }; //all values calculated using a calculator

            for (int i = 0; i < p.fn.Length; i++)
            {
                Assert.AreEqual(p.fn[i], tests[i], "Test failed: frequency doesnt match");
            }
        }




        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the Play method the Piano class. Checks that the sum of the total sample is an actual number
        */
        [TestMethod]
        public void PlayTest()
        {
            Piano p = new Piano("abcd", 44100);
            for (int i = 0; i < p.keys.Length; i++)
            {
                p.StrikeKey(p.keys[i]);
            }
            
            double sum = p.Play();

            
            Assert.IsTrue(sum > 0 || sum <= 0, "Test failed: The sum is null or doesn't exist");
        }
    }
}
