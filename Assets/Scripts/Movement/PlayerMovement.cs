using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    public float speed;
    public float horizontalInput;
    private bool isCharging;
    public Vector2 movement;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            spriteRenderer.flipX = horizontalInput < 0;
        }
        
        if(!isCharging & horizontalInput != 0)
        {
            movement = new Vector2(horizontalInput, 0) * speed * Time.deltaTime;
            transform.Translate(movement);
            animator.SetBool("is_Walking", true);
        }
        else
        {
            animator.SetBool("is_Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("is_Rolling", true);
             isCharging = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("is_Rolling", false);
            isCharging = false;
        }
    }
}
