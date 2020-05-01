using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyAttack : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocity;
    private Vector2 velocityVector;
    private int posibleEvade;
    private int knightLayer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityVector.x = -velocity;
        rigidbody2D.velocity = velocityVector;
        posibleEvade = Random.Range(1, 100);
        Debug.Log("Evade: " + posibleEvade);
        knightLayer = LayerMask.NameToLayer("Knight");
        if (posibleEvade <= 3.5 * Globals.p1Agility)
            Globals.evade = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.layer == knightLayer)
            {
                if (Globals.evade)
                {
                    Debug.Log("evadí");
                    //aqui debo poner algo visual que lo demuestre
                    Globals.evade = false;
                }
                else if (!Globals.evade)
                    Globals.p1Life -= 2f;
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
