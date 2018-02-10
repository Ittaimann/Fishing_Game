using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap_Controller : MonoBehaviour {

    private Image background;
    public GameObject minimap;
    public GameObject Object_Showing, Object_Followed;

    //This is the max travel range of the Boat (how much left and right they can go)
    public float travel_range_x;
    private bool open = false;

    //the max range is -300 to 300
    private int x_pos;

	// Use this for initialization
	void Start () {
        background = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = (Object_Showing.transform.position - Object_Followed.transform.position).magnitude;

        if (distance > 10)
            StartMinimap();
        else if (distance <= 10)
            CloseMinimap();
        if(open)
        {
            if (Object_Showing.transform.position.x >= Object_Followed.transform.position.x)
                transform.localPosition = new Vector3(Mathf.Lerp(0, 300f, (Object_Showing.transform.position.x - Object_Followed.transform.position.x)/travel_range_x), 0, 0);
            else
                transform.localPosition = new Vector3(Mathf.Lerp(0, -300f, (Object_Followed.transform.position.x - Object_Showing.transform.position.x) / travel_range_x), 0, 0);

            if (Object_Showing.transform.position.y >= Object_Followed.transform.position.y)
                transform.localPosition = new Vector3(transform.localPosition.x, 125, 0);
            else
                transform.localPosition = new Vector3(transform.localPosition.x, -125, 0);
        }
    }

    public void Casted(GameObject o)
    {
        Object_Followed = o;
    }

    void CloseMinimap()
    {
        if(open)
        {
            open = false;
            background.enabled = false;
            minimap.SetActive(false);
        }
    }

    void StartMinimap()
    {
        if(!open)
        {
            open = true;
            background.enabled = true;
            minimap.SetActive(true);
        }
    }
}
