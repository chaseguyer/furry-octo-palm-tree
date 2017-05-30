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

    private int _health;
    public int Health
    {
        get { return _health; } 
        set
        {
            _health = value;
            if(healthTrans != null)
            {
                // Becuase Unity is retarded
                float f = (float)_health / (float)maxHealth;
                float r = f * (float)maxWidth;
                healthTrans.sizeDelta = new Vector2(r, healthTrans.rect.height);
            }   
        }
    }

    private int _energy;
    public int Energy
    {
        get { return _energy; }
        set
        {
            _energy = value;
            if(energyTrans != null)
            {
                // Becuse Unity is retarded
                float f = (float)_energy / (float)maxEnergy;
                float r = f * (float)maxWidth;
                energyTrans.sizeDelta = new Vector2(r, energyTrans.rect.height);
            }
        }
    }



	// Use this for initialization
	void Start () 
    {
        healthTrans = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<RectTransform>();
        energyTrans = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<RectTransform>();

        maxWidth = healthTrans.rect.width;

        // Set values w/o using properties
        _health = maxHealth;
        _energy = maxEnergy;
	}
	
	// Update is called once per frame
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
            Energy -= 5;
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

        if(Health <= 0)
        {
            Debug.Log("YOU DEAD BITCH GIT GUD U GOT RIGGITY REKT");
        }
	}

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
}
