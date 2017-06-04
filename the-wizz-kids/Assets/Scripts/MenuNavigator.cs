using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void ToggleActive(GameObject obj)
    {
        bool state = obj.activeSelf;
        obj.SetActive(!state);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchFromMenuTo(GameObject toObj)
    {
        GameObject obj = GameObject.Find("Main");
        obj.SetActive(false);

        toObj.SetActive(true);
    }
}
