using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject PointArray;
    private NavMeshAgent agent;
    [SerializeField] private float timer = 60;
    private float tim = 0f;
    [SerializeField] private bool MoveInStart = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        tim = timer;

        if (MoveInStart)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tim<0)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0,PointArray.transform.GetChild(a).childCount)).position);
            tim = timer;
        }
        tim -= Time.deltaTime;
    }
}
