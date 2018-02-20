using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fish : MonoBehaviour {

    private float cur_power = 0;
    public float x_float, y_float, max_power;
    public GameObject hook;
    private bool casted = false, can_charge = true;
    public MiniMap_Controller minimap;

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
                if (Input.GetMouseButton(0) && cur_power < max_power)
                    cur_power += Time.deltaTime;
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
                casted = false;
                lr.enabled = false;
            }
        }
	}

    private void Cast_Line(float power)
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        can_charge = false; 
        casted = true;
        hook.SetActive(true);
        hook.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        minimap.Object_Followed = hook;
        hook.GetComponent<Rigidbody2D>().AddForce(new Vector2(mouse.x > transform.position.x ? power * x_float : -power * x_float, power * y_float));
        Camera.main.GetComponent<Camera_Follow>().to_follow = hook;
    }
}
