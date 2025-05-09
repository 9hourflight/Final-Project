using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    [SerializeField]
    float speed;
    float horizontalInput;
    float verticalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
       
        transform.Translate((Vector3.forward * speed) * Time.deltaTime * verticalInput);
        transform.Translate((Vector3.right * speed) * Time.deltaTime * horizontalInput);
    }
}
