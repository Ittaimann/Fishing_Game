﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fish : MonoBehaviour {

    private float cur_power = 0;
    public float x_float, y_float, max_power;
    public GameObject hook;
    private bool casted = false, can_charge = true;
    public MiniMap_Controller minimap;

    public Transform PowerBar;
    private bool shakeBar = false, shakingBar = false;
    public bool shakyBar;

    //Changes the direction of the power bar (makes it go up (1) then down (-1))
    private int UpDownPower = 1;

    private LineRenderer lr;
	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!casted)
        {
            lr.enabled = false;
            if (can_charge)
            {
                if (Input.GetMouseButton(0))
                {
                    shakeBar = true;
                    if (shakyBar && !shakingBar)
                        StartCoroutine(ShakePowerBar());
                    PowerBar.parent.gameObject.SetActive(true);
                    if (cur_power >= max_power)
                        UpDownPower = -1;
                    else if (cur_power <= 0)
                        UpDownPower = 1;
                    cur_power += Time.deltaTime * UpDownPower;

                    //Flips the power bar to be on the left or right depending on mouse position
                    Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (mouse.x > transform.position.x)
                        PowerBar.parent.transform.localPosition = new Vector3(0.6f, 1.125f, 0);
                    else
                        PowerBar.parent.transform.localPosition = new Vector3(-0.6f, 1.125f, 0);


                    //Makes the bar go up and change color
                    PowerBar.localScale = new Vector3(.6f, 0.6f * (cur_power / max_power), 1);
                    PowerBar.localPosition = new Vector3(0, -.3f + ((cur_power / max_power) * .3f), 0);
                    PowerBar.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.green, cur_power / max_power);
                }
                else if (Input.GetMouseButtonUp(0))
                    Cast_Line(cur_power);
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                    can_charge = true;
            }


        }
        else
        {
            lr.enabled = true;
            Vector3[] pos = {new Vector3(transform.position.x, transform.position.y+1, -1), new Vector3(hook.transform.position.x, hook.transform.position.y+0.5f, -1) };
            lr.SetPositions(pos);
            if (!hook.activeSelf)
            {
                Camera.main.GetComponent<Camera_Follow>().to_follow = gameObject;
                minimap.Set_Follow(gameObject);
                casted = false;
                lr.enabled = false;
            }
        }
	}

    private void Cast_Line(float power)
    {
        shakeBar = false;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Invoke("ClosePowerBar", 1);
        GetComponent<AudioSource>().Play();
        cur_power = 0;
        can_charge = false; 
        casted = true;
        hook.SetActive(true);
        hook.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        minimap.Set_Follow(hook);
        hook.GetComponent<Rigidbody2D>().AddForce(new Vector2(mouse.x > transform.position.x ? power * x_float : -power * x_float, power * y_float));
        Camera.main.GetComponent<Camera_Follow>().to_follow = hook;
    }

    void ClosePowerBar()
    {
        PowerBar.parent.gameObject.SetActive(false);
    }

    private IEnumerator ShakePowerBar()
    {
        shakingBar = true;
        Vector3 origin = PowerBar.parent.localPosition;
        float percent;
        while(shakeBar)
        {
            percent = cur_power / max_power;
            yield return new WaitForSeconds(0.1f);

            //I dont like having this here but it works for now
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mouse.x > transform.position.x)
                origin.x = 0.6f;
            else
                origin.x = -0.6f;

            PowerBar.parent.localPosition = new Vector3(origin.x + Random.Range(-.05f * percent, .05f * percent), origin.y + Random.Range(-.05f * percent, .05f * percent), 0);
        }
        PowerBar.parent.localPosition = origin;
        shakingBar = false;
    }
}
