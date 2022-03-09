using System;
using System.Collections.Generic;

internal class Map<TKey, TValue>
{
    List<(TKey, TValue)> map;
    public Map()
    {
        map = new();
    }

    public void Add(TKey key, TValue value)
    {
        if (map.Exists(x => x.Item1.Equals(key)))
        {
            throw new ArgumentException($"An item with the same key has already been added. Key: {key}");
        }
        else
        {
            map.Add((key, value));
        }
    }

    public TValue this[TKey key]
    {
        get
        {
            if (!map.Exists(x => x.Item1.Equals(key)))
            {
                throw new ArgumentException($"The given key '{key}' was not present in the map.");
            }
            else
            {
                return map.Find(x => x.Item1.Equals(key)).Item2;
            }
        }
    }

    public bool Remove(TKey key)
    {
        if (!map.Exists(x => x.Item1.Equals(key)))
        {
            return false;
        }
        else
        {
            map.Remove(map.Find(x => x.Item1.Equals(key)));
            return true;
        }

    }

    public int Count => map.Count;

    public bool ContainsKey(TKey key)
    {
        return map.Exists(x => x.Item1.Equals(key));
    }
}