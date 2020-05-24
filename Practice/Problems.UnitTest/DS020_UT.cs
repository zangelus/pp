using DataStructureAndAlgorithms;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Resources;

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
        public void TestIEnumerator()
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
        public void TestIEnumeratorOfT()
        {
            ResourceManager rm = new ResourceManager("Problems.UnitTest.Resource1", Assembly.GetExecutingAssembly());

            string fileName = "Test1.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Resource\", fileName);
            string textToSearch = "1500";

            // Check the memory before the iterator is used.
            long memoryBefore = GC.GetTotalMemory(true);

            StreamReaderEnumerable sre = new StreamReaderEnumerable(path);

            IEnumerable<string> results;

            try
            {
                results = from line in new StreamReaderEnumerable(path)
                          where line.Contains(textToSearch)
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

            long memoryAfter = GC.GetTotalMemory(false);
            long totalMemoryWithEnumerable = ((memoryAfter - memoryBefore) / 1000);

            Console.WriteLine("Memory Used With Iterator = \t"
            + string.Format(totalMemoryWithEnumerable.ToString(), "n") + "kb");

            //Run the following code to demonstrate the difference reading a file with and without iterator
            long? totalMemoryWihtoutEnumerable = 
                TestReadingFileWithoutEnumerable(path, textToSearch);

            Assert.Greater(totalMemoryWihtoutEnumerable, totalMemoryWithEnumerable);
        }

        public static long? TestReadingFileWithoutEnumerable(string filePath, string textToSearch)
        {
            long memoryBefore = GC.GetTotalMemory(true);
            StreamReader sr;
            try
            {
                sr = File.OpenText(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@"This example requires a file named " + filePath);
                return null;
            }

            // Add the file contents to a generic list of strings.
            List<string> fileContents = new List<string>();
            while (!sr.EndOfStream)
            {
                fileContents.Add(sr.ReadLine());
            }

            // Check for the string.
            var stringsFound =
                from line in fileContents
                where line.Contains(textToSearch)
                select line;

            sr.Close();
            Console.WriteLine("Found: " + stringsFound.Count());

            // Check the memory after when the iterator is not used, and output it to the console.
            long memoryAfter = GC.GetTotalMemory(false);
            long totalMemory = ((memoryAfter - memoryBefore) / 1000);

            Console.WriteLine("Memory Used Without Iterator = \t" +
                string.Format(totalMemory.ToString(), "n") + "kb");

            return totalMemory;
        }

        [Test]
        public void TestYieldPattern1()
        {
            int i = 9;
            foreach(var el in GetSingleDigitNumbers1())
            {
                Assert.AreEqual(i--, el);
            }
        }

        [Test]
        public void TestYieldPattern2()
        {
            int i = 9;
            foreach (var el in GetSingleDigitNumbers2())
            {
                Assert.AreEqual(i--, el);
            }
        }

        [Test]
        public void TestYieldPattern3()
        {
            int[] expected5 = new[] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };

            IEnumerator a = expected5.GetEnumerator();
            IEnumerator b = GetSingleDigitNumbers3().GetEnumerator();

            while (a.MoveNext() && b.MoveNext())
            {
                Assert.AreEqual(a.Current, b.Current);
            }
        }

        [Test]
        public void TestYieldPattern4()
        {
            var list1 = new[] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
            var list2 = GetSingleDigitNumbers3();

            var tuple = list1.Zip(list2);

            foreach(var t in tuple)
            {
                Assert.AreEqual(t.First, t.Second);
            }
        }

        private IEnumerable<int> GetSingleDigitNumbers1()
        {
            yield return 9;
            yield return 8;
            yield return 7;
            yield return 6;
            yield return 5;
            yield return 4;
            yield return 3;
            yield return 2;
            yield return 1;
            yield return 0;
        }
        private IEnumerable<int> GetSingleDigitNumbers2()
        {
            int i = 9;

            while (i >=0)
            {
                yield return i--;
            }
        }

        private IEnumerable<int> GetSingleDigitNumbers3()
        {
            var range = Enumerable.Range(0, 100 +1);

            foreach(var el in range)
            {
                if(el % 5 == 0)
                {
                    yield return el;
                }
            }
        }


    }
}
