using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace DataStructureAndAlgorithms
{
    public class DS020_custom_collections
    {

    }

    public class CustomCollection : IEnumerable
    {


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    /* IEnumerable example
    **
    **
    **
    **
    **
    */

    public class People : IEnumerable
    {
        Person[] _list;
        public People(Person[] list)
        {
            _list = new Person[list.Length];

            //shallow copy
            for(int i=0; i < list.Length; i++)
            {
                _list[i] = list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetPeopleEnumerator();
        }

        public IEnumerator GetPeopleEnumerator()
        {
            return new PeopleEnumerator(_list);
        }
    }

    public class PeopleEnumerator : IEnumerator
    {
        Person[] _list;
        int currentPosition = -1;
     
        public PeopleEnumerator(Person[] list)
        {
            _list = list;
        }

        public Person Current
        {
            get
            {
                try
                {
                    return _list[currentPosition];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get {
                return Current;
            }
        }

        public bool MoveNext()
        {
            currentPosition++;
            return (currentPosition < _list.Length);
        }

        public void Reset()
        {
            currentPosition = -1;
        }
    }

    /* IEnumerable<T> example
    **
    **
    **
    **
    **
    */

    public class StreamReaderEnumerable : IEnumerable<string>
    {

        string _path;

        public StreamReaderEnumerable(string path)
        {
            _path = path;
        }

        public IEnumerator<string> GetEnumerator()
        {
             return new StreamReaderEnumerator(_path);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }

        private IEnumerator GetEnumerator1()
        {
            return GetEnumerator();
        }
    }

    public class StreamReaderEnumerator : IEnumerator<string>
    {
        private StreamReader _sr;
        public StreamReaderEnumerator(string path)
        {
            _sr = new StreamReader(path);
        }

        private string _current;

        public string Current
        {
            get
            {
                if(_sr == null || _current == null)
                {
                    throw new InvalidOperationException();
                    
                }

                return _current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            _current = _sr.ReadLine();
            return _current != null;
        }

        public void Reset()
        {
            _sr.DiscardBufferedData();
            _sr.BaseStream.Seek(0, SeekOrigin.Begin);
            _current = null;
        }

        // Implement IDisposable, which is also implemented by IEnumerator(T).
        private bool disposedValue = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose of managed resources.
                }
                _current = null;
                if (_sr != null)
                {
                    _sr.Close();
                    _sr.Dispose();
                }
            }

            this.disposedValue = true;
        }

        ~StreamReaderEnumerator()
        {
            Dispose(false);
        }
    }

    /* Yield example
    *******************************************************
    * Another strategy to creating an interator is directly 
    * using the keyword yield. In fact, this avoid the 
    * creation of IEnumerable and IEnumerators for the 
    * custom collection.
    * 
    * When a yield return statement is reached in the 
    * iterator method, expression is returned, and the 
    * current location in code is retained. Execution 
    * is restarted from that location the next time that 
    * the iterator function is called.
    ******************************************************
    */

    public class YieldOperator
    {

        public IEnumerable<int> GetSingleDigitNumbers1()
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
        public IEnumerable<int> GetSingleDigitNumbers2()
        {
            int i = 0;

            while (i < 10)
            {
                yield return i++;
            }
        }



    }


    //references to add to readme
    //https://www.claudiobernasconi.ch/2013/07/22/when-to-use-ienumerable-icollection-ilist-and-list/
    //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield
    //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=netcore-3.1

}
