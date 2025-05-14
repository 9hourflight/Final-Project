using UnityEngine;

public class PlayerControls : MonoBehaviour
{
private CharacterController controller;
    private Camera playerCamera;
    [SerializeField] Transform cameraArm;
    [SerializeField] GameObject loogeyPrefab;
    [SerializeField] Transform loogeySpawn;
    private Rigidbody loogeyRb;
    private float speed;
    [SerializeField]
    float spitForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        loogeyRb = loogeyPrefab.GetComponent<Rigidbody>();
        loogeyRb.AddForce(transform.forward, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        cameraArm.Rotate( -mouseY, 0,  0);
        transform.Rotate(0, mouseX, 0);
        if(inputDirection.magnitude >= 0.1f)
        {
            Vector3 moveDirection = transform.right * inputDirection.x + transform.forward * inputDirection.z;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(loogeyPrefab, loogeySpawn.transform.position, loogeyPrefab.transform.rotation);
            
        }
    }
}
