using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBlast : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Text txtEnemy;
    [SerializeField] private Text txtLifeEnemy;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer sr;
    private Vector2 velocityVector;
    private bool move;
    private float alpha;
    private int posibleCritic;
    private int posibleEnemyEvade;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityVector.y = velocity;
        rigidbody2D.velocity = velocityVector;
        move = true;
        sr = GetComponent<SpriteRenderer>();
        alpha = 256f;
        posibleCritic = 0;
        posibleEnemyEvade = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 0.5f && move)
        {
            move = false;
            velocityVector.y = 0;
            rigidbody2D.velocity = velocityVector;
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            ///
            posibleEnemyEvade = Random.Range(0, 100);
            Debug.Log("enemigo evade: " + posibleEnemyEvade);
            if (posibleEnemyEvade > (1 + Globals.eTAgility / 0.8f))
            {
                //probabilidad de lanzar critico
                posibleCritic = Random.Range(0, 100);
                Debug.Log("player critico: " + posibleCritic);
                if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                {
                    txtEnemy.text = "Critic!!!";
                    txtEnemy.color = new Color(1f, 0f, 0f);
                    txtEnemy.gameObject.SetActive(true);
                    Globals.eTLife -= (Globals.posibleDamage * 1.5f);
                    txtLifeEnemy.text = "-" + (Globals.posibleDamage * 1.5f);
                    txtLifeEnemy.color = new Color(1f, 0f, 0f);
                    txtLifeEnemy.gameObject.SetActive(true);
                }
                else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                {
                    Globals.eTLife -= (Globals.posibleDamage);
                    txtLifeEnemy.text = "-" + (Globals.posibleDamage);
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
        }
        if (!move)
        {
            alpha -= 4;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha / 255f);
            if (alpha == 0)
            {
                //new turn?
                if (Globals.eTInitiative > Globals.p1Initiative)
                    Globals.newTurn = true;
                //Globals.p1CanAttack = false;
                Globals.eTCanAttack = true;
                Destroy(gameObject);
            }
        }
    }
}
