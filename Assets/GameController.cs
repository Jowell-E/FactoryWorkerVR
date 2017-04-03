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



	public Text scoreDisplay;
	public float score = 0;
	public float scoreBonus = .5f;
	public float scoreWrongBonus = .75f;
	public float morale = 0;
	// Use this for initialization
	void Start () {
		MakeObjectList ();
		MakeSortingRules ();
		UpdateInstructions ();
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
		TextMesh text = instructions.GetComponent<TextMesh> ();
		text.text = 
			"Hello World, \n" +
			"Welcome to the Factory! \n" +
			"Press the button to begin! \n"; 
		for (int i = 0; i < containers.Length; i++) {
			text.text += "\n" + (i+1).ToString () + ": "; 
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

	// Update is called once per frame
	void Update () {
		
	}

	int sortCount = 0;
	public void Sort(GameObject obj){
		sortCount += 1;
		score += scoreBonus;
		scoreDisplay.text = score.ToString();

	}

	int sortWrongCount = 0;
	public void SortedWrong (){
		sortWrongCount += 1;
		if (sortWrongCount == 20) {
			morale -= .5f;
			sortWrongCount = 0;
		}
		score -= scoreWrongBonus;
		scoreDisplay.text = score.ToString ();
	}
}
