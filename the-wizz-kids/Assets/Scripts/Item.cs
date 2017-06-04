using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Equippable Inanimate object that may or may not enahnce the equippers attributes
/// </summary>
public class Item : MonoBehaviour 
{
    /// <summary>
    /// The type of Item
    /// </summary>
    public enum Type
    {
        WizHat,
        Cloak,
        Staff,
        Ring,
        Amulet
    }

    /// <summary>
    /// The attributes this Item enhances
    /// </summary>
    public List<Attributes> attributes;

    /// <summary>
    /// How much gold this Item is worth
    /// </summary>
    public int value;

    /// <summary>
    /// The prefab for this Item
    /// </summary>
    public GameObject itemPrefab;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
