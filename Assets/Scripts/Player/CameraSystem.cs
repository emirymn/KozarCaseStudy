using UnityEngine;


public class CameraSystem : MonoBehaviour
{
    public static CameraSystem instance;
    public Camera cam;
    [SerializeField] float sensX, sensY;

    [SerializeField] Transform orientation;
   

    private void Awake()
    {
        instance = this;
        cam = GetComponent<Camera>();
    }
    private float xRot, yRot;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    } 
}
