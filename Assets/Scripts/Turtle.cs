using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turtle : MonoBehaviour
{
    [SerializeField] private GameObject PointArray;
    private NavMeshAgent agent;
    [SerializeField] private bool MoveInStart = false;
    private bool Rage = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (MoveInStart)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
        }
    }
}
