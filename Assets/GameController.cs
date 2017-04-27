using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private static GameController instance = null;
	public static GameController Instance
	{
		get
		{
			return instance;
		}
	}


	void Awake (){
		if(instance){
			DestroyImmediate(gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad(gameObject);
	}


	public bool started = false;
	public Text scoreDisplay;
	public float score = 0;
	public float scoreBonus = .5f;
	public float scoreWrongBonus = .75f;
	public float morale = 0;
	// Use this for initialization

	void Start () {
		markStart = mark.transform.localPosition;
		SetUpLevel ();

		MakeObjectList ();
		MakeSortingRules ();
		UpdateInstructions ();
		SteamVR_Fade.View (Color.black, 0f);
		Invoke ("WakeUp", 2.5f);
	}

	void WakeUp(){
		SteamVR_Fade.View (Color.clear, 5f);
	}

	public AudioClip startGuy;
	public AudioClip dialGuy;
	public AudioClip themoreyouGuy;
	public AudioClip todayyousortGuy;
	public AudioClip intoAGuy;
	public AudioClip[] objectsToSortGuy;
	public AudioClip[] positiveRemarks;
	public AudioClip[] negativeRemarks;
	public AudioClip fallingSFX;

	public int level = 0;
	void SetUpLevel(){
		if (level == 0) {
			AudioController.instance.PlaySingle (startGuy, AudioController.instance.musicSource);
			Invoke ("PlayLoudspeaker", startGuy.length);
		} else {
			PlayLoudspeaker ();
		}
	}

	public AudioClip endBuzzer;
	public void EndLevel(){
		if (level == 0) {
			AudioController.instance.PlaySingle (endBuzzer, null);
			SteamVR_Fade.View (Color.black, 2.5f);
			Invoke ("LoadNextScene", 5f);
		}
	}

	void LoadNextScene(){
		if (level == 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (1);
			Destroy (GameController.instance.gameObject);
		}
	}
	void PlayLoudspeaker(){
		
		AudioController.instance.PlaySingle (dialGuy, AudioController.instance.musicSource);
		Invoke ("PlayLoudspeaker", dialGuy.length);

		if (AudioController.instance.musicSource.clip == dialGuy) {
			AudioController.instance.PlaySingle (themoreyouGuy, AudioController.instance.musicSource);
			Invoke ("PlayLoudspeaker", themoreyouGuy.length);
		} else if (AudioController.instance.musicSource.clip == themoreyouGuy){
			AudioController.instance.PlaySingle(todayyousortGuy, AudioController.instance.musicSource);
			Invoke ("PlayLoudspeaker", todayyousortGuy.length);
		} else if (AudioController.instance.musicSource.clip == todayyousortGuy){
			AudioController.instance.PlaySingle (intoAGuy, AudioController.instance.musicSource);
			Invoke ("PlayLoudspeaker", intoAGuy.length + .1f);
		} else if (AudioController.instance.musicSource.clip == intoAGuy){
			StartCoroutine ("ReadObjects");
		}
	}

	IEnumerator ReadObjects (){
		yield return new WaitForSeconds (.5f);
		for (int i = 0; i < objectsToSortGuy.Length; i++) {
			AudioController.instance.PlaySingle (objectsToSortGuy [i], AudioController.instance.musicSource);

			yield return new WaitForSeconds (1 + objectsToSortGuy [i].length);
		}
	}



	public int amountOfObjects;
	public GameObject[] objPool;
	public List<GameObject> objectToSort = new List<GameObject>();
	public bool GetRandomObjects;
	void MakeObjectList(){
		//3 different objects 
		if (GetRandomObjects) {
			for (int i = 0; i < amountOfObjects; i++) {
				int randomObjectNumber = Random.Range (0, objPool.Length);
				objectToSort.Add (objPool [randomObjectNumber]);
			}
		}
	}

	public GameObject[] containers;
	public bool GetRandomRules;
	void MakeSortingRules(){
		//4 rules generated per container
		if (GetRandomRules) {
			foreach (GameObject container in containers) {
				int ruleNumber = Random.Range (0, 4);
				if (ruleNumber == 0) {
					container.GetComponentInChildren<SortDestroyer> ().color = RandomColor ();
				} else if (ruleNumber == 1) {
					container.GetComponentInChildren<SortDestroyer> ().obj = RandomObj ();
				} else if (ruleNumber == 2) {
					container.GetComponentInChildren<SortDestroyer> ().audioName = RandomAudio ();
				} else if (ruleNumber == 3) {
					container.GetComponentInChildren<SortDestroyer> ().defective = RandomDefect ();
				} 
			}
		}
	}

	public int amountOfColors;
	string RandomColor(){
		int randInt = Random.Range (0, 4);
		if (randInt == 0) {
			return "Red";
		} else if (randInt == 1) {
			return "Blue";
		} else if (randInt == 2) {
			return "Yellow";
		} else if (randInt == 3) {
			return "White";
		}

		return "";
	}

	string RandomObj(){
		int randInt = Random.Range (0, 3);
		if (randInt == 0) {
			return "Toy";
		} else if (randInt == 1) {
			return "Kitchen";
		} else if (randInt == 2) {
			return "Office";
		}
		return "";
	}

	string RandomAudio(){
		int randInt = Random.Range (0, 2);
		if (randInt == 0) {
			return "Special";
		} else if (randInt == 1) {
			return "Normal";
		}
		return "";
	}

	bool RandomDefect(){
		int randInt = Random.Range (0, 2);
		if (randInt == 0) {
			return false;
		} else if (randInt == 1) {
			return true;
		} 
		return false;
	}

	public GameObject instructions;
	void UpdateInstructions(){
		TextMesh text = instructions.GetComponentInChildren<TextMesh> ();
		text.text = 
			"Hello World, \n" +
			"Welcome to the Factory! \n" +
			"Turn the dial to begin! \n"; 
		for (int i = 0; i < containers.Length; i++) {
			if (level == 0) {
				if (i == 0) {
					text.text += "\n" + "Light blue" + ": "; 
				} else if (i == 1) {
					text.text += "\n" + "Green" + ": "; 
				}
			}else if (level == 1){
				if (i == 0) {
					text.text += "\n" + "Green" + ": "; 
				} else if (i == 1) {
					text.text += "\n" + "Purple" + ": "; 
				} else if (i == 2) {
					text.text += "\n" + "White" + ": "; 
				} 
			}
			SortDestroyer sort = containers[i].GetComponentInChildren<SortDestroyer> ();
			if (sort.color != "") {
				text.text += sort.color + ". ";
			}
			if (sort.audioName != ""){
				text.text += sort.audioName + ". ";
			}
			if (sort.obj != ""){
				text.text += sort.obj + ". ";
			}
			if (sort.defective != false){
				text.text += sort.defective.ToString() + ". ";
			}
		}
	}

	public GameObject mark;
	Vector3 markStart;
	// Update is called once per frame
	void UpdateMorale () {
		morale = Mathf.Clamp (morale, 0, 100f);

		if (morale < 10) {
			mark.transform.localPosition = new Vector3 (markStart.x, mark.transform.localPosition.y, mark.transform.localPosition.z);
		} else if (morale < 20) {
			mark.transform.localPosition = new Vector3 (markStart.x - .07f, mark.transform.localPosition.y, mark.transform.localPosition.z);
		} else if (morale < 30) {
			mark.transform.localPosition = new Vector3 (markStart.x - .15f, mark.transform.localPosition.y, mark.transform.localPosition.z);
		} else if (morale < 40) {
			mark.transform.localPosition = new Vector3 (markStart.x - .23f, mark.transform.localPosition.y, mark.transform.localPosition.z);
		} else if (morale < 50) {
			mark.transform.localPosition = new Vector3 (markStart.x - .31f, mark.transform.localPosition.y, mark.transform.localPosition.z);
		} else if (morale < 60) {
			mark.transform.localPosition = new Vector3 (markStart.x - .39f, mark.transform.localPosition.y, mark.transform.localPosition.z);
		} else if (morale < 70) {
			mark.transform.localPosition = new Vector3 (markStart.x - .47f, mark.transform.localPosition.y, mark.transform.localPosition.z);
		} else if (morale < 80) {
			mark.transform.localPosition = new Vector3 (markStart.x - .55f, mark.transform.localPosition.y, mark.transform.localPosition.z);
		} else if (morale < 90) {
			mark.transform.localPosition = new Vector3 (markStart.x - .63f, mark.transform.localPosition.y, mark.transform.localPosition.z);
		}
	}

	int sortCount = 0;
	int posCount = 0;
	public void Sort(GameObject obj){
		sortCount += 1;
		posCount += 1;
		if (posCount == 3) {
			AudioController.instance.RandomizeSfx (AudioController.instance.musicSource, positiveRemarks);
			posCount = 0;
		}
		score += scoreBonus;
		morale += moraleBonus;
		scoreDisplay.text = score.ToString();
		UpdateMorale ();
	}

	int sortWrongCount = 0;
	int negCount = 0;
	public float moraleBonus;
	public void SortedWrong (){
		sortWrongCount += 1;
		negCount += 1;
		if (negCount == 3) {
			AudioController.instance.RandomizeSfx (AudioController.instance.musicSource, negativeRemarks);
			negCount = 0;
		}
		if (sortWrongCount == 20) {
			morale -= moraleBonus;
			sortWrongCount = 0;
		}
		score -= scoreWrongBonus;
		scoreDisplay.text = score.ToString ();
		UpdateMorale ();
	}
}
