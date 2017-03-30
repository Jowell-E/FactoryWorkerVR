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
	public int score = 0;
	public int scoreBonus = 10;
	// Use this for initialization
	void Start () {
		MakeObjectList ();
		MakeSortingRules ();
	}

	public int amountOfObjects;
	public GameObject[] objPool;
	public List<GameObject> objectToSort = new List<GameObject>();
	void MakeObjectList(){
		//3 different objects 
		for (int i = 0; i < amountOfObjects; i++) {
			int randomObjectNumber = Random.Range (0, objPool.Length);
			objectToSort.Add (objPool [randomObjectNumber]);
		}

	}

	public GameObject[] containers;
	void MakeSortingRules(){
		//4 rules generated per container
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

	public int amountOfColors;
	string RandomColor(){
		int randInt = Random.Range (0, 5);
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

	// Update is called once per frame
	void Update () {
		
	}

	public void Sort(GameObject obj){
		score += scoreBonus;
		scoreDisplay.text = score.ToString();

	}

	public void SortedWrong (){
		score -= scoreBonus;
		scoreDisplay.text = score.ToString ();
	}
}
