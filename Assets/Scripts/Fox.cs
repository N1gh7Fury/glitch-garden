using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Animator animator;
    private Attacker attacker;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Defender>())
        {
            return;
        }    
        if (obj.GetComponent<Stone>())
        {
            animator.SetTrigger("jump trigger");
        } else
        {
            animator.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
