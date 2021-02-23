using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Snake : MonoBehaviour
{
    //Массив точек по которым они могут ходить
    [SerializeField] private GameObject PointArray;

    /*********************************/
    /**/private NavMeshAgent agent;/**/
    /*********************************/

    void Start()
    {
        //просто нужно
        //ибо это ссылка на нав меш агента
        agent = GetComponent<NavMeshAgent>();

        //запоминаем комнату в которую идём
        int a = Random.Range(0, PointArray.transform.childCount);

        //собственно берём любую позицию в комнате
        agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
    }

    void Update()
    {
        //если дошли то идём в другое место
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
        }
    }
}
