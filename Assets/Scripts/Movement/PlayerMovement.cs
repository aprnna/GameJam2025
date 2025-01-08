using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public float speed;
    public float horizontalInput;

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
            animator.SetBool("is_Walking", true);
        }
        if (horizontalInput == 0)
        {
            animator.SetBool("is_Walking", false);
        }
        
        Vector2 movement = new Vector2(horizontalInput, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
