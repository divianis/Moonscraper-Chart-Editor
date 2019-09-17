﻿using System;
using System.Collections;
using System.Collections.Generic;

public class EnumLookupTable<EnumType, Value> : IList<Value> where EnumType : Enum
{
    Value[] table = new Value[Enum.GetValues(typeof(EnumType)).Length];

    public Value this[int index] { get => table[index]; set => table[index] = value; }
    public Value this[EnumType index] { get => table[Convert.ToInt32(index)]; set => table[Convert.ToInt32(index)] = value; }

    public int Count => table.Length;

    public bool IsReadOnly => table.IsReadOnly;

    public void Add(Value item)
    {
        ((IList<Value>)table).Add(item);
    }

    public void Clear()
    {
        ((IList<Value>)table).Clear();
    }

    public bool Contains(Value item)
    {
        return ((IList<Value>)table).Contains(item);
    }

    public void CopyTo(Value[] array, int arrayIndex)
    {
        ((IList<Value>)table).CopyTo(array, arrayIndex);
    }

    public IEnumerator<Value> GetEnumerator()
    {
        return ((IList<Value>)table).GetEnumerator();
    }

    public int IndexOf(Value item)
    {
        return ((IList<Value>)table).IndexOf(item);
    }

    public void Insert(int index, Value item)
    {
        ((IList<Value>)table).Insert(index, item);
    }

    public bool Remove(Value item)
    {
        return ((IList<Value>)table).Remove(item);
    }

    public void RemoveAt(int index)
    {
        ((IList<Value>)table).RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return table.GetEnumerator();
    }
}