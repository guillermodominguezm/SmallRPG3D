using UnityEngine;

public class Movement : MonoBehaviour
{
    private float inputX;
    private float inputY;
    private bool isRunning = false;
    private float gravityForce = -10.0f;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotSpeed = 10f;

    private CharacterController controller;
    private Animator animator;

    [SerializeField] private GameObject inventoryUI;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotSpeed * Time.deltaTime, 0);
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = transform.TransformDirection(move);

        if (move.magnitude > 0 && !isRunning)
        {
            animator.SetFloat("moveSpeed", 0.5f);

        }
        else
        {
            if (!isRunning)
            {
                animator.SetFloat("moveSpeed", 0f);
            }
        }

        move.y += gravityForce * Time.deltaTime;
        controller.Move(move * speed);
        transform.Rotate(rotation);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2;
            animator.SetFloat("moveSpeed", 1.0f);
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2;
            isRunning = false;
            //animator.SetFloat("moveSpeed", 0.5f);
            if (move.x > 0 || move.z > 0)
            {
                animator.SetFloat("moveSpeed", 0.5f);
            }
            else
            {
                animator.SetFloat("moveSpeed", 0f);
            }
        }

    }

}