using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Controls Camera angles, menu visibility, and navigation
/// </summary>
public class GuiManager : MonoBehaviour 
{
    /// <summary>
    /// The GuiManager instance.
    /// </summary>
    public static GuiManager instance;

    // Health/Energy bars calculations
    private float maxWidth;
    private RectTransform healthTrans;
    private RectTransform energyTrans;

    public void Awake()
    {
        // Make sure there is only one instance
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);

        // We actually destroy this if we hit "Quit"
        DontDestroyOnLoad(gameObject);

        Initialize();
    }

	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Initialize()
    {
        Debug.Log("Gui Init");

        healthTrans = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<RectTransform>();
        energyTrans = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<RectTransform>();
        maxWidth = healthTrans.rect.width;
    }

    public void UpdateHealthBar(int cHealth, int mHealth)
    {
        if(healthTrans != null)
        {
            // Becuase Unity is retarded
            float f = (float)cHealth / (float)mHealth;
            float r = f * (float)maxWidth;
            healthTrans.offsetMax = new Vector2(r, healthTrans.rect.height/2);
        }
    }

    public void UpdateEnergyBar(int cEnergy, int mEnergy)
    {
        if(energyTrans != null)
        {
            // Becuse Unity is retarded
            float f = (float)cEnergy / (float)mEnergy;
            float r = f * (float)maxWidth;
            energyTrans.offsetMax = new Vector2(r, energyTrans.rect.height/2);
        }
    }

    // Update spells
    // Grab players inventory
    // Grab players gold

}
