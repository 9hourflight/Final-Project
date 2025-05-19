using System.IO;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class AiController : MonoBehaviour
{
    [SerializeField] Animator birdAnimator;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] int currentPathIndex = 0;
    [SerializeField] private Transform[] path;
    private bool isDead;
    [SerializeField] float despawnTime;
    [SerializeField] public AudioClip birdSounds;
    [SerializeField] private AudioSource birdAudioSource;
    [SerializeField] public float birdsShot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdAnimator = GetComponent<Animator>();
        //birdAudioSource = GetComponent<AudioSource>();
        isDead = false;
        despawnTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isDead)
        {
            if (agent.remainingDistance < .00001f)
            {
                agent.SetDestination(path[currentPathIndex++].position);
                birdAnimator.SetBool("isFlying", true);

                if (currentPathIndex >= path.Length)
                {
                    currentPathIndex = 0;
                }
            }
        }
        else if (isDead)
        {
            agent.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            birdAnimator.SetBool("die", true);
            isDead = true;
            birdsShot++;
            birdAudioSource.PlayOneShot(birdSounds, 1f);
            StartCoroutine(DespawnBird());
            //WaitForSecondsRealTime(despawnTime);

        }
            
    }
    IEnumerator DespawnBird()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
