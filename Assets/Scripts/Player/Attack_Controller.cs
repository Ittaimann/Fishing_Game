using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour
{

    public float track_speed;
    private Rigidbody2D rb2d;
    public GameObject boat;
    void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }


    void OnEnable()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log(mouse);
        rb2d.AddForce(new Vector2(-(transform.position.x-boat.transform.position.x)*100,250));
    }
    void FixedUpdate()
    {
       // Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //transform.position = Vector2.Lerp(transform.position, mouse, track_speed * Time.deltaTime);

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
