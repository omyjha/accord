﻿// Accord Unit Tests
// The Accord.NET Framework
// http://accord.googlecode.com
//
// Copyright © César Souza, 2009-2012
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//



namespace Accord.Tests.Statistics
{
    using Accord.Statistics.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data;

    [TestClass()]
    public class NormalizationFilterTest
    {


        private TestContext testContextInstance;

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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void ApplyTest()
        {
            DataTable input = new DataTable("Sample data");
            input.Columns.Add("x", typeof(double));
            input.Columns.Add("y", typeof(double));
            input.Rows.Add(0.0, 0);
            input.Rows.Add(0.2, -20);
            input.Rows.Add(0.8, -80);
            input.Rows.Add(1.0, -100);

            DataTable expected = new DataTable("Sample data");
            expected.Columns.Add("x", typeof(double));
            expected.Columns.Add("y", typeof(double));
            expected.Rows.Add(-1.0502, 1.0502);
            expected.Rows.Add(-0.6301, 0.6301);
            expected.Rows.Add(0.6301, -0.6301);
            expected.Rows.Add(1.0502, -1.0502);



            Normalization target = new Normalization("x", "y");

            target.Detect(input);

            DataTable actual = target.Apply(input);

            for (int i = 0; i < actual.Rows.Count; i++)
            {
                double ex = (double)expected.Rows[i][0];
                double ey = (double)expected.Rows[i][1];

                double ax = (double)actual.Rows[i][0];
                double ay = (double)actual.Rows[i][1];

                Assert.AreEqual(ex, ax, 0.001);
                Assert.AreEqual(ey, ay, 0.001);

            }
        }

        [TestMethod()]
        public void ApplyTest2()
        {
            string colName = "(test ['a'])";

            DataTable input = new DataTable("Sample data");
            input.Columns.Add(colName, typeof(double));
            input.Rows.Add(-2);
            input.Rows.Add(-1);
            input.Rows.Add(0);
            input.Rows.Add(1);
            input.Rows.Add(2);

            DataTable expected = new DataTable("Sample data");
            expected.Columns.Add(colName, typeof(double));
            expected.Rows.Add(-1.2649110640673518);
            expected.Rows.Add(-0.63245553203367588);
            expected.Rows.Add(0);
            expected.Rows.Add(0.63245553203367588);
            expected.Rows.Add(1.2649110640673518);



            Normalization target = new Normalization(colName);

            target.Detect(input);

            DataTable actual = target.Apply(input);

            for (int i = 0; i < actual.Rows.Count; i++)
            {
                double ex = (double)expected.Rows[i][0];

                double ax = (double)actual.Rows[i][0];

                Assert.AreEqual(ex, ax, 0.001);

            }
        }

    }
}
