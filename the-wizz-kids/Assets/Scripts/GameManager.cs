using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance = null;
    public GameObject playerPrefab;

    [System.NonSerialized]
    public GameObject player;

	// Use this for initialization
	void Awake () 
    {
        // Make sure there is only one instance
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);

        // We actually destroy this if we hit "Quit"
        DontDestroyOnLoad(gameObject);

        InitializeGame();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void InitializeGame()
    {
        player = Instantiate(playerPrefab, new Vector3(1f, 2f, 0f), Quaternion.identity) as GameObject;
    }
}
