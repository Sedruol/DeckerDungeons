using System.Collections;
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

    [SerializeField] private Image mask;
    [SerializeField] private GameObject Player;
    [SerializeField] private Text txtEnemy;
    [SerializeField] private Text txtTitle;
    private Card card;
    [Header("POS AND SCALE")]
    private float posX;
    private float posY;
    private float scaleX;
    private float scaleY;
    private BoxCollider2D boxCollider2D;
    private Animator anim;

    private int posibleCritic;
    private int posibleEnemyEvaded;
    //private int cont;
    private bool changeCard;
    // Start is called before the first frame update
    void Start()
    {
        mask.gameObject.SetActive(false);
        if (gameObject.name == "Card 1")
            card = Globals.decklist[0];
        else if (gameObject.name == "Card 2")
            card = Globals.decklist[1];
        else if (gameObject.name == "Card 3")
            card = Globals.decklist[2];
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artWork;
        if (card.manaCost == 0)
            manaText.text = "X";
        else
            manaText.text = card.manaCost.ToString();

        boxCollider2D = GetComponent<BoxCollider2D>();
        anim = Player.GetComponent<Animator>();

        Globals.p1CantMana = Globals.p1Mana;
        posX = transform.position.x;
        posY = transform.position.y;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;

        posibleCritic = 0;
        posibleEnemyEvaded = 0;
        Globals.cont = 2;
        //Debug.Log("decklist: " + Globals.decklist.Count);
        changeCard = false;
        txtEnemy.gameObject.SetActive(false);
    }
    private void OnMouseEnter()
    {
        if (!Globals.pauseActive)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            transform.position = new Vector3(posX, posY + 1.5f, 0f);
        }
    }
    private void OnMouseExit()
    {
        if (!Globals.pauseActive)
        {
            transform.position = new Vector3(posX, posY, 1f);
            transform.localScale = new Vector3(scaleX, scaleY, 1f);
        }
    }
    private void OnMouseDown()
    {
        if (!Globals.pauseActive)
        {
            if (Globals.p1CanAttack)//cambiar por Globals.p1CanAttack si no funca
            {
                //if (Globals.p1CanUseCard)
                //{
                    if (Globals.p1CantMana == 0)
                    {
                        Globals.p1NoMana = true;
                        txtTitle.text = "You don't have mana";
                        txtTitle.gameObject.SetActive(true);
                        //Debug.Log("Usted no tiene mana");
                    }
                    else if (Globals.p1CantMana > 0)
                    {
                        posibleCritic = Random.Range(0, 100);
                        posibleEnemyEvaded = Random.Range(0, 100);
                        //Debug.Log("enemy evaded: " + posibleEnemyEvaded);
                        //Debug.Log("player critico: " + posibleCritic);
                        switch (card.name)
                        {
                            case "Arrow Barrage":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    Globals.p1CantMana = Globals.p1Mana;
                                    //el enemigo no esquiva el ataque
                                    if (posibleEnemyEvaded > 1.5 * Globals.eTAgility)
                                    {
                                        if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                                        {
                                            txtEnemy.text = "Critic!!!";
                                            txtEnemy.gameObject.SetActive(true);
                                            //efecto de la carta
                                            Globals.eTLife -= (card.dmg * 1.5f);
                                        }
                                        else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                                            Globals.eTLife -= card.dmg; //efecto de la carta
                                    }
                                    //el enemigo esquiva el ataque
                                    else if (posibleEnemyEvaded <= 1.5 * Globals.eTAgility)
                                    {
                                        txtEnemy.text = "Evaded!!!";
                                        txtEnemy.gameObject.SetActive(true);
                                    }
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("arrow barrage");
                                break;
                            case "Cold Mist":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    anim.SetBool("spell", true);
                                    Globals.p1CantMana = Globals.p1Mana;
                                    Globals.cFrostNova = true;
                                    Globals.posibleDamage = card.dmg;
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("cold mist");
                                break;
                            case "Dropplet of Life":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    Globals.p1CantMana = Globals.p1Mana;
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.cBlessingRestoration = true;
                                    Globals.posibleDamage = card.heal;
                                    //Globals.p1MaxLife += 20;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 3 (cantidad de mana perdido)
                                    anim.SetBool("spellY", true);
                                    //Debug.Log(Globals.p1ManaPosX);
                                }
                                break;
                            case "Energy Blast":
                                anim.SetBool("spellY", true);
                                Globals.p1CantMana = Globals.p1Mana;
                                Globals.cEnergyBlast = true;
                                Globals.posibleDamage = card.dmg * Globals.p1Mana;
                                Globals.p1ManaPosX -= (1 * Globals.p1Mana);
                                Globals.p1Mana = 0;
                                break;
                            case "Earthquake":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    anim.SetBool("spellY", true);
                                    Globals.p1CantMana = Globals.p1Mana;
                                    Globals.cEartquake = true;
                                    Globals.posibleDamage = card.dmg;
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("earthquake");
                                break;
                            case "Fireball":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    anim.SetBool("spell", true);
                                    Globals.p1CantMana = Globals.p1Mana;
                                    Globals.cFireBall = true;
                                    card.dmg = Random.Range(14, 21);
                                    Globals.posibleDamage = card.dmg;
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 2 (cantidad de mana perdido)
                                                                              //Debug.Log(Globals.p1ManaPosX);
                                }
                                break;
                            case "Fire Nova":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    anim.SetBool("spell", true);
                                    Globals.p1CantMana = Globals.p1Mana;
                                    Globals.cFireNova = true;
                                    card.dmg = Random.Range(21, 28);
                                    Globals.posibleDamage = card.dmg;
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                                                              //Debug.Log(Globals.p1ManaPosX);
                                }
                                break;
                            case "Ice Javeling":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    anim.SetBool("spell", true);
                                    Globals.p1CantMana = Globals.p1Mana;
                                    Globals.cIceJaveling = true;
                                    Globals.p1Mana -= card.manaCost;
                                    card.dmg = Random.Range(8, 11);
                                    Globals.posibleDamage = card.dmg;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("ice javeling");
                                break;
                            case "Knife Slash":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    Globals.p1CantMana = Globals.p1Mana;
                                    //el enemigo no esquiva el ataque
                                    if (posibleEnemyEvaded > 1.5 * Globals.eTAgility)
                                    {//efecto de la carta con critico
                                        if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                                        {
                                            txtEnemy.text = "Critic!!!";
                                            txtEnemy.gameObject.SetActive(true);
                                            //efecto de la carta
                                            Globals.eTLife -= (card.dmg * 1.5f);
                                        }//efecto normal de la carta
                                        else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                                            Globals.eTLife -= card.dmg; //efecto de la carta
                                    }
                                    //el enemigo esquiva el ataque
                                    else if (posibleEnemyEvaded <= 1.5 * Globals.eTAgility)
                                    {
                                        txtEnemy.text = "Evaded!!!";
                                        txtEnemy.gameObject.SetActive(true);
                                    }
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("knife slash");
                                break;
                            case "Low Kick":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    Globals.p1CantMana = Globals.p1Mana;
                                    //el enemigo no esquiva el ataque
                                    if (posibleEnemyEvaded > 1.5 * Globals.eTAgility)
                                    {//efecto de la carta con critico
                                        if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                                        {
                                            txtEnemy.text = "Critic!!!";
                                            txtEnemy.gameObject.SetActive(true);
                                            //efecto de la carta
                                            Globals.eTLife -= (card.dmg * 1.5f);
                                        }//efecto normal de la carta
                                        else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                                            Globals.eTLife -= card.dmg; //efecto de la carta
                                    }
                                    //el enemigo esquiva el ataque
                                    else if (posibleEnemyEvaded <= 1.5 * Globals.eTAgility)
                                    {
                                        txtEnemy.text = "Evaded!!!";
                                        txtEnemy.gameObject.SetActive(true);
                                    }
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("low kick");
                                break;
                            case "Net Arrow":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    anim.SetBool("spell", true);
                                    Globals.p1CantMana = Globals.p1Mana;
                                    Globals.cNetArrow = true;
                                    Globals.posibleDamage = card.dmg;
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("net arrow");
                                break;
                            case "Shocking Touch":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    anim.SetBool("spell", true);
                                    Globals.p1CantMana = Globals.p1Mana;
                                    Globals.cShockingTouch = true;
                                    Globals.p1Mana -= card.manaCost;
                                    card.dmg = Random.Range(10, 13);
                                    Globals.posibleDamage = card.dmg;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("shocking touch");
                                break;
                            case "Sucker Punch":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    Globals.p1CantMana = Globals.p1Mana;
                                    //el enemigo no esquiva el ataque
                                    if (posibleEnemyEvaded > 1.5 * Globals.eTAgility)
                                    {//efecto de la carta con critico
                                        if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                                        {
                                            txtEnemy.text = "Critic!!!";
                                            txtEnemy.gameObject.SetActive(true);
                                            //efecto de la carta
                                            Globals.eTLife -= (card.dmg * 1.5f);
                                        }//efecto normal de la carta
                                        else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                                            Globals.eTLife -= card.dmg; //efecto de la carta
                                    }
                                    //el enemigo esquiva el ataque
                                    else if (posibleEnemyEvaded <= 1.5 * Globals.eTAgility)
                                    {
                                        txtEnemy.text = "Evaded!!!";
                                        txtEnemy.gameObject.SetActive(true);
                                    }
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("sucker punch");
                                break;
                            case "Whirldwind":
                                if (Globals.p1Mana < card.manaCost) Globals.p1NoMana = true;
                                else
                                {
                                    Globals.p1CantMana = Globals.p1Mana;
                                    //el enemigo no esquiva el ataque
                                    if (posibleEnemyEvaded > 1.5 * Globals.eTAgility)
                                    {//efecto de la carta con critico
                                        if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                                        {
                                            txtEnemy.text = "Critic!!!";
                                            txtEnemy.gameObject.SetActive(true);
                                            //efecto de la carta
                                            Globals.eTLife -= (card.dmg * 1.5f);
                                        }//efecto normal de la carta
                                        else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                                            Globals.eTLife -= card.dmg; //efecto de la carta
                                    }
                                    //el enemigo esquiva el ataque
                                    else if (posibleEnemyEvaded <= 1.5 * Globals.eTAgility)
                                    {
                                        txtEnemy.text = "Evaded!!!";
                                        txtEnemy.gameObject.SetActive(true);
                                    }
                                    Globals.p1Mana -= card.manaCost;
                                    Globals.p1ManaPosX -= (1 * card.manaCost);//1 de pos * 4 (cantidad de mana perdido)
                                }
                                Debug.Log("whirldwind");
                                break;
                        }
                        Globals.posibleInit = card.init;
                    }
                //}
            }
        }
    }
    private void OnMouseUp()
    {
        if (!Globals.pauseActive)
        {
            if (Globals.p1CanAttack == false)
            {
                if (Globals.eTCanAttack)
                    txtTitle.text = "You can't attack, it's enemy's turn";
                else if (!Globals.eTCanAttack)
                    txtTitle.text = "You only can attack one time during your turn";
                txtTitle.gameObject.SetActive(true);
                //Debug.Log("you can attack, it's enemy's turn");
            }
            //else if (Globals.p1CanUseCard) {
            else if (Globals.p1NoMana)
            {
                txtTitle.text = "You need more mana";
                txtTitle.gameObject.SetActive(true);
                //Debug.Log("you need more mana");
                Globals.p1NoMana = false;
            }
            else if (Globals.p1NoMana == false && Globals.p1CanAttack)//cambiar por Globals.p1CanAttack si no funca
            {
                Globals.cont++;
                transform.position = new Vector3(posX, posY, 1f);
                transform.localScale = new Vector3(scaleX, scaleY, 1f);
                changeCard = true;
                this.gameObject.SetActive(false);
                Globals.p1CanAttack = false;
                //Globals.p1CanUseCard = false;//quitar si no funca
                //Globals.p1TimeToUseCard = 0;//quitar si no funca
                                            //Globals.eTCanAttack = true;
            }
            //}
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
        if (card.manaCost <= Globals.p1Mana)
            mask.gameObject.SetActive(true);
        else if (card.manaCost > Globals.p1Mana)
            mask.gameObject.SetActive(false);
        if (changeCard)
        {
            changeCard = false;
            card = Globals.decklist[Globals.cont];
            Debug.Log("contador: " + Globals.cont);
            nameText.text = card.name;
            descriptionText.text = card.description;
            artworkImage.sprite = card.artWork;
            if (card.manaCost == 0)
                manaText.text = "X";
            else
                manaText.text = card.manaCost.ToString();
        }
    }
}