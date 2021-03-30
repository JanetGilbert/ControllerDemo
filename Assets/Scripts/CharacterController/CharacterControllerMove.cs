using UnityEngine;
using System.Collections;


// Character controller player input script.
public class CharacterControllerMove : MonoBehaviour
{
    // Cache
    CharacterController characterController;
    public Animator animator;

    // Set in editor
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;

    // Controls
    private Vector3 moveDirection = Vector3.zero;
    private float xMove;
    private float yMove;
    private bool jump;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
       

    }

    private void FixedUpdate()
    {
        animator.SetBool("Grounded", characterController.isGrounded);

        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(xMove, 0.0f, yMove);
            moveDirection *= speed;

            // Face in direction of movement.
            if (moveDirection.magnitude > float.Epsilon)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }

            animator.SetFloat("MoveSpeed", moveDirection.magnitude);

            if (jump)
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.fixedDeltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.fixedDeltaTime);

    }

    // Player input should be registered in Update() because FixedUpdate may not update every frame.
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        jump = Input.GetButton("Jump");
    }

}