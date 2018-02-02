using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Controller : MonoBehaviour {

    public float speed;
    public int direction = 1;
    public float end_range;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        speed = Random.Range(speed * 0.5f, speed * 1.5f);
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (direction == 1)
        {
            if (transform.position.x > end_range)
                gameObject.SetActive(false);
        }
        else
        {
            if (transform.position.x < end_range)
                gameObject.SetActive(false);    
        }

        rb.velocity = new Vector2(speed * Time.deltaTime * direction, rb.velocity.y);
	}
}
