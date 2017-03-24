using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortDestroyer : MonoBehaviour {

	public string sortName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Sortable") {
			if (other.gameObject.name == sortName) {
				Destroy (other.gameObject);
				GameController.Instance.Sort (other.gameObject);
				return;
			}
		}
		GameController.Instance.SortedWrong ();
		//otherwise do something else here
	}
}
