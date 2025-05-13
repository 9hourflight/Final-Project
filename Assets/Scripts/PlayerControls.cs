using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private CharacterController controller;
    private Camera playerCamera;
    [SerializeField]
    float speed;
    float horizontalInput;
    float verticalInput;
    [SerializeField]
    private float turnSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        //controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
       
        transform.Translate((Vector3.forward * speed) * Time.deltaTime * verticalInput);
        transform.Translate((Vector3.right * speed) * Time.deltaTime * horizontalInput);
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput);
        playerCamera.transform.Rotate( -mouseY, 0,  0);
        transform.Rotate(0, mouseX, 0);
        //transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
    }
}
