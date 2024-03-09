using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    [SerializeField] private float movementSpeed, rotateSpeed, jumpForce, groundCheckDistance;
    [SerializeField] private Animator animator;
    public Stat_script stat;
    private Rigidbody rb;
    private bool isOnGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stat.ResetAll();
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

        rb.velocity = Vector3.up * rb.velocity.y + transform.forward * inputY * movementSpeed;
        transform.eulerAngles += Vector3.up * inputX * rotateSpeed;
        animator.SetFloat("inputX", inputX);
        animator.SetFloat("inputY", inputY);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("jump");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, groundCheckDistance))
            isOnGround = true;
    }
}
