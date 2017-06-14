using System.Collections.Generic;

public class ConcurrentDictionary<tkey, tvalue>
{
    private readonly object syncLock = new object();
    private Dictionary<tkey, tvalue> dict;

    public tvalue this[tkey key]
    {
        get { lock (syncLock) { return dict[key]; } }
        set { lock (syncLock) { dict[key] = value; } }
    }

    public int Count
    {
        get
        {
            lock (syncLock)
            {
                return dict.Count;
            }
        }
    }

    public bool ContainsKey(tkey item) { lock (syncLock) { return dict.ContainsKey(item); } }

    public ConcurrentDictionary()
    {
        this.dict = new Dictionary<tkey, tvalue>();
    }

    public void Add(tkey key, tvalue val)
    {
        lock (syncLock)
        {
            dict.Add(key, val);
        }
    }

    public void Remove(tkey key)
    {
        lock (syncLock)
        {
            dict.Remove(key);
        }
    }

    public void Clear()
    {
        lock (syncLock)
        {
            dict.Clear();
        }
    }

    public tkey[] GetKeysArray() { lock (syncLock) { tkey[] result = new tkey[dict.Keys.Count]; dict.Keys.CopyTo(result, 0); return result; } }
}