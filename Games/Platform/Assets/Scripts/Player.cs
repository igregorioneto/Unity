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

        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
        }
        
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);

        // Virar o sprite para a direção correta
        if (moveDirection != 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * moveDirection;
            transform.localScale = localScale;
        }

        // Verifica se o personagem esta no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Controlar a animação do personagem
        animator.SetBool("idle", isGrounded);
        animator.SetBool("run", moveDirection != 0);
        animator.SetBool("jump", !isGrounded);

        if (isGrounded && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
