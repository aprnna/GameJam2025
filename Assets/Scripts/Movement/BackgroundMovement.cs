using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    // public float speedDelay;
    // public GameObject player;
    // private Status playerStatus;
    // private PlayerMovement playerScript;

    private Transform playerTransform; // Referensi ke objek player
    public float parallaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("player");
        playerTransform = player.transform;
        // playerStatus = player.GetComponent<Status>(); 
        // playerScript = player.GetComponent<PlayerMovement>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (playerTransform.transform.position.x * (parallaxSpeed));
        transform.position = new Vector3(distance, transform.position.y, transform.position.z);
    }
}
