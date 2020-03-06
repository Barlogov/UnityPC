using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour {

	static public int level = 1;
	
	// Update is called once per frame
	void Update () {

		Text gt = this.GetComponent<Text>();
		gt.text = "Level: "+level;
		
	}

	static public void NextLevel(){
		AppleTree.speed *= 1.1f;
		AppleTree.secondsBerweenAppleDrops *= 0.9f;
		level++;
		
	}


}
