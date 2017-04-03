using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBeltCollision : MonoBehaviour {

	float speed;
	// Use this for initialization
	void Start () {
		speed = GetComponentInParent<ConveyerBeltBehavior> ().moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision obj ){
		if (obj.gameObject.tag == "Sortable") {

			obj.gameObject.GetComponent<Rigidbody> ().velocity= transform.forward * speed;
		}
	
	}
}
