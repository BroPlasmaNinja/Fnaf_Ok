using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public bool door = true;// тру=закрыто фолз=открыто
    public bool use = false; // юзали кнопку или нет
    [SerializeField] GameObject Doorm;//где дверь? вот дверь
    [SerializeField] Material op;//Зелёный
    [SerializeField] Material cl;//Красный
    void Start()
    {
        //Просто изначально делаем открытой чел
    }

    void Update()
    {
        if (door == false && use == true)
        {
            Doorm.GetComponent<Animation>().Play("close door");
            door = true;
            use = false;
            gameObject.GetComponent<Renderer>().material = cl;
        }
        if (door == true && use == true)
        {
            Doorm.GetComponent<Animation>().Play("open door");
            door = false;
            use = false;
            gameObject.GetComponent<Renderer>().material = op;
        }
    }
    public void Turn()
    {
        if(Doorm.transform.position.y >= 10f|| Doorm.transform.position.y <= 3.2f)
        use = true;
    }
}
