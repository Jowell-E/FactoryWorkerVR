using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehavior : MonoBehaviour {

	public float speed;
	public bool On;
	public bool goUp;
	public Vector3 top;
	public Vector3 bottom;

	public Transform player;
	
	// Update is called once per frame
	void Update () {

		if (On) {
			if (!goUp) {
				MoveTo (bottom);
			} else {
				MoveTo (top);
			}
			return;
		}
			

	}

	public void MoveTo(Vector3 pos){
		transform.localPosition = Vector3.MoveTowards (transform.localPosition, pos, speed * Time.deltaTime);
		player.transform.position = new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z - .5f);

		if (transform.localPosition == top || transform.localPosition == bottom) {
			On = false;
			goUp = !goUp;
		}
	}

}
