using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variable
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private float groundDrag;

    [Header("GroundCheck")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask whatIsGround;
    bool grounded;

    public static Movement instance;
    [SerializeField] private Transform orientation;
    private float horInput;
    private float verInput;

    private Vector3 direction;

    private Rigidbody rb;

    #endregion

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        InputEqualer();
        SpeedController();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void InputEqualer()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        direction = orientation.forward * verInput + orientation.right * horInput;

        rb.AddForce(direction.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedController()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
