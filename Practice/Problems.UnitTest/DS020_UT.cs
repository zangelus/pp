using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DataStructureAndAlgorithms;
using System.Diagnostics;

namespace Problems.UnitTest
{
    [TestFixture]
    class DS020_UT
    {
        public DS020_custom_collections problem;
        
        [SetUp]
        public void Setup()
        {
            problem = new DS020_custom_collections();
        }

        [Test] 
        public void TestIterationPattern()
        {
            People personList = new People(
                new[] 
                {
                    new Person() { Name = "Name1", ID = 1 },
                    new Person() { Name = "Name2", ID = 2 },
                    new Person() { Name = "Name3", ID = 3 },
                    new Person() { Name = "Name4", ID = 4 } 
                });

            Console.WriteLine("gi there");
            foreach (Person person in personList)
            {
                Console.WriteLine("Name: " + person.Name + " ID: " + person.ID);
            }
        }
}
