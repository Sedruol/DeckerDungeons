using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image fullLifeBar;//100 de vida = 480 width, -10 width = -5 pos x
    public Image lifeBar;//empieza -216 pos x | 48 width
    public Image Board;//100 de vida = 500 width, empieza -216 pos x | 68 width
    //empieza con 10 de vida = 48 width y -216 pos x, aumenta 2 width = 1 pos x, aumenta en 48 de width y 24 de pos 
    private float maxLife;
    private void Awake()
    {
        Globals.p1Life = Globals.p1MaxLife;//max life in globals
        Globals.e1Life = 100f;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Player Life")
        {
            if (Globals.p1Life > 10f)
            {
                fullLifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.p1Life - 10), fullLifeBar.rectTransform.sizeDelta.y);
                fullLifeBar.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1Life - 10),
                    fullLifeBar.rectTransform.localPosition.y);
                lifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.p1Life - 10), lifeBar.rectTransform.sizeDelta.y);
                lifeBar.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1Life - 10), lifeBar.rectTransform.localPosition.y);
                Board.rectTransform.sizeDelta = new Vector2(68 + 4.8f * (Globals.p1Life - 10), Board.rectTransform.sizeDelta.y);
                Board.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1Life - 10), Board.rectTransform.localPosition.y);
            }
            maxLife = Globals.p1Life;
        }
        else if (gameObject.name == "Enemy Life")
        {
            if (Globals.e1Life > 10f)
            {
                fullLifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.e1Life - 10), fullLifeBar.rectTransform.sizeDelta.y);
                fullLifeBar.rectTransform.localPosition = new Vector2(216f - 2.4f * (Globals.e1Life - 10),
                    fullLifeBar.rectTransform.localPosition.y);
                lifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.e1Life - 10), lifeBar.rectTransform.sizeDelta.y);
                lifeBar.rectTransform.localPosition = new Vector2(216f - 2.4f * (Globals.e1Life - 10), lifeBar.rectTransform.localPosition.y);
                Board.rectTransform.sizeDelta = new Vector2(68 + 4.8f * (Globals.e1Life - 10), Board.rectTransform.sizeDelta.y);
                Board.rectTransform.localPosition = new Vector2(216f - 2.4f * (Globals.e1Life - 10), Board.rectTransform.localPosition.y);
            }
            maxLife = Globals.e1Life;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player Life")
        {
            maxLife = Globals.p1MaxLife;
            if (Globals.p1MaxLife > 10f)
            {
                fullLifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.p1MaxLife - 10), fullLifeBar.rectTransform.sizeDelta.y);
                fullLifeBar.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1MaxLife - 10),
                    fullLifeBar.rectTransform.localPosition.y);
                lifeBar.rectTransform.sizeDelta = new Vector2(48 + 4.8f * (Globals.p1MaxLife - 10), lifeBar.rectTransform.sizeDelta.y);
                lifeBar.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1MaxLife - 10), lifeBar.rectTransform.localPosition.y);
                Board.rectTransform.sizeDelta = new Vector2(68 + 4.8f * (Globals.p1MaxLife - 10), Board.rectTransform.sizeDelta.y);
                Board.rectTransform.localPosition = new Vector2(-216f + 2.4f * (Globals.p1MaxLife - 10), Board.rectTransform.localPosition.y);
            }

            if (Globals.p1Life > maxLife)
                Globals.p1Life = maxLife;
            else if (Globals.p1Life <= 0f)
            {
                Globals.p1Win = false;
                Globals.menuResult = true;
            }
            fullLifeBar.fillAmount = Globals.p1Life / maxLife;
        }
        else if (gameObject.name == "Enemy Life")
        {
            if (Globals.e1Life > maxLife)
                Globals.e1Life = maxLife;
            else if (Globals.e1Life <= 0f)
            {
                Globals.p1Win = true;
                Globals.p1CanAttack = true;
                Globals.e1CanAttack = false;
                Globals.menuResult = true;
            }
            fullLifeBar.fillAmount = Globals.e1Life / maxLife;
        }
    }
}
