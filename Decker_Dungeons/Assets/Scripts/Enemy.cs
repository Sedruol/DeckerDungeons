using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private GameObject enemyAttack;
    [SerializeField] private GameObject Player;
    private Animator animPlayer;
    private Animator animEnemy;
    private Rigidbody2D rigidbody2D;
    private Vector2 velocityVector;
    private bool attack;
    private int moveDuringEarthquake;
    private int posibleCritic;
    private int posibleEnemyEvaded;
    private float miniPause;
    private Text txtLifeEnemy;
    // Start is called before the first frame update
    void Start()
    {
        animPlayer = Player.GetComponent<Animator>();
        animEnemy = GetComponent<Animator>();
        txtLifeEnemy = GameObject.Find("HUD/Texts Interaction/txtLifeEnemy").GetComponent<Text>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityVector.x = velocity;
        attack = true;
        moveDuringEarthquake = 0;
        posibleCritic = 0;
        posibleEnemyEvaded = 0;
        miniPause = 0;
    }

    public void moveEarthquake()
    {
        if (moveDuringEarthquake < 7)
        {
            if (transform.position.x == 5.6f)
            {
                rigidbody2D.velocity = velocityVector;
            }
            else if (transform.position.x >= 6.1f)
            {
                velocityVector.x = -velocity;
                rigidbody2D.velocity = velocityVector;
                moveDuringEarthquake++;
            }
            else if (transform.position.x <= 5.1f)
            {
                velocityVector.x = velocity;
                rigidbody2D.velocity = velocityVector;
                moveDuringEarthquake++;
            }
        }
        else if (moveDuringEarthquake == 7)
        {
            Globals.cEartquake = false;
            velocityVector.x = 0;
            rigidbody2D.velocity = velocityVector;
            transform.position = new Vector3(6f, transform.position.y, transform.position.z);
            posibleCritic = Random.Range(0, 100);
            posibleEnemyEvaded = Random.Range(0, 100);
            Debug.Log("enemy evaded: " + posibleEnemyEvaded);
            Debug.Log("player critico: " + posibleCritic);
            if (SceneManager.GetActiveScene().name != "Level 3")
            {//efecto de la carta con critico
                if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                {
                    Globals.critico = true;
                    Globals.eTLife -= (Globals.posibleDamage * 1.5f);
                    txtLifeEnemy.text = "-" + (Globals.posibleDamage * 1.5f);
                    txtLifeEnemy.color = new Color(1f, 0f, 0f);
                    txtLifeEnemy.gameObject.SetActive(true);
                }
                else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                {
                    Globals.eTLife -= Globals.posibleDamage;
                    txtLifeEnemy.text = "-" + Globals.posibleDamage;
                    txtLifeEnemy.color = new Color(1f, 0f, 0f);
                    txtLifeEnemy.gameObject.SetActive(true);
                }
            }
            else
            {
                //el enemigo no esquiva el ataque
                if (posibleEnemyEvaded > 1.5 * Globals.eTAgility)
                {//efecto de la carta con critico
                    if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                    {
                        Globals.critico = true;
                        Globals.eTLife -= (Globals.posibleDamage * 1.5f);
                        txtLifeEnemy.text = "-" + (Globals.posibleDamage * 1.5f);
                        txtLifeEnemy.color = new Color(1f, 0f, 0f);
                        txtLifeEnemy.gameObject.SetActive(true);
                    }
                    else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                    {
                        Globals.eTLife -= Globals.posibleDamage;
                        txtLifeEnemy.text = "-" + Globals.posibleDamage;
                        txtLifeEnemy.color = new Color(1f, 0f, 0f);
                        txtLifeEnemy.gameObject.SetActive(true);
                    }
                }
                //el enemigo esquiva el ataque
                else if (posibleEnemyEvaded <= 1.5 * Globals.eTAgility)
                {
                    Globals.eTEvade = true;
                }
            }
            moveDuringEarthquake++;
        }
    }

    private void ControllerEnemyAttack()
    {
        animEnemy.SetBool("attack", false);
        GameObject newAttack = Instantiate(enemyAttack, new Vector3(transform.position.x - 1.5f, transform.position.y + 0.75f,
                transform.position.z), Quaternion.identity, this.transform);
        attack = false;
    }
    private void ControllerMukAttack()
    {
        GameObject newAttack = Instantiate(enemyAttack, new Vector3(transform.position.x - 1.5f, transform.position.y + 0.75f,
                transform.position.z), Quaternion.identity, this.transform);
        attack = false;
    }
    private void EndMukAttack()
    {
        animEnemy.SetBool("attack", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Globals.eTCanAttack && attack && Globals.menuResult == false)
        {
            animEnemy.SetBool("attack", true);
        }
        if (transform.childCount == 0)
        {
            attack = true;
        }
        if (Globals.cEartquake && animPlayer.GetBool("spell") == false)
        {
            moveEarthquake();
        }
        if (!Globals.cEartquake && moveDuringEarthquake == 8)
        {
            miniPause += Time.deltaTime;
            if (miniPause > 1f)
            {
                moveDuringEarthquake = 0;
                //new turn?
                if (Globals.eTInitiative > Globals.p1Initiative)
                    Globals.newTurn = true;
                //Globals.p1CanAttack = false;
                Globals.eTCanAttack = true;
            }
        }
    }
}
