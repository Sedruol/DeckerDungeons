using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPortal : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject player;
    private int nextLevel; //que tipo de sala sera la siguiente
    private int roomSelected; //cual de las posibles salas del tipo seleccionado sera escogida
    private int actualRoom;
    private bool canMove;

    private void Awake()
    {
        nextLevel = Random.Range(0, 2); //0 o 1
        Debug.Log("funca");
        if (SceneManager.GetActiveScene().name == "Exploration")
            actualRoom = 0;
        if (actualRoom == 0 || actualRoom == 1)
            nextLevel = 1;
        else if (actualRoom == 2 || actualRoom == 3)
            nextLevel = 0;
    }
    void Start()
    {
        canMove = false;
        //0: sala sin enemigos
        if (nextLevel == 0)
        { 
            //0: sala vacia, 1: sala con mercader, 2: sala con tienda
            roomSelected = Random.Range(0, 2);
            while(roomSelected == actualRoom)
                roomSelected = Random.Range(0, 2);
        }
        //1: sala con enemigo
        else if (nextLevel == 1)
        {
            roomSelected = Random.Range(2, 4); //2 o 3
            while (roomSelected == actualRoom)
                roomSelected = Random.Range(0, 2);
        }
    }
    private void OnMouseDown()
    {
        canMove = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canMove = false;
        Debug.Log("holi");
        if(collision.gameObject.layer == 12)
        {
            Debug.Log(roomSelected);
            /*if(roomSelected == 2)
            {
                Debug.Log(roomSelected);
                SceneManager.LoadScene("Level 1");
            }*/
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
            float step = speed * Time.deltaTime;
            player.transform.position = Vector2.MoveTowards(new Vector2(player.transform.position.x, player.transform.position.y),
                new Vector2(transform.position.x, transform.position.y), step);
        }
    }
}
