﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject PointArray;
    private NavMeshAgent agent;
    [SerializeField] private bool MoveInStart = false;
    [SerializeField] [Range(0,3600)] private int Timer = 5;
    [SerializeField] [Range(0, 3600)] private int StayOnStart = 0;
    private float tim;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();


        if (MoveInStart)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
            tim = Timer;
        }
        else
        {
            tim = StayOnStart;
        }
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && tim >= 0)
        {
            tim -= Time.deltaTime;
        }
        if (agent.remainingDistance <= agent.stoppingDistance && tim <= 0)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
            tim = Timer;
        }
    }
}
