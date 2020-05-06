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
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityVector.x = -velocity;
        rigidbody2D.velocity = velocityVector;
        posibleEvade = Random.Range(1, 100);
        posibleEnemyCritic = Random.Range(1, 100);
        Debug.Log("player evade: " + posibleEvade);
        knightLayer = LayerMask.NameToLayer("Knight");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.layer == knightLayer)
            {
                if (posibleEvade <= 3.5 * Globals.p1Agility)
                    Globals.evade = true;
                if (!Globals.evade)
                {
                    Debug.Log("enemy critico: " + posibleEnemyCritic);
                    if (posibleEnemyCritic <= 2.5 * Globals.e1Bloodlust)
                    {
                        Globals.p1Life -= (Globals.e1Strength * 1.5f);
                        Globals.e1Critico = true;
                    }
                    else if (posibleEnemyCritic > 2.5 * Globals.e1Bloodlust)
                        Globals.p1Life -= Globals.e1Strength;
                }
                Globals.p1CanAttack = true;
                Globals.e1CanAttack = false;
                Globals.newTurn = true;
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
