using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 3f;
    public float runSpeed = 5f;
    public float turnSmoothTime;
    public float actionTime = 1f;
    float turnSmoothVelocity;
    float moveSpeed = 0f;

    bool walkButton;
    bool attackButton;
    bool ableToMove = true;
    public bool canAttack = true;

    public Transform cam;
    Vector2 input;
    Rigidbody rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        MyInputs();
        Movement();
    }

    void MyInputs() {
        if (ableToMove)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            input = Vector2.ClampMagnitude(input, 1);

            anim.SetFloat("speed", input.magnitude);

            walkButton = Input.GetKey(KeyCode.LeftShift);
            attackButton = Input.GetKey(KeyCode.Space);

            if (walkButton) {
                moveSpeed = baseSpeed;
                anim.SetBool("isWalking", true); 
            } else {
                moveSpeed = runSpeed;
                anim.SetBool("isWalking", false); 
            }

            if (attackButton && canAttack) {
                StartCoroutine("ResetAttackCooldown");
            } else {
                anim.SetBool("isAttacking", false); 
            }
        }
    }

    void Movement() {
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;

        // Normalize the camera angle
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;

        // Controlling the rotation based on camera angle
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        // Start Moving
        if (ableToMove)
        {
            Vector3 yVelocity = new Vector3(0, rb.velocity.y, 0);
            rb.velocity = input.x * camRight * moveSpeed + input.y * camForward * moveSpeed + yVelocity;
        }
    }

    public IEnumerator Dead() {
        ableToMove = false;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator ResetAttackCooldown() {
        anim.SetBool("isAttacking", true);
        ableToMove = false;
        yield return new WaitForSeconds(.8f);
        anim.SetBool("isAttacking", false); 
        canAttack = true;
        ableToMove = true;
    }
}
