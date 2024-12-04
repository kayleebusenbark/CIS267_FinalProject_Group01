using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CyclopsAI : MonoBehaviour
{
    public float cyclopsSpeed = 1f;
    public float stopDistance = .4f;
    public float cyclopsFollowingDistance = 1f;

    public Level02EnemyHealth cyclopsHealth;

    public GameObject laserPrefab;

    private bool isFiringLaser = false;
    private bool isWalking = false;
    //private bool isThrowingRock = false;
    //private bool isStomping = false;

    private PlayerController player;

    private Animator animator;

    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FollowPlayer()
    {

    }

    //private void StompAtPlayer()
    //{

    //}

    private void ShootLaser()
    {
        if (stopDistance == .4f) 
        {
            isFiringLaser = true;
        }
    }

    //private void ThrowRock()
    //{

    //}
    
    private void CyclopsIsDead()
    {
    }
}
