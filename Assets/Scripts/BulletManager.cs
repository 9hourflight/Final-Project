using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
        else
        {
            StartCoroutine(DespawnBullet());
        }
    }
    IEnumerator DespawnBullet()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
