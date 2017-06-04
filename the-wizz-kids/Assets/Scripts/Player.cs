using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public float speed = 0.2f;

    public int maxHealth = 100;
    public int maxEnergy = 100;

    private float maxWidth;

    private RectTransform healthTrans;
    private RectTransform energyTrans;

    // FIXME: if you plan on MVVM'ing this bish, change this
    private int _health;
    /// <summary>
    /// Gets or sets the health value
    /// </summary>
    public int Health
    {
        get { return _health; } 
        set
        {
            if(value >= 0 && value <= maxHealth)
            {
                _health = value;
                if(healthTrans != null)
                {
                    // Becuase Unity is retarded
                    float f = (float)_health / (float)maxHealth;
                    float r = f * (float)maxWidth;
                    healthTrans.offsetMax = new Vector2(r, healthTrans.rect.height/2);
                }

                // Consider putting this elsewhere
                if(_health == 0)
                {
                    Die();
                }
            }
        }
    }

    private int _energy;
    /// <summary>
    /// Gets or sets the energy value
    /// </summary>
    public int Energy
    {
        get { return _energy; }
        set
        {
            if(value <= maxEnergy && value >= 0)
            {
                _energy = value;
                if(energyTrans != null)
                {
                    // Becuse Unity is retarded
                    float f = (float)_energy / (float)maxEnergy;
                    float r = f * (float)maxWidth;
                    energyTrans.offsetMax = new Vector2(r, energyTrans.rect.height/2);
                }
            }
        }
    }


	/// <summary>
    /// Start this instance.
    /// </summary>
	void Start () 
    {
        healthTrans = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<RectTransform>();
        energyTrans = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<RectTransform>();

        maxWidth = healthTrans.rect.width;

        // Set values w/o using properties
        _health = maxHealth;
        _energy = maxEnergy;
	}
	
    /// <summary>
    /// Update this instance.
    /// </summary>
	void Update () 
    {

        // MOVEMENT
        int horizontal = 0;
        int vertical = 0;

        #if UNITY_EDITOR

        horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
        vertical = (int) (Input.GetAxisRaw("Vertical"));

        if(horizontal != 0 || vertical != 0) 
        {
            Move(horizontal, vertical);
        }

        // TEST
        if(Input.GetMouseButtonDown(0))
        {
            Health -= 5;
        }
        if(Input.GetMouseButtonDown(1))
        {
            Health += 5;
        }

        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                int x = (int)(touchDeltaPosition.x * speed);
                int y = (int)(touchDeltaPosition.y * speed);
                Move(x, y);
            }
        }
        #endif
	}

    /// <summary>
    /// Move the specified xDir and yDir.
    /// </summary>
    /// <param name="xDir">X dir.</param>
    /// <param name="yDir">Y dir.</param>
    void Move(int xDir, int yDir)
    {
        Vector3 vec = new Vector3(xDir * speed, yDir * speed, 0f);

        // What our new location will be
        float newX = gameObject.transform.position.x + vec.x;
        float newY = gameObject.transform.position.y + vec.y;

        // FIXME : Where the hell am i going to get these numbers??
        if(newX > -8.5 && newX < 8.5 && newY > -3.8 && newY < 3.8)
        this.transform.position += vec;
    }

    /// <summary>
    /// Called when the player should die
    /// </summary>
    void Die()
    {
        Debug.Log("YOU DEAD BITCH");
        Destroy(gameObject);
    }
}
