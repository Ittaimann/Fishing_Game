using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
	}

}
