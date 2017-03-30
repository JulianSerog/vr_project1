using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MovingScript : MonoBehaviour {

    public GameObject player;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller;

    Vector2 touchpad;

    private float sensitivityX = 1.5F;
    private Vector3 playerPos;


    // Use this for initialization
    void Start() {
        controller = gameObject.GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update() {
        device = SteamVR_Controller.Input((int)controller.index);
        //If finger is on touchpad
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Read the touchpad values
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);


            // Handle movement via touchpad
            
                // Move Forward
                player.transform.position += player.transform.forward * Time.deltaTime * (-touchpad.x * 5f);
				player.transform.position += player.transform.right * Time.deltaTime * (touchpad.y * 5f);

                // Adjust height to terrain height at player positin
                playerPos = player.transform.position;
				if(Terrain.activeTerrain != null)
					playerPos.y = Terrain.activeTerrain.SampleHeight (player.transform.position);
		

                player.transform.position = playerPos;
        }//if
    }//update
}//class