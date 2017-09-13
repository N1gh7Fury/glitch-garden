using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile;
    private GameObject projectileParent;
    public GameObject gun;
    private Animator animator;
    private Spawner laneSpawner;

    private void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        SetMyLaneSpawner();
    }

    void SetMyLaneSpawner()
    {
        Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
        foreach(Spawner spawner in spawners)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                laneSpawner = spawner;
                return;
            }
        }
        Debug.LogError("Cant find spawner in lane");
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true); 
        } else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    
    private bool IsAttackerInLane()
    {
        if(laneSpawner.transform.childCount <= 0)
        {
            return false;
        } 
        
        foreach(Transform child in laneSpawner.transform)
        {
            if(child.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
