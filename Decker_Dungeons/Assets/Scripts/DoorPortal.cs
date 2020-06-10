﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPortal : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject player;
    private Animator anim;
    private int nextLevel; //que tipo de sala sera la siguiente
    private int roomSelected; //cual de las posibles salas del tipo seleccionado sera escogida
    private int actualRoom;
    private bool canMove;
    private string roomName;

    private void Awake()
    {
        anim = player.GetComponent<Animator>();
        roomName = SceneManager.GetActiveScene().name;
        nextLevel = Random.Range(0, 2); //0 o 1
        Debug.Log("funca");
        if (roomName == "Exploration")
            actualRoom = 2;
        else if (roomName == "Level 1")
            actualRoom = 3;
        else if (roomName == "Level 2")
            actualRoom = 4;
        /*if (actualRoom == 0 || actualRoom == 1)
            nextLevel = 1;
        else if (actualRoom == 2 || actualRoom == 3)
            nextLevel = 0;*/
    }
    void Start()
    {
        canMove = false;
        //0: sala sin enemigos
        if (nextLevel == 0)
        {
            //0: sala con curacion, 1: sala con mercader, 2: sala vacia, 
            roomSelected = Random.Range(2, 3);//solo sala vacia(temporal)
            while (roomSelected == actualRoom)//si es igual, debe ser otra de las posibles del mismo tipo
                roomSelected = Random.Range(3, 5);//temporal, solo mandara a las de enemigos
        }
        //1: sala con enemigo
        else if (nextLevel == 1)
        {
            //3: enemy lvl1, 4: enemy lvl2
            roomSelected = Random.Range(3, 5); //3 o 4
            while (roomSelected == actualRoom)
                roomSelected = Random.Range(3, 5);
        }
    }
    private void OnMouseDown()
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canMove = false;
        anim.SetBool("move", false);
        nextLevel = Random.Range(0, 2);
        if (roomName == "Exploration")
            actualRoom = 2;
        else if (roomName == "Level 1")
            actualRoom = 3;
        else if (roomName == "Level 2")
            actualRoom = 4;
        if (nextLevel == 0)
        {
            //0: sala vacia, 1: sala con curacion, 2: sala con mercader
            roomSelected = Random.Range(2, 3);//solo sala vacia(temporal)
            while (roomSelected == actualRoom)//si es igual, debe ser otra de las posibles del mismo tipo
                roomSelected = Random.Range(3, 5);//temporal, solo mandara a las de enemigos
        }
        //1: sala con enemigo
        else if (nextLevel == 1)
        {
            //3: enemy lvl1, 4: enemy lvl2
            roomSelected = Random.Range(3, 5); //3 o 4
            while (roomSelected == actualRoom)
                roomSelected = Random.Range(2, 5);
            Debug.Log("holi");
        }
        if (collision.gameObject.layer == 12)
        {
            Debug.Log(roomSelected);
            if (roomSelected == 2)
            {
                Debug.Log(roomSelected);
                SceneManager.LoadScene("Exploration");
            }
            else if (roomSelected == 3)
            {
                Debug.Log(roomSelected);
                SceneManager.LoadScene("Level 1");
            }
            else if (roomSelected == 4)
            {
                Debug.Log(roomSelected);
                SceneManager.LoadScene("Level 2");
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
            float step = speed * Time.deltaTime;
            player.transform.position = Vector2.MoveTowards(new Vector2(player.transform.position.x, player.transform.position.y),
                new Vector2(transform.position.x, transform.position.y), step);
        }
    }
}