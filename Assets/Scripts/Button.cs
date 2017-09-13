using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    private Button[] buttonArray;
    private static GameObject selectedDefender;

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        foreach(Button button in buttonArray)
        {
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }
        selectedDefender = defenderPrefab;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
