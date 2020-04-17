using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStats : MonoBehaviour
{
    public Text name;
    public Text strength;
    public Text intelligence;
    public Text bloodlust;
    public Text agility;
    // Start is called before the first frame update
    void Start()
    {
        Globals.p1Stats = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.p1Stats)
        {
            name.text = "Name : Hercules";
            strength.text = "Strength : " + Globals.p1Strength;
            intelligence.text = "Intelligence : " + Globals.p1Intelligence;
            bloodlust.text = "Bloodlust : " + Globals.p1Bloodlust;
            agility.text = "Agility : " + Globals.p1Agility;
        }
        else if (Globals.p2Stats)
        {

        }
        else if (Globals.p3Stats)
        {

        }
        else if (Globals.e1Stats)
        {
            name.text = "Name : Demon";
            strength.text = "Strength : " + Globals.e1Strength;
            intelligence.text = "Intelligence : " + Globals.e1Intelligence;
            bloodlust.text = "Bloodlust : " + Globals.e1Bloodlust;
            agility.text = "Agility : " + Globals.e1Agility;
        }
        else if (Globals.e2Stats)
        {

        }
        else if (Globals.e3Stats)
        {

        }
    }
}
