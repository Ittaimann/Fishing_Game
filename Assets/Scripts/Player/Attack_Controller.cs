using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour
{

    public float track_speed;
    private Rigidbody2D rb2d;
    public GameObject boat;
    private int num_swings = 0;
    public int max_swings;
    void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }


    void OnEnable()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        num_swings = max_swings;
        //rb2d.AddForce(new Vector2(-(transform.position.x-mouse.x)*100,250));
        rb2d.AddForce(new Vector2(0, 250));
    }

    void FixedUpdate()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && num_swings > 0)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(-(transform.position.x - mouse.x) * 50, -(transform.position.y - mouse.y) * 100));
            num_swings--;
        }
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

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Bird" && enabled)
        {
            if(num_swings < max_swings)
                num_swings++;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
            c.GetComponent<Bird_Controller>().Take_Damage();
        }
    }
}
