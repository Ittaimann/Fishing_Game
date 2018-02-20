using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Physics : MonoBehaviour {

    //private BuoyancyEffector2D be;
    public GameObject splash;

    //void Start()
    //{
    //    be = GetComponent<BuoyancyEffector2D>();
    //    StartCoroutine(UpdateFlow());
    //}

    //private IEnumerator UpdateFlow()
    //{
    //    yield return new WaitForSeconds(2f);
    //    be.flowMagnitude = Random.Range(-5f, 5f);
    //}

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.CompareTag("Player"))
        {
            c.GetComponent<Player_Movement>().enabled = true;
            c.GetComponent<Player_Fish>().enabled = true;
            c.GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<AudioSource>().Play();
            Instantiate(splash, new Vector3(c.transform.position.x, 5, 0), Quaternion.identity);
        }
    }
}
