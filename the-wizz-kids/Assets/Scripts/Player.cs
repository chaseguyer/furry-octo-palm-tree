using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

    public float speed = 0.2f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        int horizontal = 0;
        int vertical = 0;

        #if UNITY_EDITOR

        horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
        vertical = (int) (Input.GetAxisRaw("Vertical"));

        if(horizontal != 0 || vertical != 0) 
        {
            Move(horizontal, vertical);
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

    void Move(int xDir, int yDir)
    {
        Vector3 vec = new Vector3(xDir * speed, yDir * speed, 0f);

        // What our new location will be
        float newX = gameObject.transform.position.x + vec.x;
        float newY = gameObject.transform.position.y + vec.y;

        // FIXME : Where the hell am i going to get these numbers??
        if(newX > 0.4 && newX < 16.5 && newY > 1.9 && newY < 8.5)
        this.transform.position += vec;
    }
}
