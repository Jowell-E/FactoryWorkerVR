using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAudio : MonoBehaviour {

	AudioSource source;
	ObjectProperties obj;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		obj = GetComponent<ObjectProperties> ();
		rb = GetComponent<Rigidbody> ();
	}

	GameObject lastHit;
	void OnCollisionEnter(Collision other){
		if (obj.audioClips.Length == 0) {
			return;
		}
		float velocity;
		velocity = rb.velocity.sqrMagnitude;
		if (other.gameObject != lastHit) {
			if (!source.isPlaying) {
				if (velocity > 0.05f) {
					AudioController.instance.RandomizeSfx (source, obj.audioClips);
					lastHit = other.gameObject;
				}
			}
		}
	}

	void OnCollisionExit(Collision other){
		if (other.gameObject == lastHit) {
			lastHit = null;
		}
	}
}
