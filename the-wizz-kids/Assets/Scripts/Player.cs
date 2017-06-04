using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
    /// <summary>
    /// The attributes of the Player
    /// </summary>
    public Attributes attributes;

    private int _health;
    /// <summary>
    /// Gets or sets the current health value
    /// </summary>
    public int Health
    {
        get { return _health; } 
        set
        {
            if(value >= 0 && value <= attributes.Health)
            {
                _health = value;

                GuiManager.instance.UpdateHealthBar(_health, attributes.Health);

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
    /// Gets or sets the current energy value
    /// </summary>
    public int Energy
    {
        get { return _energy; }
        set
        {
            if(value <= attributes.Energy && value >= 0)
            {
                _energy = value;

                GuiManager.instance.UpdateEnergyBar(_energy, attributes.Energy);
            }
        }
    }

    /// <summary>
    /// The Player's list of learned spells
    /// </summary>
    public List<Spell> spellLibrary;

    /// <summary>
    /// The Player's list of equipped Spells
    /// </summary>
    public List<Spell> spellBook;

    /// <summary>
    /// The size of the spell book
    /// </summary>
    public int spellBookSize;

    /// <summary>
    /// The Player's active Spell
    /// </summary>
    public Spell activeSpell;

    /// <summary>
    /// The Player's unequipped Items
    /// </summary>
    public List<Item> backpack;

    /// <summary>
    /// The max size of the backpack
    /// </summary>
    public int backpackSize;

    /// <summary>
    /// The Player's equipped Items;
    /// </summary>
    public List<Item> equipped; 


	/// <summary>
    /// Start this instance.
    /// </summary>
	void Start () 
    {
        // Health, Energy, Speed, Damage
        attributes = new Attributes(100, 100, 0.2f, 10);

        // Set values w/o using properties
        _health = attributes.Health;
        _energy = attributes.Energy;
	}
	
    /// <summary>
    /// Update this instance.
    /// </summary>
	void Update () 
    {
        HandleMovement();
	}


    void HandleMovement()
    {
        int horizontal = 0;
        int vertical = 0;

        #if UNITY_EDITOR

        horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
        //vertical = (int) (Input.GetAxisRaw("Vertical"));

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

                //int x = (int)(touchDeltaPosition.x * speed);
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
        Vector3 vec = new Vector3(xDir * attributes.Speed, yDir * attributes.Speed, 0f);

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
