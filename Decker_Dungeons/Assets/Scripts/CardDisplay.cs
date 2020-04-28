using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;
    public Text manaText;
    public GameObject manaGroup;

    [Header("POS AND SCALE")]
    private float posX;
    private float posY;
    private float scaleX;
    private float scaleY;
    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
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
    }
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(2.5f, 2.5f, 1f);
        transform.position = new Vector3(posX, -0.75f, 0f);
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
                Debug.Log("Usted no tiene mana");
            }
            else if (Globals.p1CantMana > 0)
            {
                switch (card.name)
                {
                    case "Fire Nova":
                        Globals.p1CantMana = Globals.p1Mana;
                        if (Globals.p1Mana < 4) Globals.p1NoMana = true;
                        else
                        {
                            Globals.p1Mana -= 4;
                            Globals.e1Life -= 30;
                            Globals.p1ManaPosX -= 4;//1 de pos * 2 (cantidad de mana perdido)
                            Debug.Log(Globals.p1ManaPosX);
                        }
                        break;
                    case "Dropplet of Life":
                        if (Globals.p1Mana < 3) Globals.p1NoMana = true;
                        else
                        {
                            Globals.p1CantMana = Globals.p1Mana;
                            Globals.p1Mana -= 3;
                            Globals.p1Life += 20;
                            Globals.p1ManaPosX -= 3;//1 de pos * 2 (cantidad de mana perdido)
                            Debug.Log(Globals.p1ManaPosX);
                        }
                        break;
                    case "Fireball":
                        if (Globals.p1Mana < 2) Globals.p1NoMana = true;
                        else
                        {
                            Globals.p1CantMana = Globals.p1Mana;
                            Globals.e1Life -= 20;
                            Globals.p1Mana -= 2;
                            Globals.p1ManaPosX -= 2;//1 de pos * 1 (cantidad de mana perdido)
                            Debug.Log(Globals.p1ManaPosX);
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
            Debug.Log("you can attack, it's enemy's turn");
        }
        else if (Globals.p1NoMana)
        {
            Debug.Log("you need more mana");
            Globals.p1NoMana = false;
        }
        else if (Globals.p1NoMana == false && Globals.p1CanAttack)
        {
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
            Debug.Log(Globals.p1CantMana);
        }
    }
}