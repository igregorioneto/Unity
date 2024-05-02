using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Transform groundCheck;
    private float groundCheckRadius = 0.2f;  
    private Animator animator;  

    private void MovePlayer()
    {
        if (groundCheck == null)
        {
            return;
        }

        // Verifica se o personagem esta no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float moveDirection = 0f;
        if (moveDirection == 0)
        {
            animator.SetBool("isGrounded", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
            animator.SetBool("isRunning", true);
        }
        
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);

        // Virar o sprite para a direção correta
        if (moveDirection != 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * moveDirection;
            transform.localScale = localScale;
        }

        if (isGrounded && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                        
        }
        else if (isGrounded && moveDirection == 0)
        {
            animator.SetBool("isGrounded", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        groundCheck = transform.Find("GroundCheck");
        animator = GetComponent<Animator>();
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck não encontrado! Certifique-se de que um objeto chamado 'GroundCheck' está presente como filho do Player.");
        }
    }

    void Update()
    {
        MovePlayer();
    }

}
