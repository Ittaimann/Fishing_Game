﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Controller : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;

    public float maxDistance;

    bool in_water = false;
    bool caught_fish = false;
    GameObject fish;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (in_water && !caught_fish)
        {
            if (Input.GetMouseButton(0))
                rb.velocity = new Vector2(rb.velocity.x, -speed * Time.deltaTime);
            else
                rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime);
        }
        else if (caught_fish)
        {
            if (Input.GetMouseButton(0))
                rb.velocity = new Vector2(rb.velocity.x, -speed * 2 * Time.deltaTime);
            else
                rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Water"))
        {
            if(!fish)
            {
                //If the hook hits the water after the cast
                GetComponent<AudioSource>().Play();
                in_water = true;
                GetComponent<BoxCollider2D>().isTrigger = false;
                rb.velocity = new Vector2(0, rb.velocity.y);
                rb.gravityScale = 0;
            }
            else
            {
                //If the hook hits the water after it has a fish and was attacking
                rb.gravityScale = 1;
                caught_fish = false;
                in_water = false;
                GetComponent<Attack_Controller>().enabled = false;
                Destroy(fish);
                fish = null;
                enabled = true;
                gameObject.SetActive(false);
            }

            
        }
        else if(c.CompareTag("Fish") && !fish)
        {
            //If the hook hits a fish and it doens't have one hooked

            fish = c.gameObject;
            caught_fish = true;
            c.transform.parent = transform;
            c.GetComponent<Fish_Controller>().enabled = false;
            c.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else if(c.CompareTag("Wall"))
        {
            //If the hooks hits the wall on a cast

            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if(c.CompareTag("Water"))
        {
            if (!fish)
            {
                in_water = false;
                rb.gravityScale = 1;
                gameObject.SetActive(false);
            }
            else
            {
                in_water = false;
                rb.gravityScale = 1;
                GetComponent<Attack_Controller>().enabled = true;
                enabled = false;
            }
        }
    }
}
