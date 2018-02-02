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
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, rb.velocity.y, 0);
        if (rb.velocity.x > 0)
        {
            if(!movement_splash.isPlaying)
                movement_splash.Play();

            movement_splash.transform.localPosition = new Vector3(0.5f, 0, 0);
            movement_splash.transform.rotation = Quaternion.Euler(new Vector3(0, 180, -10));
        }
        else if (rb.velocity.x < 0)
        {
            if (!movement_splash.isPlaying)
                movement_splash.Play();

            movement_splash.transform.localPosition = new Vector3(-0.5f, 0, 0);
            movement_splash.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -10));
        }
        else
            movement_splash.Stop();

    }
}
