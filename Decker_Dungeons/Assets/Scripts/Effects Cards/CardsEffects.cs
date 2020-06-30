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

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = player.GetComponent<Animator>();
    }
    private void Update()
    {
        if (anim.GetBool("spell") == false)
        {
            if (Globals.cIceJaveling)
            {
                Globals.cIceJaveling = false;
                GameObject ice = Instantiate(icePrefab) as GameObject;
                ice.transform.position = new Vector3(-4.75f, 0.3f, 0f);
            }
            else if (Globals.cShockingTouch)
            {
                Globals.cShockingTouch = false;
                GameObject shocking = Instantiate(shockingPrefab) as GameObject;
                shocking.transform.position = new Vector3(-4.75f, 0.3f, 0f);
            }
            else if (Globals.cNetArrow)
            {
                Globals.cNetArrow = false;
                GameObject arrow = Instantiate(arrowPrefab) as GameObject;
                arrow.transform.position = new Vector3(-4.75f, 0.3f, 0f);
            }
            else if (Globals.cFireBall)
            {
                Globals.cFireBall = false;
                GameObject fireball = Instantiate(fireballPrefab) as GameObject;
                fireball.transform.position = new Vector3(-4.75f, 0.3f, 0f);
            }
            else if (Globals.cBlessingRestoration)
            {
                Globals.cBlessingRestoration = false;
                Instantiate(healingPrefab, new Vector3(-6.75f, -0.17f, 0f), Quaternion.identity, player.transform);
            }
            else if (Globals.cFireNova)
            {
                Globals.cFireNova = false;
                Instantiate(fireNovaPrefab, new Vector3(5.5f, -0.5f, 0f), Quaternion.identity);
            }
            else if (Globals.cFrostNova)
            {
                Globals.cFrostNova = false;
                Instantiate(frostNovaPrefab, new Vector3(5.5f, -0.5f, 0f), Quaternion.identity);
            }
            else if (Globals.cKnifeSlash)
            {

            }
            /*
            else if (Globals.cArrowBarrage)
            {
                Globals.cArrowBarrage = false;
                Instantiate(arrowPrefab, new Vector3(-4.75f, 0.85f, 0f), Quaternion.identity);
            }*/

            if (Globals.critico)
            {
                txtEnemy.text = "Critic!!!";
                txtEnemy.color = new Color(1f, 0f, 0f);
                txtEnemy.gameObject.SetActive(true);
                Globals.critico = false;
            }
            if (Globals.eTEvade)
            {
                //Debug.Log("evadí");
                //aqui debo poner algo visual que lo demuestre
                txtEnemy.text = "Evaded!!!";
                txtEnemy.color = new Color(1f, 196f / 255f, 0f);
                txtEnemy.gameObject.SetActive(true);
                Globals.eTEvade = false;
            }
        }
    }
    public void EffectCard()
    {
    }
}