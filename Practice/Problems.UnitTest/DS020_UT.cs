using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DataStructureAndAlgorithms;
using System.Diagnostics;
using System.Resources;
using System.ComponentModel;
using System.Reflection;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using System.Security.Cryptography;
using System.Linq;
using Newtonsoft.Json.Linq;

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

        [Test]
        public void TestIterationPattern2()
        {
            ResourceManager rm = new ResourceManager("Problems.UnitTest.Resource1", Assembly.GetExecutingAssembly());

            string fileName = "Test1.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Resource\", fileName);

            StreamReaderEnumerable sre = new StreamReaderEnumerable(path);

            IEnumerable<string> results;

            try
            {
                results = from line in new StreamReaderEnumerable(path)
                          where line.Contains("1500")
                          select line;
            }
            catch
            {
                throw new FileNotFoundException();
            }

            int count = 0;
            foreach(string line in results)
            {
                Console.WriteLine("Line"+ ++count + ": " + line);
            }
            

            //string text = File.ReadAllText(path);
            //Console.WriteLine(text);
        }

    }
}
