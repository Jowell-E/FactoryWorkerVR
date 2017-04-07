using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBeltBehavior : MonoBehaviour {

	public Material texture;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame

	public bool moving = false;
	public float moveSpeed;
	void Update () {
		if (moving) {
			texture.mainTextureOffset = new Vector2(texture.mainTextureOffset.x + moveSpeed * Time.deltaTime, 0);
		}
	}

	void OnCollisionStay(Collision obj ){
		if (obj.gameObject.tag == "Sortable") {
			
			obj.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime, transform);
		}
	}

}
