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
    [SerializeField] private Text txtLifeEnemy;
    [SerializeField] private AudioClip audioHit;
    [SerializeField] private AudioSource FxSoundController;
    private Animator anim;
    private Vector2 velocityVector;
    private Vector3 pos;
    private int enemyLayer;
    public bool moveAttack;
    private int posibleCritic;
    private int posibleEnemyEvade;
    private float timeVisibleCritic;
    private float timeVisibleEvade;
    private float strMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        if (Globals.pauseActive)
            anim.speed = 0;
        else if (!Globals.pauseActive)
            anim.speed = 1;
        if (Globals.p1BasicAttack)
        {
            anim.SetBool("dash", true);
            velocityVector.x = velocity;
            rigidbody2D.velocity = velocityVector;
            Globals.p1BasicAttack = false;
            moveAttack = true;
        }
        if (!Globals.p1BasicAttack && !moveAttack && pos.x > gameObject.transform.position.x)
        {
            anim.SetBool("dash", false);
            rigidbody2D.velocity = new Vector2(0f, 0f);
            gameObject.transform.position = new Vector3(pos.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Globals.eTCanAttack = true;
            if (Globals.eTInitiative > Globals.p1Initiative)
                Globals.newTurn = true;
        }
        if (Globals.eTCritico)
        {
            txtPlayer.text = "Critic!!!";
            txtPlayer.color = new Color(1f, 0f, 0f);
            txtPlayer.gameObject.SetActive(true);
            Globals.eTCritico = false;
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
    private void ControllerAttack()
    {
        anim.SetBool("attack", false);
        bool mov = true;
        while (mov)
        {
            if (anim.GetBool("attack") == false)
            {
                if (pos.x < transform.position.x)
                {
                    velocityVector.x = -velocity;
                    rigidbody2D.velocity = velocityVector;
                    moveAttack = false;
                    //probabilidad de que el enemigo evada
                    posibleEnemyEvade = Random.Range(0, 100);
                    Debug.Log("enemigo evade: " + posibleEnemyEvade);
                    if (posibleEnemyEvade > (1 + Globals.eTAgility/0.8f))
                    {
                        //probabilidad de lanzar critico
                        posibleCritic = Random.Range(0, 100);
                        Debug.Log("player critico: " + posibleCritic);
                        if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                        {
                            txtEnemy.text = "Critic!!!";
                            txtEnemy.color = new Color(1f, 0f, 0f);
                            txtEnemy.gameObject.SetActive(true);
                            Globals.eTLife -= ((3 + Globals.p1Strength * strMultiplier) * 1.5f);
                            txtLifeEnemy.text = "-" + ((3 + Globals.p1Strength * strMultiplier) * 1.5f);
                            txtLifeEnemy.color = new Color(1f, 0f, 0f);
                            txtLifeEnemy.gameObject.SetActive(true);
                        }
                        else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                        {
                            Globals.eTLife -= (3 + Globals.p1Strength * strMultiplier);
                            txtLifeEnemy.text = "-" + (3 + Globals.p1Strength * strMultiplier);
                            txtLifeEnemy.color = new Color(1f, 0f, 0f);
                            txtLifeEnemy.gameObject.SetActive(true);
                        }
                    }
                    else if (posibleEnemyEvade <= (1 + Globals.eTAgility / 0.8f))
                    {
                        txtEnemy.text = "Evaded!!!";
                        txtEnemy.color = new Color(1f, 196f / 255f, 0f);
                        txtEnemy.gameObject.SetActive(true);
                    }
                    mov = false;
                }
            }
        }
    }
    private void ControllerSpell()
    {
        anim.SetBool("spell", false);
        //Debug.Log("2");
    }
    private void ControllerSpellInY()
    {
        anim.SetBool("spellY", false);
    }
    /*private void StartSpell()
    {
        anim.transform.position = new Vector3(anim.transform.position.x, 0.12f, anim.transform.position.z);
    }
    private void StartIdle()
    {
        anim.transform.position = new Vector3(anim.transform.position.x, -0.36f, anim.transform.position.z);
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.layer == enemyLayer)
            {
                Globals.p1BasicAttack = false;
                if (moveAttack)
                {
                    velocityVector.x = 0f;
                    rigidbody2D.velocity = velocityVector;
                    anim.SetBool("attack", true);
                    FxSoundController.clip = audioHit;
                    FxSoundController.Play();
                    /* if (pos.x < transform.position.x)
                    {
                        velocityVector.x = -velocity;
                        rigidbody2D.velocity = velocityVector;
                        moveAttack = false;
                        //probabilidad de que el enemigo evada
                        posibleEnemyEvade = Random.Range(0, 100);
                        Debug.Log("enemigo evade: " + posibleEnemyEvade);
                        if (posibleEnemyEvade > 1.5 * Globals.eTAgility)
                        {
                            //probabilidad de lanzar critico
                            posibleCritic = Random.Range(0, 100);
                            Debug.Log("player critico: " + posibleCritic);
                            if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                            {
                                txtEnemy.text = "Critic!!!";
                                txtEnemy.color = new Color(1f, 0f, 0f);
                                txtEnemy.gameObject.SetActive(true);
                                Globals.eTLife -= ((3 + Globals.p1Strength * strMultiplier) * 1.5f);
                                txtLifeEnemy.text = "-" + ((3 + Globals.p1Strength * strMultiplier) * 1.5f);
                                txtLifeEnemy.color = new Color(1f, 0f, 0f);
                                txtLifeEnemy.gameObject.SetActive(true);
                            }
                            else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                            {
                                Globals.eTLife -= (3 + Globals.p1Strength * strMultiplier);
                                txtLifeEnemy.text = "-" + (3 + Globals.p1Strength * strMultiplier);
                                txtLifeEnemy.color = new Color(1f, 0f, 0f);
                                txtLifeEnemy.gameObject.SetActive(true);
                            }
                        }
                        else if (posibleEnemyEvade <= 3.5 * Globals.eTAgility)
                        {
                            txtEnemy.text = "Evaded!!!";
                            txtEnemy.color = new Color(1f, 196f / 255f, 0f);
                            txtEnemy.gameObject.SetActive(true);
                        }
                    }*/
                }
            }
        }
    }
}
