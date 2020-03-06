using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

	[Header("Set in Inspector")]
    public GameObject applePrefab;
    public static float speed = 10f;
    public float leftAndRightEdge = 20f;
    public float chanceToChangeDirections = 0.02f;
    public static float secondsBerweenAppleDrops = 0.8f;

	// Use this for initialization
	void Start () {
		Invoke("DropApple", 2f);  
	}

	void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBerweenAppleDrops);
    }
	
	// Update is called once per frame
	void Update () {
		
		 Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if( pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);
        } else {
            if (pos.x > leftAndRightEdge){
                speed = -Mathf.Abs(speed);
            } 
        }

	}

	void FixedUpdate(){
        if (Random.value < chanceToChangeDirections){
            	 speed *= -1;
            }
    }
}
