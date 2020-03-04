using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
	public float fireRate = 0.3f; // Dont used

	// Update is called once per frame
	void Update () {
		Move();
	}

	public virtual void Move(){
		Vector3 tempPos = pos;
		tempPos.y -= speed * Time.deltaTime;
		pos = tempPos;
	}

	void OnCollisionEnter(Collision coll){
		GameObject other = coll.gameObject;
		switch(other.tag){
			case "Hero":
				// Will be
				break;
			case "HeroLaser":
				Destroy(this.gameObject);
				break;
		}
	}

	public Vector3 pos{
		get{
			return(this.transform.position);
		}
		set{
			this.transform.position=value;
		}
	}
}
