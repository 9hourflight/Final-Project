using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject crow;
    [SerializeField] public int activeCrows;
    private float xUpper = 5f;
    private float xLower = -18f;
    private float zUpper = 20f;
    private float zLower = -2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnCrow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnCrow()
    {
        yield return new WaitForSeconds(12);
        InstantiateCrow();

    }

    void InstantiateCrow()
    {
        Vector3 spawnPos = new Vector3(Random.Range(xLower, xUpper), 0, (Random.Range(zLower, zUpper)));
        Instantiate(crow, spawnPos, crow.transform.rotation);
        activeCrows++;
    }
}
