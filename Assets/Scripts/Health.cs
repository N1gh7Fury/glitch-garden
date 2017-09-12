using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health;

    public void DealDamage(float damage)
    {
        health -= damage;  
        if(health < 0)
        {
            DestoryObject();
        }
    }

    public void DestoryObject()
    {
        Destroy (gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
