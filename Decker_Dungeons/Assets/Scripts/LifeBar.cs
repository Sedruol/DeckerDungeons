using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image fullLifeBar;
    private float maxLife;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Player Life")
            maxLife = Globals.p1Life;
        else if (gameObject.name == "Enemy Life")
            maxLife = Globals.e1Life;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player Life")
        {
            if (Globals.p1Life > 100f)
                Globals.p1Life = 100f;
            else if (Globals.p1Life <= 0f)
            {
                Globals.p1Win = false;
                Globals.menuResult = true;
            }
            fullLifeBar.fillAmount = Globals.p1Life / maxLife;
        }
        else if (gameObject.name == "Enemy Life")
        {
            if (Globals.e1Life > 100f)
                Globals.e1Life = 100f;
            else if (Globals.p1Life <= 0f)
            {
                Globals.p1Win = true;
                Globals.menuResult = true;
            }
            fullLifeBar.fillAmount = Globals.e1Life / maxLife;
        }
    }
}
