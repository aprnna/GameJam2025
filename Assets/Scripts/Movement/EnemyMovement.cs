using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float dashDistance = 14f;
    public float cooldown = 3f;
    public float cooldownTimer = 3f;
    public bool isCooldown = true;
    public bool isDash = false;
    public int direction = 0;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer.flipX = false;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(isCooldown == false)
        {
            if(direction == 0)
            {
                transform.Translate(Vector2.left * speed * dashDistance * Time.deltaTime);
                isDash = true;
                DashManager();
            }

            else if(direction == 1)
            {
                transform.Translate(Vector2.right * speed * dashDistance * Time.deltaTime);
                isDash = true;
                DashManager();
            }
        }

        else if(isCooldown == true)
        {
            CoolDown();
        }
    }

    public void CoolDown()
    {
        cooldown -= Time.deltaTime; 
        if (cooldown <= 0)
        {
            isCooldown = false;
            isDash = false;
            cooldown = 0;
            cooldown = cooldownTimer;
        }
    }

    public void DashManager()
    {
        if(dashDistance == 17f)
        {
            animator.SetTrigger("Attack_Trigger");
        }
        if(dashDistance != 0f)
        {
            dashDistance -= 1f;
        }

        else if (dashDistance == 0f)
        {
            isCooldown = true;
            dashDistance = 17f;
            if(direction == 0)
            {
                direction = 1;
                spriteRenderer.flipX = true;
            }
            else if(direction == 1)
            {
                direction = 0;
                spriteRenderer.flipX = false;
            }
        }
    }

    
    
}