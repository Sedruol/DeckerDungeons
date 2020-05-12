using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    private float alpha;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        alpha = 256f;
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
