using System;
using System.Linq;

public class MyList<T>
{
    private T[] myList;
    private int numberOfElements;
    public MyList()
    {
        myList = new T[0];
        numberOfElements = 0;
    }

    public MyList(int capacity)
    {
        myList = new T[capacity];
        numberOfElements = 0;
    }

    public int Count
    {
        get { return numberOfElements; }
    }

    public int Capacity
    {
        get { return myList.Length; }
    }
    public void Add(T element)
    {
        if (Count == Capacity)
        {
            if (Capacity == 0)
            {
                myList = new T[4];
                myList[0] = element;
                numberOfElements++;
            }
            else
            {
                T[] newList = myList;
                Array.Resize(ref newList, Capacity * 2);
                newList[Count] = element;
                numberOfElements++;
                myList = newList;
            }
        }
        else
        {
            myList[Count] = element;
            numberOfElements++;
        }
    }

    public T this[int x]
    {
        get
        {
            if (Count <= x)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return myList[x];
            }
        }
    }

    public void Clear()
    {
        Array.Clear(myList, 0, Count);  
        numberOfElements = 0;
    }

    public void RemoveLast()
    {
        if (Count == 0)
        {
            throw new IndexOutOfRangeException();
        }
        else
        {
            Array.Clear(myList, Count - 1, 1);
            numberOfElements--;
        }
    }

    public void RemoveAt(int index)
    {
        if (index >= Count)
        {
            throw new IndexOutOfRangeException();
        }
        for(int i = index; i < Count-1; i++)
        {
            myList[i] = myList[i + 1];
        }
        Array.Clear(myList, Count - 1, 1);
        numberOfElements--;

    }

    public T Max()
    {
        if(Count == 0)
        {
            throw new IndexOutOfRangeException();
        }
        else
        {
            T max = myList[0];
            if(max is IComparable)
            {
                foreach(T item in myList)
                {
                    if((max as IComparable).CompareTo(item) < 0)
                    {
                        max = item;
                    }
                }
                return max;

            }
            else
            {
                throw new NotSupportedException("This operation is not supported for this type");
            }
        }
    }
    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < Count; i++)
        {
            s+=myList[i].ToString() + " ";
        }
        return s;
    }
}