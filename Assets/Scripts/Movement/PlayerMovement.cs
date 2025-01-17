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
    private bool isRolling;
    public Vector2 movement;
    public float dashspeed = 1f;

    public float cooldownDuration = 2f;
    public float cooldownTimer;
    public bool isOnCooldown = false;

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
        
        if(!isCharging & horizontalInput != 0 & !isRolling)
        {
            movement = new Vector2(horizontalInput, 0) * speed * Time.deltaTime;
            transform.Translate(movement);
            animator.SetBool("is_Walking", true);
        }

        else if(isRolling & horizontalInput != 0)
        {
            movement = new Vector2(horizontalInput, 0) * speed * dashspeed * Time.deltaTime;
            transform.Translate(movement);

            if (dashspeed > 1f)
            {
                dashspeed = dashspeed - 0.5f;
                isOnCooldown = true;
            }
            else
            {
                isRolling = false;
                animator.SetBool("is_Rolling", false);
            }
        }

        else if(horizontalInput == 0 & isRolling)
        {
            isRolling = false;
            dashspeed = 1f;
            animator.SetBool("is_Rolling", false);
        }

        else
        {
            animator.SetBool("is_Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) & !isRolling & !isOnCooldown)
        {
            animator.SetBool("is_Rolling", true);
            isCharging = true;
        }

        if(Input.GetKeyUp(KeyCode.Space) & !isRolling & isCharging)
        {
            cooldownTimer = cooldownDuration;
            dashspeed = 25f;
            isCharging = false;
            isRolling = true;
        }    

        if(isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime; 
            if (cooldownTimer <= 0)
            {
                isOnCooldown = false;
                cooldownTimer = 0;
            }
        }
    }
}
