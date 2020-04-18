using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject manaGroup;
    private Button btn;
    private float posX;
    private float posY;
    private float scaleX;
    private float scaleY;
    private int cant;
    void Start()
    {
        cant = Globals.p1Mana;
        btn = GetComponent<Button>();
        posX = transform.position.x;
        posY = transform.position.y;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(2.5f, 2.5f, 1f);
        transform.position = new Vector3(posX, 0f, 0f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position = new Vector3(posX, posY, 1f);
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Globals.p1CanAttack)
        {
            if (cant == 0)
            {
                Globals.p1NoMana = true;
                Debug.Log("Usted no tiene mana");
            }
            else if (cant > 0)
            {
                switch (btn.image.sprite.name)
                {
                    case "cards_0":
                        Globals.p1Mana -= 1;
                        Globals.p1Agility += 10;
                        Globals.p1ManaPosX -= 1;//1 de pos * 1 (cantidad de mana perdido)
                        Debug.Log(Globals.p1ManaPosX);
                        break;
                    case "cards_1":
                        Debug.Log("uno");
                        Globals.p1Mana -= 2;
                        Globals.p1Life += 20;
                        Globals.p1ManaPosX -= 2;//1 de pos * 2 (cantidad de mana perdido)
                        Debug.Log(Globals.p1ManaPosX);
                        break;
                    case "cards_2":
                        Globals.e1Life -= 20;
                        Globals.p1Mana -= 2;
                        Globals.p1ManaPosX -= 2;//1 de pos * 2 (cantidad de mana perdido)
                        Debug.Log(Globals.p1ManaPosX);
                        break;
                }
            }
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    { 
        if(Globals.p1CanAttack == false)
        {
            Debug.Log("you can attack, it's enemy's turn");
        }
        else if (Globals.p1NoMana == false && Globals.p1CanAttack)
        {
            btn.gameObject.SetActive(false);
            Globals.p1CanAttack = false;
            Globals.e1CanAttack = true;
        }
    }
    private void Update()
    {
        while (Globals.p1Mana < cant)
        {
            Destroy(manaGroup.transform.GetChild(cant - 1).gameObject);
            cant--;
            Debug.Log(cant);
        }
    }
}