using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleCard : MonoBehaviour
{
    [SerializeField] private Image artWorkMask;
    [SerializeField] private Text nameText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Image artworkImage;
    [SerializeField] private Text manaText;

    private GameObject cards;
    private int cant;
    private Text txtCantCards;
    public bool selected;

    [Header("POS AND SCALE")]
    private float posX;
    private float posY;
    private float scaleX;
    private float scaleY;
    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    public void Init(string name, string description, Sprite art, int manaCant)
    {
        nameText.text = name;
        descriptionText.text = description;
        artworkImage.sprite = art;
        if (manaCant == 0)
            manaText.text = "X";
        else
            manaText.text = manaCant.ToString();
    }
    void Start()
    {
        cant = 0;
        cards = GameObject.Find("Cards");
        txtCantCards = GameObject.Find("HUD/Paper/txtCantCards").GetComponent<Text>();
        artWorkMask.color = new Color(90, 90, 90);
        boxCollider2D = GetComponent<BoxCollider2D>();
        posX = transform.position.x;
        posY = transform.position.y;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        selected = false;
    }
    public void Contador()
    {
        int temp = 0;
        for (int i = 0; i < cards.transform.childCount; i++)
        {
            if (cards.transform.GetChild(i).GetComponent<ScaleCard>().selected)
            {
                temp++;
            }
        }
        if (temp > cant || temp < cant)
        {
            cant = temp;
            txtCantCards.text = "" + cant;
            if (cant >= 6 && cant <= 10)
                txtCantCards.color = new Color(42/255f, 164f/255f, 0f);
            else
                txtCantCards.color = new Color(1f, 0f, 0f);
        }
        //Debug.Log(cant);
    }
    private void OnMouseEnter()
    {
        if (!Globals.pauseActive)
            transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
    }
    private void OnMouseExit()
    {
        if (!Globals.pauseActive)
            transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
    private void OnMouseDown()
    {
        if (!Globals.pauseActive)
        {
            selected = !selected;
            Globals.saveDeck = false;
            Contador();
        }
    }
    private void OnMouseUp()
    {
        if (!Globals.pauseActive)
        {
            if (selected)
                gameObject.transform.GetChild(4).gameObject.SetActive(selected);
            else if (!selected)
                gameObject.transform.GetChild(4).gameObject.SetActive(selected);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
