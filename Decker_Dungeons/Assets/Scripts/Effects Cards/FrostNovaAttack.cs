using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrostNovaAttack : MonoBehaviour
{
    private float values;
    private float newColorG;
    //private SpriteRenderer sr;
    private int posibleCritic;
    private int posibleEnemyEvaded;
    private Text txtLifeEnemy;
    private void Awake()
    {
        //sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        txtLifeEnemy = GameObject.Find("HUD/Texts Interaction/txtLifeEnemy").GetComponent<Text>();
        values = 0f;
        newColorG = 255;
        posibleCritic = 0;
        posibleEnemyEvaded = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            values += Time.deltaTime;
            newColorG--;
            transform.localScale = new Vector3(values, values, values);
            transform.rotation = Quaternion.Euler(0f, 0f, values * 180);
            //sr.color = new Color(sr.color.r, newColorG / 255f, sr.color.b);
            if (transform.localScale.x >= 2)
            {
                posibleCritic = Random.Range(0, 100);
                posibleEnemyEvaded = Random.Range(0, 100);
                Debug.Log("enemy evaded: " + posibleEnemyEvaded);
                Debug.Log("player critico: " + posibleCritic);
                //el enemigo no esquiva el ataque
                if (posibleEnemyEvaded > 1 + (Globals.eTAgility / 0.8f))
                {//efecto de la carta con critico
                    if (posibleCritic <= 2.5 * Globals.p1Bloodlust)
                    {
                        Globals.critico = true;
                        Globals.eTLife -= (Globals.posibleDamage * 1.5f);
                        txtLifeEnemy.text = "-" + Globals.posibleDamage * 1.5f;
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
                    Globals.eTAgility -= 6;
                    Globals.changeStats = true;
                    if (Globals.posibleInit > 0)
                        Globals.eTInitiative -= Globals.posibleInit;
                }
                //el enemigo esquiva el ataque
                else if (posibleEnemyEvaded <= 1 + (Globals.eTAgility / 0.8f))
                {
                    Globals.eTEvade = true;
                }
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
