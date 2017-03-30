using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortDestroyer : MonoBehaviour {

	public string color;
	public string audioName;
	public string obj;
	public bool defective;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Sortable") {
			if (color != "") {
				if (other.gameObject.GetComponent<ObjectProperties> ().color == color) {
					Destroy (other.gameObject);
					GameController.Instance.Sort (other.gameObject);
					return;
				}
			}
			if (audioName != ""){
				if (other.gameObject.GetComponent<ObjectProperties> ().audioName == audioName) {
				Destroy (other.gameObject);
				GameController.Instance.Sort (other.gameObject);
				return;
				}
			}
			if (obj != ""){
				if (other.gameObject.GetComponent<ObjectProperties> ().obj == obj) {
				Destroy (other.gameObject);
				GameController.Instance.Sort (other.gameObject);
				return;
				}
			}
			if (defective != false){
				if (other.gameObject.GetComponent<ObjectProperties> ().defective == defective) {
				Destroy (other.gameObject);
				GameController.Instance.Sort (other.gameObject);
				return;
				}
			}

			Destroy (other.gameObject);
			GameController.Instance.SortedWrong ();
		}
	}
}
