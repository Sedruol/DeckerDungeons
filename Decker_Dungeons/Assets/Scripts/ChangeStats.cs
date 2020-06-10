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
            name.text = "Name : Knight";
            strength.text = "Strength : " + Globals.p1Strength.ToString();
            intelligence.text = "Intelligence : " + Globals.p1Intelligence.ToString();
            bloodlust.text = "Bloodlust : " + Globals.p1Bloodlust.ToString();
            agility.text = "Agility : " + Globals.p1Agility.ToString();
        }
        /*else if (Globals.p2Stats)
        {

        }
        else if (Globals.p3Stats)
        {

        }*/
        else if (Globals.eTStats)
        {
            name.text = "Name : Demon";
            strength.text = "Strength : " + Globals.eTStrength.ToString();
            intelligence.text = "Intelligence : " + Globals.eTIntelligence.ToString();
            bloodlust.text = "Bloodlust : " + Globals.eTBloodlust.ToString();
            agility.text = "Agility : " + Globals.eTAgility.ToString();
        }
        /*else if (Globals.e2Stats)
        {

        }
        else if (Globals.e3Stats)
        {

        }*/
    }
}
