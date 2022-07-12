using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCarControllerSystems : MonoBehaviour
{
    [Header("Car Controller Variables")]
    [SerializeField] float forwardSpeed = 0;
    public Transform target;
    public float distance;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = new Vector3(target.position.x - 1f,0, target.position.z - 0.5f);
        agent.speed = forwardSpeed;
    }
}
