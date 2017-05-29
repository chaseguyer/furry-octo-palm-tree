using UnityEngine;
using System.Collections;

public abstract class Inhabitant : Entity 
{
    public Inhabitant()
    {

    }

    /// <summary>
    /// Moves the Inhabitant in the indicated direction
    /// </summary>
    public abstract void Move();
}