using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovePlayerAttack : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocity;
    private Vector2 velocityVector;
    private int enemyLayer;
    private int posibleCritic;
    private int posibleEnemyEvaded;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityVector.x = velocity;
        rigidbody2D.velocity = velocityVector;
        enemyLayer = LayerMask.NameToLayer("Enemy");
        posibleCritic = 0;
        posibleEnemyEvaded = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.layer == enemyLayer)
            { 
                posibleCritic = Random.Range(0, 100);
                posibleEnemyEvaded = Random.Range(0, 100);
                Debug.Log("enemy evaded: " + posibleEnemyEvaded);
                Debug.Log("player critico: " + posibleCritic);
                //el enemigo no esquiva el ataque
                if (posibleEnemyEvaded > 1.5 * Globals.e1Agility)
                {//efecto de la carta con critico
                    if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                    {
                        Globals.critico = true;
                        Globals.e1Life -= (Globals.posibleDamage * 1.5f);
                    }
                    else if (posibleCritic > 2.5 * Globals.p1Bloodlust)
                        Globals.e1Life -= Globals.posibleDamage;
                    if (Globals.posibleInit > 0)
                        Globals.e1Initiative -= Globals.posibleInit;
                }
                //el enemigo esquiva el ataque
                else if (posibleEnemyEvaded <= 1.5 * Globals.e1Agility)
                {
                    Globals.e1Evade = true;
                }
                //new turn?
                if (Globals.e1Initiative > Globals.p1Initiative)
                    Globals.newTurn = true;
                //Globals.p1CanAttack = false;
                Globals.e1CanAttack = true;
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
