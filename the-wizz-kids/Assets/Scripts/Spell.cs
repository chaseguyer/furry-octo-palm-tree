using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour 
{
    public Type type;
    public enum Type
    {
        Destruction,
        Mobility,
        Defense
    }

    public Cast cast;
    public enum Cast
    {
        Tap,
        DTap,
        Hold
    }

    public GameObject SpellPrefab;

    public string spellName;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
