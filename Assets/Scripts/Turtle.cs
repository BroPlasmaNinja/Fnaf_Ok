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
    private bool rage = false;
    [SerializeField] private GameObject Hero;
    [SerializeField] private Material TestG;
    [SerializeField] private Material TestY;
    [SerializeField] private Material TestR;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (MoveInStart)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
        }
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && rage && !Rage)
        {
            agent.SetDestination(Hero.transform.position);
            Rage = true;
            gameObject.GetComponent<Renderer>().material = TestR;
        }
        if (agent.remainingDistance <= agent.stoppingDistance && !rage && !Rage)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
            rage = true;
            gameObject.GetComponent<Renderer>().material = TestY;
        }
    }
    private void OnBecameVisible()
    {
        rage = false;
        gameObject.GetComponent<Renderer>().material = TestG;
    }
}
