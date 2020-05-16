using System;
using System.Collections;
using System.Collections.Generic;
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
            return GetEnumerator();
        }

        public IEnumerator GetEnumerator()
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
                return _list[currentPosition];
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




    //references to add to readme
    //https://www.claudiobernasconi.ch/2013/07/22/when-to-use-ienumerable-icollection-ilist-and-list/

}
