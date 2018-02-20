using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_Hook_Control : MonoBehaviour {
    private Rigidbody2D rb;
	private HingeJoint2D hinge;
    public float track_speed;
	private Vector2 start;
	private Vector2 end;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        hinge= GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {

		if(hinge.enabled == true)
			rb.velocity=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if(Input.GetMouseButton(0))
		{
			hinge.enabled=false;
		}
		/*if(Input.GetMouseButtonDown(0)){
			start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
        if (Input.GetMouseButtonUp(0))
        {
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
		Debug.Log(start+" "+end);
		if(start!=Vector2.zero && end!=Vector2.zero)
        	rb.AddForce(10*(start-end), ForceMode2D.Impulse);
        if(end!=Vector2.zero)
		{
			start=Vector2.zero;
            end = Vector2.zero;

        }
		/*
         *         mouse_pos = Input.mousePosition;
        if (mouse_pos != old_mouse_pos)
            //This should get the vector to the mouse position - the camera's position then normalizing and multiplying that to get a good vector force
            rb.AddForce((Camera.main.ScreenToWorldPoint(mouse_pos) - Camera.main.transform.position).normalized * force_mod);

        old_mouse_pos = mouse_pos;
         * 
         * 
         * 
         */
    }
}
