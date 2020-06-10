using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveEnemyAttack : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocity;
    //[SerializeField] private Text txtEvade;
    private Vector2 velocityVector;
    private int posibleEvade;
    private int posibleEnemyCritic;
    private int knightLayer;
    private float strMultiplier;
    private int typeAttack;
    private SpriteRenderer sr;
    private float baseAttack;
    private Text txtLifePlayer;
    private void Awake()
    {
        typeAttack = Random.Range(0, 2);
    }
    // Start is called before the first frame update
    void Start()
    {
        txtLifePlayer = GameObject.Find("HUD/Texts Interaction/txtLifePlayer").GetComponent<Text>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        velocityVector.x = -velocity;
        rigidbody2D.velocity = velocityVector;
        posibleEvade = Random.Range(0, 100);
        posibleEnemyCritic = Random.Range(0, 100);
        Debug.Log("player evade: " + posibleEvade);
        knightLayer = LayerMask.NameToLayer("Knight");
        strMultiplier = 0.2f;
        if (typeAttack == 0)
        {
            baseAttack = 4f;
            transform.localScale = new Vector3(-0.6f, 0.6f, 0.6f);
        }
        else if (typeAttack == 1)
        {
            sr.color = new Color(255f, 0f, 0f);
            baseAttack = 8;
        }
        //Debug.Log(typeAttack);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.layer == knightLayer)
            {
                if (posibleEvade <= 1.5 * Globals.p1Agility)
                    Globals.evade = true;
                if (!Globals.evade)
                {
                    Debug.Log("enemy critico: " + posibleEnemyCritic);
                    if (posibleEnemyCritic <= 2.5 * Globals.eTBloodlust)
                    {
                        Globals.p1Life -= ((baseAttack + Globals.eTStrength * strMultiplier) * 1.5f);
                        txtLifePlayer.text = "-" + ((baseAttack + Globals.eTStrength * strMultiplier) * 1.5f);
                        txtLifePlayer.color = new Color(1f, 0f, 0f);
                        txtLifePlayer.gameObject.SetActive(true);
                        Globals.eTCritico = true;
                    }
                    else if (posibleEnemyCritic > 2.5 * Globals.eTBloodlust)
                    {
                        Globals.p1Life -= (baseAttack + Globals.eTStrength * strMultiplier);
                        txtLifePlayer.text = "-" + (baseAttack + Globals.eTStrength * strMultiplier);
                        txtLifePlayer.color = new Color(1f, 0f, 0f);
                        txtLifePlayer.gameObject.SetActive(true);
                    }
                }
                Globals.p1CanAttack = true;
                Globals.eTCanAttack = false;
                if(Globals.eTInitiative <= Globals.p1Initiative)
                    Globals.newTurn = true;
                Debug.Log("vida: " + Globals.p1Life);
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
