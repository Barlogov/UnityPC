using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // <--- !!!!!!!!Important!!!!!!!!

public class Basket : MonoBehaviour {

	[Header("Set Dynamically")]
	public Text scoreGT;
	static public int score;

	// Use this for initialization
	void Start () {
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		scoreGT = scoreGO.GetComponent<Text>();
		scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
		
		if(!PauseMenu.GameIsPaused){
			Vector3 pos = this.transform.position;
			pos.x=mousePos3D.x;
			this.transform.position=pos;
		}
	}

	void OnCollisionEnter(Collision coll) {
		GameObject collidedWith = coll.gameObject;
		if(collidedWith.tag == "Apple"){
			Destroy(collidedWith);
			score = int.Parse(scoreGT.text);
			score += 100;
			scoreGT.text = score.ToString();
			if (score > HighScore.score){
				HighScore.score = score;
			}
		}

		

	}
	
}
