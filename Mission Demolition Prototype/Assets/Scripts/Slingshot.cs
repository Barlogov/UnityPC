using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

	[Header("Set in Inspector:")]
	public GameObject prefubProjectile;
	public float velocityMult = 8f;

	[Header("Set Dynamically")]
	public GameObject launchPoint;
	public Vector3 launchPos;
	public GameObject projectile;
	public bool aimingMode;
	
	private Rigidbody projectileRigidbody;


	void Awake() {
		Transform launchPointTrans = transform.Find("LounchPoint");  //Поиск дочернего объекта и возврат компонента Transform
		launchPoint = launchPointTrans.gameObject;                   //Получение игрового объекта, владеющего этим Transform
		launchPoint.SetActive(false);
		launchPos = launchPointTrans.position;
	}

	// Введение и выход мышки из колайдера объекта
	void OnMouseEnter() {
		//print("Slingshot:OnMouseEnter()");
		launchPoint.SetActive(true);
	}

	void OnMouseExit() {
		//print("Slingshot:OnMouseExit()");
		launchPoint.SetActive(false);
	}

	private void OnMouseDown() {
		aimingMode = true;
		projectile = Instantiate(prefubProjectile) as GameObject;
		projectile.transform.position = launchPos;
		//projectile.GetComponent<Rigidbody>().isKinematic = true; // Делет объект кинематическим
		projectileRigidbody = projectile.GetComponent<Rigidbody>();
		projectileRigidbody.isKinematic = true;
	}

	private void Update() {
		if(!aimingMode) return;
			// Получение координат мыши
			Vector3 mousePos2D = Input.mousePosition;
			mousePos2D.z = -Camera.main.transform.position.z;
			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

			// 
			Vector3 mouseDelta = mousePos3D - launchPos;
			// Ограничить дельту радиусом колайдера рогадки
			float maxMagnitude = this.GetComponent<SphereCollider>().radius;
			if(mouseDelta.magnitude > maxMagnitude){
				mouseDelta.Normalize();
				mouseDelta *= maxMagnitude;	
			}

			// Передвинуть снаряд
			Vector3 projPos = launchPos + mouseDelta;
			projectile.transform.position = projPos;
			if(Input.GetMouseButtonUp(0)){
				aimingMode = false;
				projectileRigidbody.isKinematic = false;
				projectileRigidbody.velocity = -mouseDelta*velocityMult;
				FollowCam.POI = projectile;
				projectile=null;
			}


	}
}
