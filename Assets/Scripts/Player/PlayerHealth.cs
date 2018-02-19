using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {


 public int health;
 public int invultime;
 private bool hurtable;
 public GameManager manager;

 void Start()
 {
    hurtable=true;
 }


 
  void OnTriggerEnter2D(Collider2D other)
  {
    
            if (other.gameObject.tag == "Bird" && hurtable)
            {
				health-=1;
                hurtable=false;
                StartCoroutine(invincible());
                StartCoroutine(flashing());
            }

            if(health<0)
            {
                manager.end();
            }
        
  }

  private IEnumerator invincible()
  {
        yield return new WaitForSeconds(3f);
		hurtable=true;
  }

  private IEnumerator flashing()
  {
      float time=0;
      while(time<3)
      {
            gameObject.transform.GetComponentInParent<SpriteRenderer>().enabled=false;
            yield return new WaitForSeconds(.25f);
            time+=.25f;
            gameObject.transform.GetComponentInParent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.25f);
            time += .25f;

        }
  }
}