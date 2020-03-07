using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

	static public GameObject POI; // Интересующий объект point of interest
	[Header("Set in Inspector")]
	public float easing = 0.05f;
	public Vector2 minXY = Vector2.zero;

	[Header("Set Dynamically")]
	public float camZ; // Желаемая координата Z для камеры

	void Awake(){
		camZ = this.transform.position.z;
	}

	private void FixedUpdate() {
		if (POI == null) return;

		// Получить позицию интересующего объекта
		Vector3 destination = POI.transform.position;
		// Ограничить X и Y минимальными значениями ( чтобы не видить что под землёй)
		destination.x = Mathf.Max(minXY.x, destination.x);
		destination.y = Mathf.Max(minXY.y, destination.y);
		// Определить точку между текущим местоположением камеры и destination
		destination = Vector3.Lerp(transform.position, destination, easing);
		// Принудительно установить значение destination.z равным camZ, чтобы отодвинуть камеру подальше
		destination.z = camZ;
		// Поместить камеру в позицию destination
		transform.position = destination;	
		// Изменить размер обозримого(orthographicSize) камеры, чтобы земля оставалась в поле зрения всегда
		Camera.main.orthographicSize = destination.y+10;

	}
}
