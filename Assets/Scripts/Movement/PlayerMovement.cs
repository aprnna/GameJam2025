using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    public Status status;
    public float horizontalInput;
    private bool isCharging;
    private bool isRolling;
    public Vector2 movement;
    public float cooldownDuration = 2f;
    public float cooldownTimer;
    public bool isOnCooldown = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        status = GetComponent<Status>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mengambil nilai arah horizontal
        horizontalInput = Input.GetAxis("Horizontal");

        // Untuk membalik arah sprite bila karakter ke arah kiri atau kanan
        if (horizontalInput != 0)
        {
            spriteRenderer.flipX = horizontalInput < 0;
        }
        
        // Untuk proses berjalan
        if(!isCharging & horizontalInput != 0 & !isRolling)
        {
            walking();
        }

        // Untuk proses dash
        else if(isRolling & horizontalInput != 0)
        {
            dashDirection();
        }

        // Untuk proses bila tidak jadi dash
        else if(horizontalInput == 0 & isRolling)
        {
            dashCancel();
        }

        // Jika berhenti berjalan
        else
        {
            animator.SetBool("is_Walking", false);
        }

        // Untuk proses charged attack
        if (Input.GetKeyDown(KeyCode.Space) & !isRolling & !isOnCooldown)
        {
            charged();
        }

        // Untuk proses inisialisasi dash
        if(Input.GetKeyUp(KeyCode.Space) & !isRolling & isCharging)
        {
            dashInit();
        }    

        // Untuk cooldown charged attack
        if(isOnCooldown)
        {
            dashCooldown();
        }
    }

    // Method-Method Control

    // Method untuk proses berjalan
    public void walking()
    {
        movement = new Vector2(horizontalInput, 0) * status.speed * Time.deltaTime;
        transform.Translate(movement);
        animator.SetBool("is_Walking", true);
    }

    // Method untuk melakukan charged attack
    public void charged()
    {
        animator.SetBool("is_Rolling", true);
        isCharging = true;
    }

    // Method untuk mengisi nilai-nilai tertentu saat melakukan dash
    public void dashInit()
    {
        cooldownTimer = cooldownDuration;
        status.dashspeed = 25f;
        isCharging = false;
        isRolling = true;
    }

    // Method untuk mengarahkan dash
    public void dashDirection()
    {
        movement = new Vector2(horizontalInput, 0) * status.speed * status.dashspeed * Time.deltaTime;
        transform.Translate(movement);

        if (status.dashspeed > 1f)
        {
            status.dashspeed = status.dashspeed - 0.5f;
            isOnCooldown = true;
        }
        else
        {
            isRolling = false;
            animator.SetBool("is_Rolling", false);
        }
    }

    // Method bila saat melakukan charged attack tidak mengarahkan arah horizontal
    public void dashCancel()
    {
        isRolling = false;
        status.dashspeed = 1f;
        animator.SetBool("is_Rolling", false);
    }

    // Method untuk proses cooldown melakukan charged attack
    public void dashCooldown()
    {
        cooldownTimer -= Time.deltaTime; 
        if (cooldownTimer <= 0)
        {
            isOnCooldown = false;
            cooldownTimer = 0;
        }
    }
}
