using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiePath : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    Transform startPoint,endPoint;


    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        startPoint = GameObject.Find("Start Enemie Points").transform;
        endPoint = GameObject.FindGameObjectWithTag("Finish").transform;
    }

    void Update() => myNavMeshAgent.SetDestination(endPoint.position);
    
    public void HasReachedEndPoint() => transform.position = startPoint.position;

    public void DisableAISystem()
    {
        myNavMeshAgent.enabled = false;
        this.enabled = false;
    }

}
