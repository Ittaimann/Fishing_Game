using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Controller : MonoBehaviour {

    public float speed;
	private float DiveAngle;
    public int direction = 1; // 1= going to the right, -1 = going to the left
    [Tooltip("Health value between x and y.")]
	public Vector2 healthrange;
	private float health;
	enum birdState{
		neutral,
		chasing,
		leaving,
		posioned,
		stuck
	}
	private birdState birb;
    public float end_range;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {	
		health=Random.Range(healthrange.x,healthrange.y);
		birb= birdState.neutral; 
		if(direction!=1)
		{
            gameObject.transform.rotation= Quaternion.Euler(0,-180,0);

        }
        speed = Random.Range(speed * .9f, speed * 1.3f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            if (transform.position.x > end_range)
                Destroy(gameObject);
        }
        else
        {
            if (transform.position.x < end_range)
                Destroy(gameObject);
        }
		if(birb==birdState.chasing && transform.position.y<=4.8)
		{
			transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, -1*transform.rotation.eulerAngles.z); 
			birb= birdState.leaving;
		}

        rb.MovePosition(transform.position+(transform.right)*Time.deltaTime*speed);
    }


	void OnTriggerEnter2D(Collider2D other)
	{
	
        if (other.tag == "Player"&& Random.Range(1f,10f)<4 && birb==birdState.neutral)
        {
			speed=3;
			
			if(birb != birdState.chasing)
			{
				birb=birdState.chasing;
				Vector2 dif= direction==1 ? transform.position-other.transform.position :  other.transform.position-transform.position;
                DiveAngle = Mathf.Atan2(dif.y,dif.x);
                DiveAngle *=Mathf.Rad2Deg;
                DiveAngle +=180;
				transform.rotation=Quaternion.Euler(0f,transform.rotation.eulerAngles.y,direction*DiveAngle);
			}
        }
	}
//void OnTriggerStay2D(Collider2D other)
//    {
//        if (other.tag == "Fish")
//        {
//            health -= 10*Time.deltaTime; // good testing question, how is the damage going?
//            if (health <= 0)
//                Destroy(gameObject);
//        }
	
//	}

    public void Take_Damage()
    {
        //Here is where they die?? I was thinking one hit kill
        Destroy(gameObject);
    }

	
}
