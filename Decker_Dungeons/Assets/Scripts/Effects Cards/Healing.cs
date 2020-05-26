﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    private float alpha;
    private SpriteRenderer sr;
    private Text txtLifePlayer;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        alpha = 256f;
        txtLifePlayer = GameObject.Find("HUD/Texts Interaction/txtLifePlayer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            alpha--;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha/255f);
            if (alpha == 0)
            {
                Globals.p1Life += Globals.posibleDamage;
                txtLifePlayer.text = "+" + Globals.posibleDamage;
                txtLifePlayer.color = new Color(0f, 1f, 7f / 255f);
                txtLifePlayer.gameObject.SetActive(true);
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
