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
