using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

	public MainMenuController mainMenu;
	public Camera initialCamera;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startScenario1 () {
		//set menu and current camera to false
		mainMenu.gameObject.SetActive(false);
		initialCamera.gameObject.SetActive(false);

		//load scene layout

	}

	public void startScenario2() {
		//set menu and current camera to false
		mainMenu.gameObject.SetActive(false);
		initialCamera.gameObject.SetActive(false);

		//load scene layout
	}

	public void startDiamondBreak() {
		//set menu and current camera to false
		mainMenu.gameObject.SetActive(false);
		initialCamera.gameObject.SetActive(false);


		//load diamond break layout
	}

	public void startTriangleBreak() {
		//set menu and current camera to false
		mainMenu.gameObject.SetActive(false);
		initialCamera.gameObject.SetActive(false);

		//load Triangle Break Layout
	}

	public void backToMainMenu() {
		//set other items to inactive


		//set main menu and initial camera active
		mainMenu.gameObject.SetActive(true);
		initialCamera.gameObject.SetActive(true);
	}
}
