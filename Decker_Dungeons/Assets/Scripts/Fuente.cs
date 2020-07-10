using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuente : MonoBehaviour
{
    [SerializeField] private GameObject healing;
    [SerializeField] private AudioClip audioHealing;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        Globals.canHeal = true;
    }
    private void OnMouseDown()
    {
        if (Globals.canHeal)
        {
            healing.SetActive(true);
            audioSource.clip = audioHealing;
            audioSource.Play();
            Globals.firstFuente = false;
            Globals.canHeal = false;
        }
    }
}
