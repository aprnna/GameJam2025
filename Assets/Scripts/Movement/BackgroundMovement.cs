using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    // public float speedDelay;
    // public GameObject player;
    // private Status playerStatus;
    // private PlayerMovement playerScript;

    public Transform player; // Referensi ke objek player
    public float parallaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindWithTag("player");
        // playerStatus = player.GetComponent<Status>(); 
        // playerScript = player.GetComponent<PlayerMovement>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position.x * (1 - parallaxSpeed));
        transform.position = new Vector3(distance, transform.position.y, transform.position.z);
    }
}
