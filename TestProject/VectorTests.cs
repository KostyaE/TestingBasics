using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void VectorDefaultConstructorCount0()
        {
            var vec = new Vector.Vector();
            Assert.AreEqual(vec.Count, 0);
        }

        [TestMethod,ExpectedException(typeof(ArgumentNullException))]
        public void VectorConstructorNullCollectionThrows()
        {
            var v = new Vector.Vector((int[]) null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void VectorConstructorNullOtherVectorThrows()
        {
            var v = new Vector.Vector((Vector.Vector) null);
        }

        [TestMethod]
        public void VectorConstructorSameCountTest()
        {
            var vec1 = new Vector.Vector(new[]{1, 2, 3});
            var vec2 = new Vector.Vector(vec1);
            Assert.AreEqual(vec1.Count, vec2.Count);
        }

        [TestMethod]
        public void VectorDeepCopyConstructorTest()
        {
            var v = new[]{1, 2, 3, 4};
            var vec1 = new Vector.Vector(v);
            var vec2 = new Vector.Vector(vec1);
            vec1[0]++;
            Assert.AreNotEqual(vec1[0], vec2[0]);
        }

        [TestMethod]
        public void VectorCountCorrectInitTest()
        {
            var vec = new Vector.Vector(new[] {1, 2, 3});
            Assert.AreEqual(vec.Count, 3);
        }

        [TestMethod]
        public void VectorCountCorrectAppendTest()
        {
            var vec = new Vector.Vector(new[] { 1, 2, 3 });
            vec.Append(new Vector.Vector(new[] {4, 5, 6}));
            Assert.AreEqual(vec.Count, 6);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void VectorSumLeftArgumentNullThrows()
        {
            var v2 = new Vector.Vector();
            var v3 = null + v2;
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void VectorSumRightArgumentNullThrows()
        {
            var v1 = new Vector.Vector();
            var v3 = v1 + null;
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void VectorSumDiffCountThrows()
        {
            var v1 = new Vector.Vector(new[] {1, 2, 3});
            var v2 = new Vector.Vector(new[] {1, 2});
            v1 += v2;
        }
        [TestMethod]
        public void VectorSum123And456Test()
        {
            var v1 = new Vector.Vector(new[] {1, 2, 3});
            var v2 = new Vector.Vector(new[] {4, 5, 6});
            v1 += v2;
            for (var i = 0; i < v1.Count; ++i)
                Assert.AreEqual(v1[i], v2[i]);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void VectorIpLeftArgumentNullThrows()
        {
            var v2 = new Vector.Vector();
            var k = null * v2;
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void VectorIpRightArgumentNullThrows()
        {
            var v1 = new Vector.Vector();
            var k = v1 * null;
        }

        [TestMethod,ExpectedException(typeof(ArgumentException))]
        public void VectorIpDiffCountThrows()
        {
            var v1 = new Vector.Vector(new[] { 1, 2, 3 });
            var v2 = new Vector.Vector(new[] { 1, 2 });
            var k=v1 * v2;
        }
        [TestMethod]
        public void VectorIp123And456Test()
        {
            var v1 = new Vector.Vector(new[] { 1, 2, 3 });
            var v2 = new Vector.Vector(new[] { 4, 5, 6 });
            var k = v1 * v2;
            Assert.AreEqual(k, 32);
        }

        [TestMethod]
        public void VectorDeepCopyTest()
        {
            var vec = new Vector.Vector(new[] {1, 2, 3});
            var vec2 = vec.Copy();
            vec[0]++;
            Assert.AreNotEqual(vec[0], vec2[0]);
        }
    }

    
}
