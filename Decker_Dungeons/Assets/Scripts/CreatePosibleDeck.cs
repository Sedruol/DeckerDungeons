using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePosibleDeck : MonoBehaviour
{
    //[SerializeField] private GameObject card;
    [SerializeField] private ScaleCard scaleCardPrefab;
    [SerializeField] private Card card1;
    [SerializeField] private Card card2;
    [SerializeField] private Card card3;
    [SerializeField] private Card card4;
    [SerializeField] private Card card5;
    [SerializeField] private Card card6;
    [SerializeField] private Card card7;
    [SerializeField] private Card card8;
    [SerializeField] private Card card9;
    [SerializeField] private Card card10;
    [SerializeField] private Card card11;
    [SerializeField] private Card card12;

    private float initialX;
    private float posX;
    private float initialY;
    private float posY;
    private bool newRow;

    private void Awake()
    {
        initialX = -6.945f;
        initialY = 2f;
        newRow = false;
        if (Globals.PosibleDeckList.Count == 0)
        {
            Globals.PosibleDeckList.Add(card1);
            Globals.PosibleDeckList.Add(card2);
            Globals.PosibleDeckList.Add(card3);
            Globals.PosibleDeckList.Add(card4);
            Globals.PosibleDeckList.Add(card5);
            Globals.PosibleDeckList.Add(card6);
            Globals.PosibleDeckList.Add(card7);
            Globals.PosibleDeckList.Add(card8);
            Globals.PosibleDeckList.Add(card9);
            Globals.PosibleDeckList.Add(card10);
            Globals.PosibleDeckList.Add(card11);
            Globals.PosibleDeckList.Add(card12);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        posX = initialX;
        posY = initialY;
        //GameObject c;
        ScaleCard scard;
        for(int i = 0; i < Globals.PosibleDeckList.Count; i++)
        {
            if (i == 5)
                newRow = true;
            else if (i > 5)
            {
                if (newRow)
                {
                    posX = initialX;
                    newRow = false;
                    posY -= 3.75f;
                }
            }
            //De forma muy pero muy cochina
            //c = Instantiate(card, new Vector3(posX, posY, 0f), Quaternion.identity, this.gameObject.transform);
            /*c.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite =
                Globals.PosibleDeckList[i].artWork;*/

            //esto es menos cochino :u
            /*c.GetComponent<ScaleCard>().artworkImage.sprite = Globals.PosibleDeckList[i].artWork;
            c.GetComponent<ScaleCard>().nameText.text = Globals.PosibleDeckList[i].name;
            c.GetComponent<ScaleCard>().descriptionText.text = Globals.PosibleDeckList[i].description;
            c.GetComponent<ScaleCard>().manaText.text = Globals.PosibleDeckList[i].manaCost.ToString();*/

            //esto es mucho menos cochino
            scard = Instantiate(scaleCardPrefab, new Vector3(posX, posY, 0f), Quaternion.identity, this.gameObject.transform);
            scard.Init(Globals.PosibleDeckList[i].name, Globals.PosibleDeckList[i].description, Globals.PosibleDeckList[i].artWork,
                Globals.PosibleDeckList[i].manaCost);
            posX += 2.778f;
        }
    }
}