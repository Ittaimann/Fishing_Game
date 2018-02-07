using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour
{

    public float track_speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.Lerp(transform.position, mouse, track_speed * Time.deltaTime);

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
