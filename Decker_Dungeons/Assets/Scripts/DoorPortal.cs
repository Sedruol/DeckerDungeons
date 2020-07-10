using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPortal : MonoBehaviour
{
    //[SerializeField] private float speed;
    [SerializeField] private GameObject player;
    [SerializeField] private float velocity;
    private Vector2 velocityVector;
    private Rigidbody2D rigidbody2D;
    private Animator anim;
    private Animator animPortal;
    private int nextLevel; //que tipo de sala sera la siguiente
    private int roomSelected; //cual de las posibles salas del tipo seleccionado sera escogida
    private int actualRoom;
    private bool canMove;
    private string roomName;

    private void IdleAnimation()
    {
        animPortal.SetBool("idle", true);
    }
    private void Awake()
    {
        animPortal = GetComponent<Animator>();
        rigidbody2D = player.GetComponent<Rigidbody2D>();
        velocityVector.x = velocity;
        anim = player.GetComponent<Animator>();
        roomName = SceneManager.GetActiveScene().name;
        nextLevel = Random.Range(0, 2); //0 o 1
        //Debug.Log("funca");
        /*if (roomName == "Exploration")
            actualRoom = 1;
        else if (roomName == "Level 1")
            actualRoom = 2;
        else if (roomName == "Level 2")
            actualRoom = 3;*/
        /*if (actualRoom == 0 || actualRoom == 1)
            nextLevel = 1;
        else if (actualRoom == 2 || actualRoom == 3)
            nextLevel = 0;*/
    }
    void Start()
    {
        canMove = false;
        animPortal.SetBool("idle", false);
        //0: sala sin enemigos
        /*if (nextLevel == 0)
        {
            //0: sala con curacion, 1: sala vacia
            roomSelected = Random.Range(1, 2);//solo sala vacia(temporal)
            while (roomSelected == actualRoom)//si es igual, debe ser otra de las posibles del mismo tipo
                roomSelected = Random.Range(2, 4);//temporal, solo mandara a las de enemigos
        }
        //1: sala con enemigo
        else if (nextLevel == 1)
        {
            //2: enemy lvl1, 3: enemy lvl2
            roomSelected = Random.Range(2, 4); //3 o 4
            while (roomSelected == actualRoom)
                roomSelected = Random.Range(2, 4);
        }*/
    }
    private void OnMouseDown()
    {
        if (!Globals.pauseActive)
        {
            if (Globals.firstLevel)
            {
                Globals.selectYourDeck = true;
                //Debug.Log("select your deck first");
            }
            else if (!Globals.firstLevel)
            {
                canMove = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canMove = false;
        anim.SetBool("move", false);
        nextLevel = Random.Range(0, 2);//0: sala pacifica, 1: sala de pelea
        Debug.Log(nextLevel);
        if (roomName == "Healing Room")
            actualRoom = 0;
        else if (roomName == "Exploration")
            actualRoom = 1;
        else if (roomName == "Level 1")
            actualRoom = 2;
        else if (roomName == "Level 2")
            actualRoom = 3;
        else if (roomName == "Level 3")
            actualRoom = 4;
        else if (roomName == "Level 4")
            actualRoom = 5;
        if (actualRoom != 0 && actualRoom != 1 && Globals.p1Life <= Globals.p1MaxLife / 2)
        {
                roomSelected = 0;
        }
        else
        {
            //0: sala pacifica
            if (nextLevel == 0)
            {
                if (actualRoom == 0 || actualRoom == 1 /*|| roomSelected = 0*/)
                {
                    //2: enemy lvl1, 3: enemy lvl2
                    if (!Globals.e1Died)//si el enemigo 1 esta vivo, enfrentalo
                        roomSelected = 2;
                    else if (Globals.e1Died && !Globals.e2Died)//si el enemigo 1 esta muerto y el 2 esta vivo, enfrenta a este ultimo
                        roomSelected = 3;
                    else if (Globals.e1Died && Globals.e2Died && !Globals.e3Died)
                        roomSelected = 4;
                    else if (Globals.e1Died && Globals.e2Died && Globals.e3Died && !Globals.e4Died)
                        roomSelected = 5;
                    //roomSelected = Random.Range(2, 4);//si estas en una sala pacifica, la siguiente debe ser de batalla
                }
                //0: sala con curacion, 1: sala vacia
                else
                    roomSelected = Random.Range(0, 2);//solo sala vacia(temporal), deberia ser (0,2)
            }
            //1: sala de batalla
            else if (nextLevel == 1)
            {
                //2: enemy lvl1, 3: enemy lvl2
                if (!Globals.e1Died)//si el enemigo 1 esta vivo, enfrentalo
                    roomSelected = 2;
                else if (Globals.e1Died && !Globals.e2Died)//si el enemigo 1 esta muerto y el 2 esta vivo, enfrenta a este ultimo
                    roomSelected = 3;
                else if (Globals.e1Died && Globals.e2Died && !Globals.e3Died)//si el enemigo 1 esta muerto y el 2 esta vivo, enfrenta a este ultimo
                    roomSelected = 4;
                else if (Globals.e1Died && Globals.e2Died && Globals.e3Died && !Globals.e4Died)
                    roomSelected = 5;
                /*roomSelected = Random.Range(2, 4); //3 o 4
                while (roomSelected == actualRoom)
                    roomSelected = Random.Range(1, 4);
                Debug.Log("holi");*/
            }
        }
        if (collision.gameObject.layer == 12)
        {
            //Debug.Log(roomSelected);
            if (roomSelected == 0)
            {
                //Debug.Log(roomSelected);
                SceneManager.LoadScene("Healing Room");
            }
            else if (roomSelected == 1)
            {
                //Debug.Log(roomSelected);
                SceneManager.LoadScene("Exploration");
            }
            else if (roomSelected == 2)
            {
                //Debug.Log(roomSelected);
                SceneManager.LoadScene("Level 1");
            }
            else if (roomSelected == 3)
            {
                //Debug.Log(roomSelected);
                SceneManager.LoadScene("Level 2");
            }
            else if (roomSelected == 4)
            {
                //Debug.Log(roomSelected);
                SceneManager.LoadScene("Level 3");
            }
            else if (roomSelected == 5)
            {
                //Debug.Log(roomSelected);
                SceneManager.LoadScene("Level 4");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            canMove = true;
        }*/
        if (canMove)
        {
            anim.SetBool("move", true);
            //Debug.Log(speed);
            /*player.transform.position = Vector2.MoveTowards(new Vector2(player.transform.position.x, player.transform.position.y),
                new Vector2(transform.position.x, transform.position.y), speed);*/

            rigidbody2D.velocity = velocityVector;
            /*player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, speed);
            Debug.Log(player.transform.position);
            Debug.Log(transform.position);*/
        }
    }
}
