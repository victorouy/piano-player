using System;
using System.Text;
using System.Collections.Generic;
using PianoPlayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PianoTests
{
    /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * Unit test of production class PianoWire
        */
    [TestClass]
    public class PianoWireTests
    {
        /*
       * @Author: Rahul Anton and Victor Ouy
       * @Date: 18/02/2020
       * 
       * 
       * Tests the constructor of the PianoWire class. Tests length
       */
        [TestMethod]
        public void ConstructorPianoWireTest()
        {
            PianoWire pianowire = new PianoWire(44100, 440);

            Assert.AreEqual(pianowire.cirArr.Length, 100, "Test failed: length should be 100");
        }

        /*
      * @Author: Rahul Anton and Victor Ouy
      * @Date: 18/02/2020
      * 
      * 
      * Tests the constructor of the PianoWire class. Tests length using different sampling rate and frequency
      */
        [TestMethod]
        public void ConstructorPianoWireTest2()
        {
            PianoWire pianowire = new PianoWire(35000, 500);

            Assert.AreEqual(pianowire.cirArr.Length, 70, "Test failed: length should be 70");
        }

        /*
      * @Author: Rahul Anton and Victor Ouy
      * @Date: 18/02/2020
      * 
      * 
      * Tests the constructor of the PianoWire class. Tests length using different sampling rate and frequency
      */
        [TestMethod]
        public void ConstructorPianoWireTest3()
        {
            PianoWire pianowire = new PianoWire(75969, 486);

            Assert.AreEqual(pianowire.cirArr.Length, 156, "Test failed: length should be 156");
        }


        /*
       * @Author: Rahul Anton and Victor Ouy
       * @Date: 18/02/2020
       * 
       * 
       * Tests the Strike method in PianoWire. Tests if CircularArray in PianoWire class truly has random values between -0.5 and 0.5
       */
        [TestMethod]
        public void StrikeTest()
        {
            PianoWire pianowire = new PianoWire(44100, 440);
            pianowire.Strike();

            for (int i = 0; i < pianowire.cirArr.Length; i++)
            {
                Assert.IsTrue((pianowire.cirArr[i] <= 0.5) && (pianowire.cirArr[i] >= -0.5), "Test failed: a random value in the circular array does not fit the range of 0.5 and -0.5" );
            }
        }

        /*
       * @Author: Rahul Anton and Victor Ouy
       * @Date: 18/02/2020
       * 
       * 
       * Tests the Strike method in PianoWire. Tests if the lenght of the CircularArray in PianoWire class is correct
       */
        [TestMethod]
        public void StrikeTest2()
        {
            PianoWire pianowire = new PianoWire(66000, 110);
            pianowire.Strike();

            Assert.AreEqual(pianowire.cirArr.Length, 600, "test failed: the length of this array should be 600");
        }


        /*
       * @Author: Rahul Anton and Victor Ouy
       * @Date: 18/02/2020
       * 
       * 
       * Tests the Sample method in PianoWire. Tests if value returned from the Sample method is equal to the calculated value
       */
        [TestMethod]
        public void SampleTest()
        {
            PianoWire pianowire = new PianoWire(44100, 440);
            pianowire.Strike();
            pianowire.cirArr[0] = 0.2;
            pianowire.cirArr[1] = 0.4;
            double removed = pianowire.Sample(0.996);

            double decayed = pianowire.cirArr[99];
            String x = decayed.ToString();

            Assert.AreEqual(removed, 0.2, "Test failed: did not properly remove the first index element");
            Assert.AreEqual(x, "0.2988", "Test failed: the decayed value does not match expected result");
        }

        /*
      * @Author: Rahul Anton and Victor Ouy
      * @Date: 18/02/2020
      * 
      * 
      * Tests the Sample method in PianoWire. Tests if value returned from the Sample method is equal to the calculated value
      */
        [TestMethod]
        public void SampleTest2()
        {
            PianoWire pianowire = new PianoWire(44100, 440);
            pianowire.Strike();
            pianowire.cirArr[0] = 0.5;
            pianowire.cirArr[1] = -0.5;
            double removed = pianowire.Sample(0.996);

            double decayed = pianowire.cirArr[99];
            String x = decayed.ToString();

            Assert.AreEqual(removed, 0.5, "Test failed: did not properly remove the first index element");
            Assert.AreEqual(x, "0", "Test failed: the decayed value does not match expected result");
        }

        /*
    * @Author: Rahul Anton and Victor Ouy
    * @Date: 18/02/2020
    * 
    * 
    * Tests the Sample method in PianoWire. Tests if value returned from the Sample method is equal to the calculated value
    */
        [TestMethod]
        public void SampleTest3()
        {
            PianoWire pianowire = new PianoWire(44100, 440);
            pianowire.Strike();
            pianowire.cirArr[0] = 0;
            pianowire.cirArr[1] = -0.5;
            double removed = pianowire.Sample(0.996);

            double decayed = pianowire.cirArr[99];
            String x = decayed.ToString();

            Assert.AreEqual(removed, 0, "Test failed: did not properly remove the first index element");
            Assert.AreEqual(x, "-0.249", "Test failed: the decayed value does not match expected result");
        }

    }
}
