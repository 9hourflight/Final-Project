using UnityEngine;

public class TissuesManager : MonoBehaviour
{
    [SerializeField] public GameObject player;
    private float playerTissues;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GetComponent<Player>();
        playerTissues = player.GetComponent<PlayerControls>().playerTissues;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            playerTissues += 10;
            Debug.Log(playerTissues);
        }
    }
}
