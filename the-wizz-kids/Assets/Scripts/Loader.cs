using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject _gameManager;
    public GameObject _guiManager;

    void Awake()
    {
        if(GameManager.instance == null)
        {
            Instantiate(_gameManager);
        }

        if(GuiManager.instance == null)
        {
            Instantiate(_guiManager);
        }
    }
}
