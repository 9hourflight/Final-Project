using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    [SerializeField] Animator birdAnimator;
    [SerializeField] NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
