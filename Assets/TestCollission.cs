using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollission : MonoBehaviour
{
    public Status status;

    public void Awake(){
        status = GetComponent<Status>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Got Hit");
            status.hitPoint = status.hitPoint - 10;
        }
    }
}
