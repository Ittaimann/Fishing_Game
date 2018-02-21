using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public ParticleSystem movement_splash;

	// Use this for initializatio
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        movement_splash.Play();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, rb.velocity.y, 0);
        if (rb.velocity.x > 0)
        {
            movement_splash.Emit(1);

            movement_splash.transform.localPosition = new Vector3(-0.4f, 0, 0);
            movement_splash.transform.rotation = Quaternion.Euler(new Vector3(0, 180, -10));
        }
        else if (rb.velocity.x < 0)
        {
            movement_splash.Emit(1);

            movement_splash.transform.localPosition = new Vector3(0.4f, 0, 0);
            movement_splash.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -10));
        }

    }

}
