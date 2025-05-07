using System;

public interface IInventory
{
    int Index { get; }
    event Action Added;
}
