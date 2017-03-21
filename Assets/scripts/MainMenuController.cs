using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public GameManger gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startScenario1Clicked () {
		gameManager.startScenario1();
		Debug.Log ("Scenario 1");
	}

	public void startScenario2Clicked() {
		gameManager.startScenario2();
		Debug.Log ("Scenario 2");
	}

	public void startDiamondBreakClicked() {
		gameManager.startDiamondBreak ();
		Debug.Log ("Diamond Break");
	}

	public void startTriangleBreakClicked() {
		gameManager.startTriangleBreak ();
		Debug.Log ("triangle break");
	}
}
