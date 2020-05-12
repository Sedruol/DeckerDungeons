using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNovaAttack : MonoBehaviour
{
    private float values;
    private float newColorG;
    private SpriteRenderer sr;
    private int posibleCritic;
    private int posibleEnemyEvaded;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        values = 0f;
        newColorG = 25;
        posibleCritic = 0;
        posibleEnemyEvaded = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            values += Time.deltaTime;
            newColorG++;
            transform.localScale = new Vector3(values, values, values);
            transform.rotation = Quaternion.Euler(0f, 0f, values * 180);
            sr.color = new Color(sr.color.r, newColorG/255f, sr.color.b);
            if (transform.localScale.x >= 2)
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
}
