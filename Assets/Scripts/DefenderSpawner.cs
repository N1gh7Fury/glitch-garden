﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject defenderParent;
    private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
        defenderParent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Vector2 position = SnapToGrid(CalculateSpawnPosition());
        GameObject selectedDefender = Button.selectedDefender;
        int defenderCost = selectedDefender.GetComponent<Defender>().starCost;
        if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            GameObject defender = Instantiate(selectedDefender, position, Quaternion.identity) as GameObject;
            defender.transform.parent = (defenderParent.transform);
        } else
        {
            Debug.Log("Insufficient stars");
        }

    }

    Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        return new Vector2(Mathf.RoundToInt(rawWorldPosition.x), Mathf.RoundToInt(rawWorldPosition.y));
    }

    Vector2 CalculateSpawnPosition()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
