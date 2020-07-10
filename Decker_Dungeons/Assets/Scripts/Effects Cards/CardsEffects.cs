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
    [SerializeField] private GameObject energyBlastPrefab;
    [SerializeField] private Text txtEnemy;

    [Header("Audio Effects")]
    [SerializeField] private AudioClip audioIce;
    [SerializeField] private AudioClip audioShocking;
    [SerializeField] private AudioClip audioArrow;
    [SerializeField] private AudioClip audioFireball;
    [SerializeField] private AudioClip audioHealing;
    [SerializeField] private AudioClip audioFireNova;
    [SerializeField] private AudioClip audioFrostNova;
    [SerializeField] private AudioClip audioEnergyBlast;

    private Animator anim;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        anim = player.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
                audioSource.clip = audioIce;
                audioSource.Play();
            }
            else if (Globals.cShockingTouch)
            {
                Globals.cShockingTouch = false;
                GameObject shocking = Instantiate(shockingPrefab) as GameObject;
                shocking.transform.position = new Vector3(-4.75f, 0.3f, 0f);
                audioSource.clip = audioShocking;
                audioSource.Play();
            }
            else if (Globals.cNetArrow)
            {
                Globals.cNetArrow = false;
                GameObject arrow = Instantiate(arrowPrefab) as GameObject;
                arrow.transform.position = new Vector3(-4.75f, 0.3f, 0f);
                audioSource.clip = audioArrow;
                audioSource.Play();
            }
            else if (Globals.cFireBall)
            {
                Globals.cFireBall = false;
                GameObject fireball = Instantiate(fireballPrefab) as GameObject;
                fireball.transform.position = new Vector3(-4.75f, 0.3f, 0f);
                audioSource.clip = audioFireball;
                audioSource.Play();
            }
            else if (Globals.cBlessingRestoration)
            {
                Globals.cBlessingRestoration = false;
                Instantiate(healingPrefab, new Vector3(-6.75f, -0.17f, 0f), Quaternion.identity, player.transform);
                audioSource.clip = audioHealing;
                audioSource.Play();
            }
            else if (Globals.cFireNova)
            {
                Globals.cFireNova = false;
                Instantiate(fireNovaPrefab, new Vector3(5.5f, -0.5f, 0f), Quaternion.identity);
                audioSource.clip = audioFireNova;
                audioSource.Play();
            }
            else if (Globals.cFrostNova)
            {
                Globals.cFrostNova = false;
                Instantiate(frostNovaPrefab, new Vector3(5.5f, -0.5f, 0f), Quaternion.identity);
                audioSource.clip = audioFrostNova;
                audioSource.Play();
            }
            else if (Globals.cEnergyBlast)
            {
                Globals.cEnergyBlast = false;
                energyBlastPrefab.SetActive(true);
                audioSource.clip = audioEnergyBlast;
                audioSource.Play();
                //Instantiate(energyBlastPrefab, new Vector3(5.7f, 7.7f, 0f), Quaternion.identity);//que se mueva en Y hasta 0.5f
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