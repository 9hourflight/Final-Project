using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
            Debug.Log("zoo wee mama");
        }
        else if (collision.gameObject.CompareTag("floor"))
        {
            
        }
    }
}
