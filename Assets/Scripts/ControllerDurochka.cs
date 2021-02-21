using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDurochka : MonoBehaviour
{
    //Это сенса мыши подёргай чтобы норм было
    [SerializeField][Range(0f,100000f)]private float sensa = 100f;

    /************************/
    /*Это табличные значения*/
    /*    Только тронь      */
    /* и узнаешь приятный ли*/
    /*    хвост ящерки ;)   */
    /************************/

    /*************************************************/
    /****************/float RotX = 0f;/***************/
    /*****/public CharacterController controllor;/****/
    /*****************/RaycastHit hit;/***************/
    /*********/private bool planShit = false;/********/
    /********/private bool InPlanShit = false;/*******/
    /**/[SerializeField] private GameObject Canvas;/**/
    /*************************************************/

    //Это скорость перса
    [SerializeField][Range(0.0000001f,299792458f)] private float speed = 12f;

    //ну а это длина его руки
    [SerializeField][Range(0.01f,9999f)]private float lenghtOfHand = 5f;

    //Запоминаем где на карте планшет
    private GameObject ps;

    //Чисто для некоторых тестов
    [SerializeField] private bool Test = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        

        #region RotOfCumAndHero

        //Это(( ^ )) просто чтобы скрывать ибо удобно

        /************************************************************/
        /*Это чудо-юдо-рыба-CUM или по нормальному камера контреллер*/
        /*            контролит cumеру поворот ес точнее            */
        /************************************************************/
        float mouseX = Input.GetAxis("Mouse X") * sensa * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensa * Time.deltaTime;

        RotX -= mouseY;

        RotX = Mathf.Clamp(RotX, -80f, 80f);

        gameObject.transform.GetChild(0).transform.localRotation = Quaternion.Euler(RotX, 0f, 0f);
        transform.Rotate(0,mouseX,0);
        /**********************************/
        /*Это перемещение нашей полторашки*/
        /*        или как там его         */
        /**********************************/
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;
        if(!Input.GetKey(KeyCode.LeftShift))
            controllor.Move(move * speed * Time.deltaTime);
        else
            controllor.Move(move * speed * Time.deltaTime*1.5f);
        #endregion
        /************************************************/
        /*А здеся интерактив ПРИРКИНЬ. ВЗАИМОДЕЙСТВИЕ!!!*/
        /*    У нас можно нажимать кнопочки в мире      */
        /************************************************/
        if (!Test)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //Я сам хз как райкаст работает, НО он работает так что не трож 
                if (Physics.Raycast(gameObject.transform.GetChild(0).GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), gameObject.transform.GetChild(0).transform.forward, out hit, lenghtOfHand))
                {
                    //проверяем на скрипт планшет объект в который попал райкаст
                    if (hit.transform.GetComponent<PlanShit>() != null)
                    {
                        //зачемтоздесьстоит
                        planShit = true;

                        //ну дэб баг
                        Debug.LogWarning("ОПАСНО!!!! Игрок поднял планшет");

                        //планшет пропал не осезаем но он существует в 16-ом измерении
                        ps = hit.transform.gameObject;
                        ps.GetComponent<MeshRenderer>().enabled = false;
                        ps.GetComponent<BoxCollider>().enabled = false;
                    }
                    if (hit.transform.GetComponent<Door>() != null)
                    {
                        hit.transform.GetComponent<Door>().Turn();
                    }
                }
            }

            //Alt+F4 чтобы достать планшет
            if (Input.GetKeyDown(KeyCode.Space) && planShit == true)
            {
                //тут и так понятно
                Debug.Log("Поднеми планшет");
                ps.GetComponent<PlanShit>().enabled = true;
                ps.GetComponent<PlanShit>().Interact();
            }
        }
    }
}
