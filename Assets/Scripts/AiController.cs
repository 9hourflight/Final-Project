using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    [SerializeField] Animator birdAnimator;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] int currentPathIndex = 0;
    [SerializeField] private Transform[] path;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < .00001f)
        {
            agent.SetDestination(path[currentPathIndex++].position);
            birdAnimator.SetBool("isFlying", true);

            if (currentPathIndex >= path.Length)
            {
                currentPathIndex = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        birdAnimator.SetBool("die", true);
    }

}
