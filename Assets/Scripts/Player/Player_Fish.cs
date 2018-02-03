using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fish : MonoBehaviour {

    private float cur_power = 0;
    public float x_float, y_float, max_power;
    public GameObject hook;
    private GameObject hook_casted;
    private bool casted = false;

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
            if (Input.GetMouseButton(0) && cur_power < max_power)
                cur_power += Time.deltaTime;
            else if (Input.GetMouseButtonUp(0))
                Cast_Line(cur_power);
        }
        else
        {
            lr.enabled = true;
            Vector3[] pos = {new Vector3(transform.position.x, transform.position.y+1, 0), new Vector3(hook_casted.transform.position.x, hook_casted.transform.position.y+0.5f, 0) };
            lr.SetPositions(pos);
        }
	}

    private void Cast_Line(float power)
    {
        casted = true;
        hook_casted = Instantiate(hook, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        hook_casted.GetComponent<Rigidbody2D>().gravityScale = 1;
        hook_casted.GetComponent<Rigidbody2D>().AddForce(new Vector2(power * x_float, power * y_float));
        Camera.main.GetComponent<Camera_Follow>().to_follow = hook_casted;
    }
}
