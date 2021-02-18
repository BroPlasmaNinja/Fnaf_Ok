using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public bool door = true;// тру=закрыто фолз=открыто
    public bool use = false; // юзали кнопку или нет
    [SerializeField] GameObject Doorm;//где дверь? вот дверь
    [SerializeField] Material op;
    [SerializeField] Material cl;
    void Start()
    {
        Doorm.GetComponent<Animation>().Play("open door");// со старта открываем
        door = false;// подтверждаем что дверь открыта
    }

    // Update is called once per frame
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
        use = true;
    }
}
