using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PTNLSystem : MonoBehaviour {
	
	
	bool rdy =true;
	static public int ptnl = 1000;
	

	// Use this for initialization
	void Start () {

		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Basket.score == ptnl && rdy){
			LevelSystem.NextLevel();
			rdy = false;
			ptnl = ptnl+ 400* LevelSystem.level;
			print(ptnl);
			}

		if(Basket.score == ptnl-100){
			rdy = true;
		}

		Text gt = this.GetComponent<Text>();
		gt.text = "Points To Next Level: "+ (ptnl- Basket.score);

		
	}
}
