using System;
using PianoPlayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PianoTests
{
    /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * Unit test of production class CircularArray
        */
    [TestClass]
    public class CircularArrayTests
    {
        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the constructor in CircularArray. Tests the Length and the that the first parameter are set correctly
        */
        [TestMethod]
        public void ConstructorCircularArrayTest()
        {
            CircularArray cirArrObj = new CircularArray(10);

            Assert.AreEqual(cirArrObj.Length, 10, "Test failed: cirArrObj Length was not 10");
            Assert.AreEqual(cirArrObj.first, 0, "Test failed: cirArrObj first value was not 0");
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the argument exception thrown in Fill method
        */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void argumentExpTest()
        {
            CircularArray cirArrObj = new CircularArray(4);
            for (int i = 0; i < cirArrObj.Length; i++)
            {
                cirArrObj[i] = i;
            }

            // This array is 5 not 4
            double[] tempArray = { 4, 5, 6, 7, 5 };
            cirArrObj.Fill(tempArray);
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the argument out of range exception for the indexer in getter
        */
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void argumentOutRangeTest1()
        {
            CircularArray cirArrObj = new CircularArray(4);
            for (int i = 0; i < cirArrObj.Length; i++)
            {
                cirArrObj[i] = i;
            }
            double exception = cirArrObj[4];
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the argument out of range exception for the indexer in setter
        */
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void argumentOutRangeTest2()
        {
            CircularArray cirArrObj = new CircularArray(4);
            cirArrObj[4] = 5;
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the exception in the constructor in CircularArray that it will throw an exception if length is 1 or less
        */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void argumentExceptionLengthTest()
        {
            CircularArray cirArrObj1 = new CircularArray(1);
            CircularArray cirArrObj2 = new CircularArray(0);
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the indexer in CircularArray to see if it stores and returns it properly -- set & get
        */
        [TestMethod]
        public void indexerTest()
        {
            CircularArray cirArrObj = new CircularArray(4);
            for (int i = 0; i < cirArrObj.Length; i++)
            {
                // Tests setter
                cirArrObj[i] = i;
            }
            // Tests getter
            Assert.AreEqual(cirArrObj[3], 3, "Test failed: cirArrObj at 3 is not equals to 3");
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests that indexer returns the proper values even after first variable has changed
        * it retruns the proper values
        */
        [TestMethod]
        public void indexerTest2()
        {
            CircularArray cirArrObj = new CircularArray(4);
            for (int i = 0; i < cirArrObj.Length; i++)
            {
                cirArrObj[i] = i;
            }

            double returned;
            returned = cirArrObj.Shift(4);
            returned = cirArrObj.Shift(5);

            //[4, 5, 2, 3]
            // first index: [2]
            Assert.AreEqual(cirArrObj[0], 2, "Test failed: cirArrObj at location 0 was not euqal to 2");
            Assert.AreEqual(cirArrObj[3], 5, "Test failed: cirArrObj at location 1 was not euqal to 5");
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the shift method in CircularArray. Tests that the array shifts properly and that the first variable changes correctly
        * it retruns the proper values
        */
        [TestMethod]
        public void ShiftTest()
        {
            CircularArray cirArrObj = new CircularArray(4);
            for (int i = 0; i < cirArrObj.Length; i++)
            {
                cirArrObj[i] = i;
            }

            double returned;
            returned = cirArrObj.Shift(4);

            returned = cirArrObj.Shift(5);
            Assert.AreEqual(returned, 1, "Test failed: the returned value of removed is not equals to 1");
            Assert.AreEqual(cirArrObj.first, 2, "Test failed: updated first index variable is equal to 2");

            returned = cirArrObj.Shift(6);

            returned = cirArrObj.Shift(7);
            Assert.AreEqual(returned, 3, "Test failed: the returned value of removed is not equals to 3");
            Assert.AreEqual(cirArrObj.first, 0, "Test failed: updated first index variable is equal to 0");
        }

        /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * 
        * Tests the fill method in CircularArray. Tests if the copy array has the same address as cirArrObj
        */
        [TestMethod]
        public void fillTest()
        {
            CircularArray cirArrObj = new CircularArray(4);
            for (int i = 0; i < cirArrObj.Length; i++)
            {
                cirArrObj[i] = i;
            }
            CircularArray copy = cirArrObj;

            Assert.AreEqual(cirArrObj, copy, "Test failed: They have the same address");
        }


        /*
       * @Author: Rahul Anton and Victor Ouy
       * @Date: 18/02/2020
       * 
       * 
       * Tests the fill method in CircularArray. Tests if cirArrObj actually makes a copy of tempArray
       */
        [TestMethod]
        public void fillTest2()
        {
            CircularArray cirArrObj = new CircularArray(4);
            for (int i = 0; i < cirArrObj.Length; i++)
            {
                cirArrObj[i] = i;
            }
            double[] tempArray = { 4, 5, 6, 7 };
            cirArrObj.Fill(tempArray);

            for (int i = 0; i < cirArrObj.Length; i++)
            {
                Assert.AreEqual(cirArrObj[i], tempArray[i], "Test failed: Numbers don't match");
            }
        }
    }
}
