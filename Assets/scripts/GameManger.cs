using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

    public GameObject triangleBreakBtn;
    public GameObject DiamondBreakBtn;
    public GameObject scenario1Btn;
    public GameObject scenario2Btn;



    //TODO: add raycast and point & click triggers to setup game



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//TODO: remove all pool balls and set up scenarios appropriately
	public void startScenario1 () {
		//load scene layout
		Debug.Log("scenario 1 started");
		Application.LoadLevel("scenario1");
	}

	public void startScenario2() {
		//load scene layout
		Debug.Log("scenario 2 started");
		Application.LoadLevel("scenario2");
	}

	public void startDiamondBreak() {
		//load diamond break layout
		Debug.Log("diamond break started");
		Application.LoadLevel("diamondBreak");
	}

	public void startTriangleBreak() {
		//load Triangle Break Layout
		Debug.Log("triangle break started");
		Application.LoadLevel("triangleBreak");
	}
}