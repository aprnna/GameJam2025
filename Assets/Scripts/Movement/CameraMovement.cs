using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Tentukan posisi yang diinginkan untuk kamera, tetap di sumbu Z kamera
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);

        // Lerp untuk perpindahan halus kamera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Perbarui posisi kamera
        transform.position = smoothedPosition;
    }
}
