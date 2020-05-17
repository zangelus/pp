using DataStructureAndAlgorithms;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Problems.UnitTest
{
    //Testing tuple and its potential

    [TestFixture]
    class DS021_UT
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            (int a, string b, float c, decimal d) pack1 = (1, "two", 3.0f, 0.01m);
            
            Assert.AreEqual(1, pack1.a);
            Assert.AreEqual("two", pack1.b);
            Assert.AreEqual(3.0f, pack1.c);
            Assert.AreEqual(0.01m, pack1.d);
        }

        [Test]
        public void Test2()
        {
            (int Id, string Name) person = (12, "Name1");
            Assert.AreEqual(person, GetPerson(person));
        }

        [Test]
        public void Test3()
        {
            (int Id, string Name)[] people = 
            { 
                (1, "Name1"),
                (2, "Name2"),
                (3, "Name3"),
            };

            (int , string)[] people1 =
            {
                (1, "Name1"),
                (2, "Name2"),
                (3, "Name3"),
            };

            int i = 0;
            foreach(var p in people)
            {
                Assert.AreEqual(people[i++], p );
            }

            i = 0;
            foreach (var p in people1)
            {
                Assert.AreEqual(people1[i++], p);
            }
        }

        [Test]
        public void Test4()
        {
            (int, string)[] people =
            {
                (1, "Name1"),
                (2, "Name2"),
                (3, "Name3"),
            };

            Assert.AreEqual(people[1], PersonExist(people, Id: 2));
            Assert.AreEqual(null, PersonExist(people, Id: 4));
        }

        private class TestType
        {
            public (int,int)[] Poi { get; set; }
        }

        [Test]
        public void Test5()
        {
            var pass = new TestType()
            {
                Poi = new[] { (1, 1), (2, 2), (3, 3), (4, 4) }
            };

            (int, int)[] expected = new []{ (1, 1), (2, 2), (3, 3), (4, 4) };

            for(int i=0; i<expected.Length; i++)
            {
                Assert.AreEqual(expected[i], pass.Poi[i]);
            }
        }

        private (int Id, string Name) GetPerson((int Id, string Name) person)
        {
            return (person.Id, person.Name);
        }

        private (int Id, string Name)? PersonExist((int Id, string Name)[] people, int Id)
        {
            foreach(var p in people)
            {
                if (p.Id == Id) return p;
            }

            return null;
        }

    }
}
