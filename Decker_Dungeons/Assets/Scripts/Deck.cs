using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Deck : MonoBehaviour
{
    [SerializeField] private Text txtTitle;
    /*[SerializeField] private Card card1;
    [SerializeField] private Card card2;
    [SerializeField] private Card card3;*/
    //public List<Card> decklist;
    private int count;
    private int last;
    private Card temp;
    private void Awake()
    {
        /*Globals.decklist.Add(card1);
        Globals.decklist.Add(card2);
        Globals.decklist.Add(card3);
        Globals.decklist.Add(card1);
        Globals.decklist.Add(card2);
        Globals.decklist.Add(card3);
        Globals.decklist.Add(card1);
        Globals.decklist.Add(card2);
        Globals.decklist.Add(card3);*/
        count = Globals.decklist.Count;
        last = count - 1;

        Shuffle();
    }

    public void Shuffle()
    {
        for (int i = 0; i < count / 2; ++i)
        {
            int pos = UnityEngine.Random.Range(0, last);
            temp = Globals.decklist[i];
            Globals.decklist[i] = Globals.decklist[pos];
            Globals.decklist[pos] = temp;

            pos = UnityEngine.Random.Range(0, last);
            temp = Globals.decklist[last - i];
            Globals.decklist[last - i] = Globals.decklist[pos];
            Globals.decklist[pos] = temp;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Debug.Log("card " + i + ": " + Globals.decklist[i].name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Globals.changeCards)
        {
            Globals.changeCards = false;
            if (Globals.cont < Globals.decklist.Count)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).gameObject.name == "Card 1" || transform.GetChild(i).gameObject.name == "Card 2" ||
                        transform.GetChild(i).gameObject.name == "Card 3")
                    {
                        if (transform.GetChild(i).gameObject.activeSelf == false)
                        {
                            transform.GetChild(i).gameObject.SetActive(true);
                        }
                    }
                }
            }
            else if (Globals.cont >= Globals.decklist.Count)
            {
                txtTitle.text = "You don't have more cards";
                txtTitle.gameObject.SetActive(true);
                //Debug.Log("You don't have more cards");
            }
        }
    }
}
