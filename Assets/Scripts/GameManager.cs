using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject fish;
    [Header("Spawn Range")]
    public float x_range_min;
    public float x_range_max;
    public float y_range_min;
    public float y_range_max;

	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn_Fish());
	}

    private IEnumerator Spawn_Fish()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            GameObject f;
            int dir = Random.Range(0, 2) == 0 ? 1 : -1;
            if (dir == 1)
            {
                f = Instantiate(fish, new Vector3(x_range_min, Random.Range(y_range_min, y_range_max)), Quaternion.identity);
                f.GetComponent<Fish_Controller>().end_range = x_range_max;
            }
            else
            {
                f = Instantiate(fish, new Vector3(x_range_max, Random.Range(y_range_min, y_range_max)), Quaternion.identity);
                f.GetComponent<Fish_Controller>().end_range = x_range_min;
            }
            f.GetComponent<Fish_Controller>().direction = dir;
        }

    }
}
