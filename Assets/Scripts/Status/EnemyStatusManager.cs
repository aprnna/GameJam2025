using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusManager : MonoBehaviour
{
    public Status status;
    public bool isTakingDamage; 
    public GameObject player;
    private PlayerMovement playerScript;

    void Start()
    {
        player = GameObject.FindWithTag("player");
        playerScript = player.GetComponent<PlayerMovement>(); 
        status = GetComponent<Status>();
        isTakingDamage = false;
    }

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && !isTakingDamage && playerScript.isRolling) 
        {
            isTakingDamage = true; 
            status.hitPoint -= 100; 
            Debug.Log("Got Hit");
            Invoke("ResetDamageFlag", 2f); // Delay damage taking for 2 seconds
        }
    }

    void ResetDamageFlag()
    {
        isTakingDamage = false; 
    }
}