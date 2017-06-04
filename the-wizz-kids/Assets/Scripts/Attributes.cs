using UnityEngine;
using System.Collections;

/// <summary>
/// Attributes
/// </summary>
public class Attributes
{
    public int Health;
    public int Energy;
    public float Speed;
    public int Damage;

    // Resistances?

    public Attributes(int health, int energy, float speed, int damage)
    {
        Health += health;
        Energy += energy;
        Speed += speed;
        Damage += damage;
    }
}