using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turtle : MonoBehaviour
{
    //Массив точек куда можно идти(точнее комнат в которых эти точки)
    [SerializeField] private GameObject PointArray;
    /*********************************/
    /**/private NavMeshAgent agent;/**/
    /*********************************/

    //я злюся но ты ещё можешь меня остановить
    private bool rage = false;

    //ну всё тебе пиздец
    private bool Rage = false;

    //Просто таймер
    private float timer;

    [SerializeField][Range(0,3600)]private int StayOnStart = 0;

    //где находится комната героя
    [SerializeField] private GameObject Hero;
    //Это материалы которые я использовал для отладки и наглядности агра
    [SerializeField] private Material TestG;
    [SerializeField] private Material TestY;
    [SerializeField] private Material TestR;
    //тест режим
    [SerializeField] private bool test = false;
    void Start()
    {
        //у меня дежавю...

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
        //если дошли и мы обиделись что на нас не обратили внимания. и дошли то бежим в комнату полтарашки
        if (agent.remainingDistance <= agent.stoppingDistance && rage && !Rage)
        {
            //берём любую позицию в комнате игрока
            agent.SetDestination(Hero.transform.GetChild(Random.Range(0,Hero.transform.childCount)).position);

            //нас теперь не остановить
            Rage = true;

            //Красим в красный если тест
            if(test)
            gameObject.GetComponent<Renderer>().material = TestR;
        }

        //если мы дошли, но на нас не обратили внимания, то обижаемся
        if (agent.remainingDistance <= agent.stoppingDistance && !rage && !Rage)
        {
            //опять дежавю...
            //я объяснял уже ес что
            int a = Random.Range(0, PointArray.transform.childCount);
            agent.SetDestination(PointArray.transform.GetChild(a).GetChild(Random.Range(0, PointArray.transform.GetChild(a).childCount)).position);

            //обижаемся
            rage = true;

            //если тестим то тогда ещё и красим в жёлтый
            if(test)
            gameObject.GetComponent<Renderer>().material = TestY;
        }
        //if()
    }
    //Если мы попали в поле зрения и отобразились на мониторе то вызывается этот метод
    /*private void OnBecameVisible()
    {
        //ладно не обижаюсь, но это пока
        rage = false;

        //Остановим его пыл
        agent.speed = 0f;

        //если тест то красим в зелёный
        if(test)
        gameObject.GetComponent<Renderer>().material = TestG;
    }
    //когда перестали видеть
    private void OnBecameInvisible()
    {
        //Ну ок пусть ходит раз мы его не видим
        agent.speed = 3.5f;
        
    }*/
    public bool IsObjectVisible( UnityEngine.Camera @this, Renderer renderer)
    {
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(@this), renderer.bounds);
    }
}
