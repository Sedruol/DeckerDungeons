using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocity;
    [SerializeField] private Text txtEnemy;
    [SerializeField] private Text txtPlayer;
    private Vector2 velocityVector;
    private Vector3 pos;
    private int enemyLayer;
    private bool moveAttack;
    private int posibleCritic;
    private int posibleEnemyEvade;
    private float timeVisibleCritic;
    private float timeVisibleEvade;
    private float strMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityVector.x = velocity;
        enemyLayer = LayerMask.NameToLayer("Enemy");
        pos = gameObject.transform.position;
        moveAttack = false;
        posibleCritic = 0;
        posibleEnemyEvade = 0;
        timeVisibleEvade = 0;
        timeVisibleCritic = 0;
        strMultiplier = 0.2f;
        txtEnemy.gameObject.SetActive(false);
        txtPlayer.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Globals.p1BasicAttack)
        {
            velocityVector.x = velocity;
            rigidbody2D.velocity = velocityVector;
            Globals.p1BasicAttack = false;
            moveAttack = true;
        }
        if (!Globals.p1BasicAttack && !moveAttack && pos.x > gameObject.transform.position.x)
        {
            rigidbody2D.velocity = new Vector2(0f, 0f);
            gameObject.transform.position = new Vector3(pos.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Globals.e1CanAttack = true;
            if (Globals.e1Initiative > Globals.p1Initiative)
                Globals.newTurn = true;
        }
        if (Globals.e1Critico)
        {
            txtPlayer.text = "Critic!!!";
            txtPlayer.color = new Color(1f, 0f, 0f);
            txtPlayer.gameObject.SetActive(true);
            Globals.e1Critico = false;
        }
        if (txtEnemy.IsActive())// && visibleCritic)
        {
            timeVisibleCritic += Time.deltaTime;
            if (timeVisibleCritic >= 1f)
            {
                //Debug.Log("se activo el critico");
                txtEnemy.gameObject.SetActive(false);
                timeVisibleCritic = 0;
            }
        }
        if (Globals.evade)
        {
            //Debug.Log("evadí");
            //aqui debo poner algo visual que lo demuestre
            txtPlayer.text = "Evaded!!!";
            txtPlayer.color = new Color(1f, 196f / 255f, 0f);
            txtPlayer.gameObject.SetActive(true);
            Globals.evade = false;
        }
        if (txtPlayer.IsActive())
        {
            timeVisibleEvade += Time.deltaTime;
            if (timeVisibleEvade >= 1f)
            {
                //Debug.Log("se activo la evasion");
                txtPlayer.gameObject.SetActive(false);
                timeVisibleEvade = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.layer == enemyLayer)
            {
                Globals.p1BasicAttack = false;
                if (moveAttack)
                {
                    if (pos.x < transform.position.x)
                    {
                        velocityVector.x = -velocity;
                        rigidbody2D.velocity = velocityVector;
                        moveAttack = false;
                        //probabilidad de que el enemigo evada
                        posibleEnemyEvade = Random.Range(0, 100);
                        Debug.Log("enemigo evade: " + posibleEnemyEvade);
                        if (posibleEnemyEvade > 1.5 * Globals.e1Agility)
                        {
                            //probabilidad de lanzar critico
                            posibleCritic = Random.Range(0, 100);
                            Debug.Log("player critico: " + posibleCritic);
                            if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                            {
                                txtEnemy.text = "Critic!!!";
                                txtEnemy.color = new Color(1f, 0f, 0f);
                                txtEnemy.gameObject.SetActive(true);
                                Globals.e1Life -= ((3 + Globals.p1Strength * strMultiplier) * 1.5f);
                            }
                            else if(posibleCritic > 2.5 * Globals.p1Bloodlust)
                                Globals.e1Life -= (3 + Globals.p1Strength * strMultiplier);
                        }
                        else if (posibleEnemyEvade <= 3.5 * Globals.e1Agility)
                        {
                            txtEnemy.text = "Evaded!!!";
                            txtEnemy.color = new Color(1f, 196f / 255f, 0f);
                            txtEnemy.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
