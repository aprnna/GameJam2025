using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public Status status;
    public PlayerMovement playermovement;
    public bool isTakingDamage; 

    void Start()
    {
        status = GetComponent<Status>();
        playermovement = GetComponent<PlayerMovement>();
        isTakingDamage = false;
    }

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !playermovement.isRolling && !isTakingDamage && !playermovement.isCharging) 
        {
            isTakingDamage = true; 
            status.hitPoint -= 20; 
            Debug.Log("Got Hit");
            Invoke("ResetDamageFlag", 2f); // Delay damage taking for 2 seconds
        }
    }

    void ResetDamageFlag()
    {
        isTakingDamage = false; 
    }
}