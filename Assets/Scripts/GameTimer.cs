using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour {

    private GameObject winLabel;
    public float levelSeconds = 10;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        winLabel = GameObject.Find("Win Label");
        if (!winLabel)
        {
            Debug.LogWarning("cant find win label");
        }

        winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        slider.value =  (Time.timeSinceLevelLoad / levelSeconds);

        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        DestoryAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void DestoryAllTaggedObjects()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("DestroyOnWin");
        foreach(GameObject taggedObject in taggedObjects)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
