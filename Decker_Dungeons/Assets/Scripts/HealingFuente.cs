using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingFuente : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject fuente;
    [SerializeField] private Text txtHealing;
    private float alpha;
    private SpriteRenderer sr;
    private float healing;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        alpha = 256f;
        if (Globals.p1MaxLife - Globals.p1Life >= 30)
            healing = 30f;
        else
            healing = Globals.p1MaxLife - Globals.p1Life;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            alpha -= 4;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha / 255f);
            if (alpha == 252)
            {
                Globals.p1Life += healing;
                txtHealing.text = "+" + healing;
                txtHealing.color = new Color(0f, 1f, 7f / 255f);
                txtHealing.gameObject.SetActive(true);
            }
            if (alpha == 0)
            {
                portal.SetActive(true);
                txtHealing.gameObject.SetActive(false);
                Destroy(fuente);
                Destroy(gameObject);
            }
        }
    }
}
