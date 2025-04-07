using System;

public interface IDestroyable
{
    void DestroyObject();

    event Action Destroyed;
}
