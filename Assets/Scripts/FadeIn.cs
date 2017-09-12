﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime;
    private Image fadePanel;
    private Color currentColor;

	// Use this for initialization
	void Start () {
        fadePanel = GetComponent<Image>();
        currentColor = fadePanel.color;
	}

    // Update is called once per frame
    void Update () {
		if(Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        } else
        {
            gameObject.SetActive(false);
        }
	}
}
