﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    //public Card card;
    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;
    public Text manaText;
    public GameObject manaGroup;

    [SerializeField] private Text txtEnemy;
    [SerializeField] private Text txtTitle;
    private Card card;
    [Header("POS AND SCALE")]
    private float posX;
    private float posY;
    private float scaleX;
    private float scaleY;
    private BoxCollider2D boxCollider2D;

    private int posibleCritic;
    private int posibleEnemyEvaded;
    //private int cont;
    private bool changeCard;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Card 1")
            card = Globals.decklist[0];
        else if (gameObject.name == "Card 2")
            card = Globals.decklist[1];
        else if (gameObject.name == "Card 3")
            card = Globals.decklist[2];
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artWork;
        manaText.text = card.manaCost.ToString();

        boxCollider2D = GetComponent<BoxCollider2D>();

        Globals.p1CantMana = Globals.p1Mana;
        posX = transform.position.x;
        posY = transform.position.y;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;

        posibleCritic = 0;
        posibleEnemyEvaded = 0;
        //cont = 2;
        //Debug.Log("decklist: " + Globals.decklist.Count);
        changeCard = false;
        txtEnemy.gameObject.SetActive(false);
    }
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        transform.position = new Vector3(posX, posY+0.75f, 0f);
    }
    private void OnMouseExit()
    {
        transform.position = new Vector3(posX, posY, 1f);
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
    private void OnMouseDown()
    {
        if (Globals.p1CanAttack)
        {
            if (Globals.p1CantMana == 0)
            {
                Globals.p1NoMana = true;
                txtTitle.text = "You don't have mana";
                txtTitle.gameObject.SetActive(true);
                //Debug.Log("Usted no tiene mana");
            }
            else if (Globals.p1CantMana > 0)
            {
                posibleCritic = Random.Range(1, 100);
                posibleEnemyEvaded = Random.Range(1, 100);
                Debug.Log("enemy evaded: " + posibleEnemyEvaded);
                Debug.Log("player critico: " + posibleCritic);
                switch (card.name)
                {
                    case "Fire Nova":
                        if (Globals.p1Mana < 4) Globals.p1NoMana = true;
                        else
                        {
                            Globals.p1CantMana = Globals.p1Mana;
                            if (posibleEnemyEvaded > 3.5 * Globals.e1Agility)
                            {
                                if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                                {
                                    txtEnemy.text = "Critic!!!";
                                    txtEnemy.gameObject.SetActive(true);
                                    Globals.e1Life -= (20 * 1.5f);
                                }
                                else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                                    Globals.e1Life -= 20;
                            }
                            else if(posibleEnemyEvaded <= 3.5 * Globals.e1Agility)
                            {
                                txtEnemy.text = "Evaded!!!";
                                txtEnemy.gameObject.SetActive(true);
                            }
                            Globals.p1Mana -= 4;
                            Globals.p1ManaPosX -= 4;//1 de pos * 4 (cantidad de mana perdido)
                            //Debug.Log(Globals.p1ManaPosX);
                        }
                        break;
                    case "Dropplet of Life":
                        if (Globals.p1Mana < 3) Globals.p1NoMana = true;
                        else
                        {
                            Globals.p1CantMana = Globals.p1Mana;
                            Globals.p1Mana -= 3;
                            Globals.p1Life += 10;
                            //Globals.p1MaxLife += 20;
                            Globals.p1ManaPosX -= 3;//1 de pos * 3 (cantidad de mana perdido)
                            //Debug.Log(Globals.p1ManaPosX);
                        }
                        break;
                    case "Fireball":
                        if (Globals.p1Mana < 2) Globals.p1NoMana = true;
                        else
                        {
                            Globals.p1CantMana = Globals.p1Mana;
                            if (posibleEnemyEvaded > 3.5 * Globals.e1Agility)
                            {
                                if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                                {
                                    txtEnemy.text = "Critic!!!";
                                    txtEnemy.gameObject.SetActive(true);
                                    Globals.e1Life -= (10 * 1.5f);
                                }
                                else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                                    Globals.e1Life -= 10;
                            }
                            else if (posibleEnemyEvaded <= 3.5 * Globals.e1Agility)
                            {
                                txtEnemy.text = "Evaded!!!";
                                txtEnemy.gameObject.SetActive(true);
                            }
                            Globals.p1Mana -= 2;
                            Globals.p1ManaPosX -= 2;//1 de pos * 2 (cantidad de mana perdido)
                            //Debug.Log(Globals.p1ManaPosX);
                        }
                        break;
                }
            }
        }
    }
    private void OnMouseUp()
    {
        if (Globals.p1CanAttack == false)
        {
            txtTitle.text = "You can attack, it's enemy's turn";
            txtTitle.gameObject.SetActive(true);
            //Debug.Log("you can attack, it's enemy's turn");
        }
        else if (Globals.p1NoMana)
        {
            txtTitle.text = "You need more mana";
            txtTitle.gameObject.SetActive(true);
            //Debug.Log("you need more mana");
            Globals.p1NoMana = false;
        }
        else if (Globals.p1NoMana == false && Globals.p1CanAttack)
        {
            Globals.cont++;
            transform.position = new Vector3(posX, posY, 1f);
            transform.localScale = new Vector3(scaleX, scaleY, 1f);
            changeCard = true;
            this.gameObject.SetActive(false);
            Globals.p1CanAttack = false;
            Globals.e1CanAttack = true;
        }
    }
    private void Update()
    {
        if (Time.timeScale == 0)
            boxCollider2D.enabled = false;
        else if (Time.timeScale == 1)
            boxCollider2D.enabled = true;
        while (Globals.p1Mana < Globals.p1CantMana)
        {
            Destroy(manaGroup.transform.GetChild(Globals.p1CantMana - 1).gameObject);
            Globals.p1CantMana--;
            //Debug.Log(Globals.p1CantMana);
        }
        if (changeCard)
        {
            changeCard = false;
            card = Globals.decklist[Globals.cont];
            Debug.Log("contador: " + Globals.cont);
            nameText.text = card.name;
            descriptionText.text = card.description;
            artworkImage.sprite = card.artWork;
            manaText.text = card.manaCost.ToString();
        }
    }
}