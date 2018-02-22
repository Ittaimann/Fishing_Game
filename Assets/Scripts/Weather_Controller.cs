using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_Controller : MonoBehaviour {

    public float left, right;
    public SpriteRenderer sky;
    bool stop_translate = false;
    bool is_night = false;
    public GameManager gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!stop_translate)
        {
            transform.Translate(new Vector3(1 * Time.deltaTime, 0, 0));
            if (transform.localPosition.x > right)
            {
                transform.localPosition = new Vector3(left, transform.localPosition.y, transform.localPosition.z);
                is_night = !is_night;
                StartCoroutine(Change_Sky(is_night));
            }
        }

	}

    private IEnumerator Change_Sky(bool is_night)
    {
        if(!is_night)
        {
            gm.win();
        }
        else
        {
            stop_translate = true;
            yield return new WaitForSeconds(1);
            for (int i = 0; i < 50; ++i)
            {
                sky.color = new Color(sky.color.r, is_night ? sky.color.g - 0.02f : sky.color.g + 0.02f, sky.color.b);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(1f);
            GetComponent<SpriteRenderer>().color = is_night ? new Color(.83f, .83f, .83f) : new Color(1, 1, 0);
            stop_translate = false;
        }

    }
}
