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
	void FixedUpdate () {
		if (moving) {
			texture.mainTextureOffset = new Vector2(texture.mainTextureOffset.x + (moveSpeed / 4.5f) * Time.deltaTime, 0);
		}
	}

	void OnCollisionStay(Collision obj ){
		if (moving) {
			if (obj.gameObject.tag == "Sortable") {
				obj.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime, transform);
			}
		}
	}

	void OnTriggerStay (Collider obj){
		if (moving) {
			if (obj.gameObject.tag == "Player") {
				if (moveSpeed > 0) {
					obj.transform.parent.parent.transform.Translate (Vector3.right * (moveSpeed - 1f) * Time.deltaTime, transform);
				} else {
					obj.transform.parent.parent.transform.Translate (Vector3.right * (moveSpeed + 1f) * Time.deltaTime, transform);
				}
			}
		}
	}
}
