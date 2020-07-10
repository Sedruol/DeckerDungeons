using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private string room;
    private void Awake()
    {
        typeAttack = Random.Range(0, 2);
    }
    // Start is called before the first frame update
    void Start()
    {
        room = SceneManager.GetActiveScene().name;
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
            if (room == "Level 1")
                sr.color = new Color(0f, 255f, 0f);
            if (room == "Level 2")
                sr.color = new Color(190f, 0f, 255f);
            if (room == "Level 3")
                transform.localScale = new Vector3(-1f, 1f, 1f);
            if (room == "Level 4")
                sr.color = new Color(0f, 255f, 8f);
        }
        else if (typeAttack == 1)
        {
            sr.color = new Color(255f, 0f, 0f);
            transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
            if (room == "Level 1" || room == "Level 2")
                transform.localScale = new Vector3(-1f, 1f, 1f);
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
                if (posibleEvade <= 1 + (Globals.eTAgility / 0.8f))
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
