using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private CharacterController controller;
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
        transform.rotation = Quaternion.Euler(0, yaw, 0);
        //loogeySpawn.localRotation = Quaternion.Euler(0, yaw, 0);
        loogeySpawn.localRotation = cameraArm.localRotation;
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        if(inputDirection.magnitude >= 0.1f)
        {
            Vector3 moveDirection = transform.right * inputDirection.x + transform.forward * inputDirection.z;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
          
            GameObject loogey = Instantiate(loogeyPrefab, loogeySpawn.transform.position, loogeySpawn.transform.localRotation);
            loogey.GetComponent<Rigidbody>().AddForce(loogeySpawn.forward * spitForce, ForceMode.Impulse); //is only going in one direction
            

        }

        characterAnimator.SetFloat("MoveX", inputDirection.x);
        characterAnimator.SetFloat("MoveY", inputDirection.z);
    }
}
