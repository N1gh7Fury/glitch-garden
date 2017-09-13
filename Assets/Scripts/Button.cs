using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    private Button[] buttonArray;
    public static GameObject selectedDefender;
    private Text costText;

	// Use this for initialization
	void Start () {
        costText = GetComponentInChildren<Text>();
        buttonArray = GameObject.FindObjectsOfType<Button>();

        if (!costText)
        {
            Debug.LogWarning("cant find costText of " + name);
        }
        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
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
