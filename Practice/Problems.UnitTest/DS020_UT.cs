using DataStructureAndAlgorithms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("Memory Used With Iterator = \t"
            + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");

            //Run the following code to demonstrate the difference reading a file with and without iterator
            TestReadingFileWithoutEnumerable(path, textToSearch);
        }

        public static void TestReadingFileWithoutEnumerable(string filePath, string textToSearch)
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
                return;
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
            Console.WriteLine("Memory Used Without Iterator = \t" +
                string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
        }

    }
}
