using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocity;
    private Vector2 velocityVector;
    private Vector3 pos;
    private int enemyLayer;
    private bool moveAttack;
    private int posibleCritic;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        velocityVector.x = velocity;
        enemyLayer = LayerMask.NameToLayer("Enemy");
        pos = gameObject.transform.position;
        moveAttack = false;
        posibleCritic = 0;
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
                        //probabilidad de lanzar critico
                        posibleCritic = Random.Range(1, 100);
                        Debug.Log("critico: " + posibleCritic);
                        if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                            Globals.critico = true;
                        //calculo de daño
                        if (Globals.critico)
                        {
                            Debug.Log("criticaso");
                            Globals.e1Life -= (Globals.p1Strength * 1.5f);
                            Globals.critico = false;
                        }
                        else if (!Globals.critico)
                            Globals.e1Life -= Globals.p1Strength;
                    }
                }
            }
        }
    }
}
