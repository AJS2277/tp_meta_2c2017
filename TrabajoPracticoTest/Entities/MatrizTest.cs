using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrabajoPractico.Entities;

namespace TrabajoPracticoTest.Entities
{
    /// <summary>
    /// Summary description for MatrizTest
    /// </summary>
    [TestClass]
    public class MatrizTest
    {
        public MatrizTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;
        private Matriz matriz = buildMatriz();

        private static Matriz buildMatriz()
        {
            var matrix = new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 },
                new int[] { 13, 14, 15, 16 },
            };

            var matriz = new Matriz(matrix);

            return matriz;
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void FitnessIsCorrect()
        {
            Assert.AreEqual(matriz.Fitness, 36);
        }

        [TestMethod]
        public void FitnessKeptAfterExchange()
        {
            var tupleExchange = new Tuple<int, int>(1, 2);
            matriz.Swap(tupleExchange);
            matriz.Swap(tupleExchange);

            Assert.AreEqual(matriz.Fitness, 36);
        }

        [TestMethod]
        public void RebuildWithoutModify()
        {
            matriz.Rebuild();

            Assert.AreEqual(matriz.Fitness, 36);
        }

        [TestMethod]
        public void RebuildModify()
        {
            var tupleExchange = new Tuple<int, int>(1, 2);
            var moves = new List<Tuple<int, int>>()
            {
                tupleExchange,
                tupleExchange
            };

            matriz.Moves = moves;
            matriz.Rebuild();

            Assert.AreEqual(matriz.Fitness, 36);
        }
    }
}
