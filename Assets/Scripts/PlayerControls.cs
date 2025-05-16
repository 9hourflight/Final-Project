using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
private CharacterController controller;
    private Camera playerCamera;
    [SerializeField] Transform cameraArm;
    [SerializeField] GameObject loogeyPrefab;
    [SerializeField] Transform loogeySpawn;
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private float speed;
    [SerializeField]
    private float spitForce = 1400;
    [SerializeField]
    private float yaw;
    [SerializeField]
    private float pitch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        characterAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 60f); //magic numbers

        cameraArm.localRotation = Quaternion.Euler(pitch, 0, 0);
        transform.localRotation = Quaternion.Euler(0, yaw, 0);
        loogeySpawn.localRotation = Quaternion.Euler(pitch, 0, 0);

        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        //cameraArm.Rotate( -mouseY, 0,  0);
        //transform.Rotate(0, mouseX, 0);
        if(inputDirection.magnitude >= 0.1f)
        {
            Vector3 moveDirection = transform.right * inputDirection.x + transform.forward * inputDirection.z;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
        
            GameObject loogey = Instantiate(loogeyPrefab, loogeySpawn.transform.position, loogeyPrefab.transform.rotation);
            loogey.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, spitForce, spitForce));

        }

        characterAnimator.SetFloat("MoveX", inputDirection.x);
        characterAnimator.SetFloat("MoveY", inputDirection.z);
    }
}
