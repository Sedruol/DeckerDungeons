using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private GameObject enemyAttack;
    private Rigidbody2D rigidbody2D;
    private Vector2 velocityVector;
    private bool attack;
    private int moveDuringEarthquake;
    private int posibleCritic;
    private int posibleEnemyEvaded;
    private float miniPause;
    private void OnMouseOver()
    {
        Globals.p1Stats = false;
        Globals.e1Stats = true;
    }
    private void OnMouseExit()
    {
        Globals.p1Stats = true;
        Globals.e1Stats = false;
    }
    // Start is called before the first frame update
    void Start()
    {
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
            if (transform.position.x == 6)
            {
                rigidbody2D.velocity = velocityVector;
            }
            else if (transform.position.x >= 6.5f)
            {
                velocityVector.x = -velocity;
                rigidbody2D.velocity = velocityVector;
                moveDuringEarthquake++;
            }
            else if (transform.position.x <= 5.5f)
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
            }
            //el enemigo esquiva el ataque
            else if (posibleEnemyEvaded <= 1.5 * Globals.e1Agility)
            {
                Globals.e1Evade = true;
            }
            moveDuringEarthquake++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.e1CanAttack && attack && Globals.menuResult == false)
        {
            GameObject newAttack = Instantiate(enemyAttack, new Vector3(transform.position.x - 1.5f, transform.position.y,
                    transform.position.z), Quaternion.identity, this.transform);
            attack = false;
        }
        if (transform.childCount == 0)
        {
            attack = true;
        }
        if (Globals.cEartquake)
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
                if (Globals.e1Initiative > Globals.p1Initiative)
                    Globals.newTurn = true;
                //Globals.p1CanAttack = false;
                Globals.e1CanAttack = true;
            }
        }
    }
}
