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
        manaText.text = manaCant.ToString();
    }
    void Start()
    {
        artWorkMask.color = new Color(90, 90, 90);
        boxCollider2D = GetComponent<BoxCollider2D>();
        posX = transform.position.x;
        posY = transform.position.y;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        selected = false;
    }
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
    private void OnMouseDown()
    {
        selected = !selected;
        Globals.saveDeck = false;
    }
    private void OnMouseUp()
    {
        if (selected)
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(selected);
        }
        else if (!selected)
            gameObject.transform.GetChild(4).gameObject.SetActive(selected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
