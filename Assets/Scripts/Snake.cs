using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Snake : MonoBehaviour
{
    //Массив точек по которым они могут ходить
    [SerializeField] private GameObject PointArray;

    //Время которое он стоит при старте
    [SerializeField] [Range(0, 3600)] private int StayOnStart;

    //Время которое он стоит в комнате
    [SerializeField] [Range(0, 3600)] private int StayOnPos;

    //Таймер
    private float timer = 0;

    /*********************************/
    /**/private NavMeshAgent agent;/**/
    /*********************************/

    void Start()
    {
        //просто нужно
        //ибо это ссылка на нав меш агента
        agent = GetComponent<NavMeshAgent>();

        //таймер равен времен которое мы должны ждать при старте
        timer = StayOnStart;

        //если время при старте равно 0 то вот
        if (timer == 0)
        {
            //запоминаем комнату в которую идём
            int a = Random.Range(0, PointArray.transform.childCount);

            //собственно берём любую позицию в комнате
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);

            //таймер равен времени ожидания при переходах
            timer = StayOnPos;
        }
    }

    void Update()
    {
        //дошли но таймер пока не равен нулю
        if (agent.remainingDistance <= agent.stoppingDistance && timer > 0)
            timer -= Time.deltaTime;

        //если дошли и таймер равен 0 то идём в другое место
        if (agent.remainingDistance <= agent.stoppingDistance && timer <= 0)
        {
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);
            timer = StayOnPos;
        }
        

    }
}
