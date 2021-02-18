using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanShit : MonoBehaviour
{
    //Массив Cumер которые есть на карте (заполняется ручками)
    [SerializeField] private GameObject[] Cums = new GameObject[7];

    //Главный Cum, иначе Cum на лице перса
    [SerializeField] private GameObject MainCum;

    //Активная камеры 
    public int CumNum = 0;

    //Ну а это табличные значения не трож убъёт
    [SerializeField] GameObject Canvas;//ссылка на канвас
    [SerializeField] private GameObject MyUI;//панель планшета с кнопочками пост эффектом(ужасным)
    [SerializeField] private GameObject Hero;//ну и наша полторашка

    private void Update()
    {
        //Выход по нажатию Выхода ;)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Exit();
        }
    }
    //то что вызывается при открывании планшета
    public void Interact()
    {
        //Запоминаем главную камеру
        MainCum = Hero.transform.GetChild(0).gameObject;

        // минус лицо
        MainCum.SetActive(false);

        // плюс камера
        Cums[CumNum].SetActive(true);

        //Отключаем всё, весь канвас к херам
        for(int i = 0; i < Canvas.transform.childCount; i++)
        {
            Canvas.transform.GetChild(i).gameObject.SetActive(false);
        }
        //а не вот эту UI надо оставить было
        MyUI.SetActive(true);

        //Включаем курсор
        Cursor.lockState = CursorLockMode.Confined;

        //Сонный паралич у перса
        Hero.GetComponent<ControllerDurochka>().enabled = false;
        Debug.Log("Ну поднял и что?");
    }
    //метод листания влево
    public void Left()
    {
        //разбирайся сам я устал объяснять
        if (CumNum == 0)
        {
            Cums[0].SetActive(false);
            Cums[6].SetActive(true);
            CumNum = 6;
            Debug.Log("Влево (Так ещё и через границу)");
            Debug.Log(CumNum);
        }
        else
        {
            Cums[CumNum].SetActive(false);
            Cums[CumNum - 1].SetActive(true);
            CumNum -= 1;
            Debug.Log("Влево");
            Debug.Log(CumNum);
        }
    }
    //метод листания вправо
    public void Right()
    {
        //там в методе влево написано
        if (CumNum == 6)
        {
            Cums[6].SetActive(false);
            Cums[0].SetActive(true);
            CumNum = 0;
            Debug.Log("неВлево (Так ещё и через границу)");
            Debug.Log(CumNum);
        }
        else
        {
            Cums[CumNum].SetActive(false);
            Cums[CumNum + 1].SetActive(true);
            CumNum += 1;
            Debug.Log("неВлево");
            Debug.Log(CumNum);
        }
    }
    //выход с планшета
    private void Exit()
    {
        //лечим паралич
        Hero.GetComponent<ControllerDurochka>().enabled = true;

        //минус камера
        Cums[CumNum].SetActive(false);

        //плюс лицо
        MainCum.SetActive(true);

        //включаем прицел и отключаем UI планшета
        Canvas.transform.GetChild(0).gameObject.SetActive(true);
        Canvas.transform.GetChild(1).gameObject.SetActive(false);

        //Возьми себя в руки наглядно
        Cursor.lockState = CursorLockMode.Locked;

        //Отключаем скрипт чтобы не мешался
        this.enabled = false;
        Debug.Log("Почему планшет так близко?");
    }
    public void Turn(int Cum)
    {
        if (Cum >= Cums.Length)
        {
            Debug.LogError("Цифоркой промахнулся. Я столько камер не знаю(");
            Exit();
        }

        Cums[CumNum].SetActive(false);
        Cums[Cum].SetActive(true);
        CumNum = Cum;
        Debug.Log("Переключил на камеру " + CumNum);
    }
}
