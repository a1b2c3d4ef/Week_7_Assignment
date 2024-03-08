using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    [SerializeField] private float movementSpeed, jumpForce, groundCheckDistance;
    [SerializeField] private Animator animator;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
        Jump();
    }
    private void Movement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(inputX * movementSpeed, rb.velocity.y, inputY * movementSpeed);
        animator.SetFloat("inputX", inputX);
        animator.SetFloat("inputY", inputY);
    }
    private void Jump()
    {
        print(Physics.Raycast(transform.position, Vector3.down, groundCheckDistance));
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, groundCheckDistance))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("jump");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + Vector3.up * 0.5f, transform.position + Vector3.down * groundCheckDistance);
    }
}
