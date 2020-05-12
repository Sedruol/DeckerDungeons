using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsEffects : MonoBehaviour
{
    [Header("Cards Effects")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject icePrefab;
    [SerializeField] private GameObject shockingPrefab;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private GameObject healingPrefab;
    [SerializeField] private GameObject fireNovaPrefab;
    [SerializeField] private GameObject frostNovaPrefab;
    [SerializeField] private Text txtEnemy;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        if (Globals.cIceJaveling)
        {
            Globals.cIceJaveling = false;
            GameObject ice = Instantiate(icePrefab) as GameObject;
            ice.transform.position = new Vector3(-4.75f, 0.85f, 0f);
        }
        else if (Globals.cShockingTouch)
        {
            Globals.cShockingTouch = false;
            GameObject shocking = Instantiate(shockingPrefab) as GameObject;
            shocking.transform.position = new Vector3(-4.75f, 0.85f, 0f);
        }
        else if (Globals.cNetArrow)
        {
            Globals.cNetArrow = false;
            GameObject arrow = Instantiate(arrowPrefab) as GameObject;
            arrow.transform.position = new Vector3(-4.75f, 0.85f, 0f);
        }
        else if (Globals.cFireBall)
        {
            Globals.cFireBall = false;
            GameObject fireball = Instantiate(fireballPrefab) as GameObject;
            fireball.transform.position = new Vector3(-4.75f, 0.85f, 0f);
        }
        else if (Globals.cBlessingRestoration)
        {
            Globals.cBlessingRestoration = false;
            Instantiate(healingPrefab, new Vector3(-6.57f, 0.4f, 0f), Quaternion.identity, player.transform);
        }
        else if (Globals.cFireNova)
        {
            Globals.cFireNova = false;
            Instantiate(fireNovaPrefab, new Vector3(6.36f, 0.23f, 0f), Quaternion.identity);
        }
        else if (Globals.cFrostNova)
        {
            Globals.cFrostNova = false;
            Instantiate(frostNovaPrefab, new Vector3(6.36f, 0.23f, 0f), Quaternion.identity);
        }

        if (Globals.critico)
        {
            txtEnemy.text = "Critic!!!";
            txtEnemy.gameObject.SetActive(true);
            Globals.critico = false;
        }
        if (Globals.e1Evade)
        {
            //Debug.Log("evadí");
            //aqui debo poner algo visual que lo demuestre
            txtEnemy.text = "Evaded!!!";
            txtEnemy.gameObject.SetActive(true);
            Globals.e1Evade = false;
        }
    }
    public void EffectCard()
    {
    }
}