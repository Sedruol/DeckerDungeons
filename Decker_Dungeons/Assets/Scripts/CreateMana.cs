﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMana : MonoBehaviour
{
    public GameObject mana;

    // Start is called before the first frame update
    void Start()
    {
        Globals.p1ManaPosX = -8.1f;
        GameObject m;
        for (int i = 0; i < Globals.p1Mana; i++)
        {
            m = Instantiate(mana, new Vector3(Globals.p1ManaPosX, Globals.p1ManaPosY, 0), Quaternion.identity, this.gameObject.transform);
            m.transform.localScale = new Vector3(72f, 72f, 72f);
            Globals.p1ManaPosX += 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}