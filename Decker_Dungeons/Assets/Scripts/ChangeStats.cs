using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStats : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Text pName;
    [SerializeField] private Text pStrength;
    [SerializeField] private Text pIntelligence;
    [SerializeField] private Text pBloodlust;
    [SerializeField] private Text pAgility;
    [Header("Enemy")]
    [SerializeField] private Text eName;
    [SerializeField] private Text eStrength;
    [SerializeField] private Text eIntelligence;
    [SerializeField] private Text eBloodlust;
    [SerializeField] private Text eAgility;
    // Start is called before the first frame update
    void Start()
    {
        //PLAYER
        pName.text = "Name : Knight";
        pStrength.text = "Strength : " + Globals.p1Strength.ToString();
        pIntelligence.text = "Intelligence : " + Globals.p1Intelligence.ToString();
        pBloodlust.text = "Bloodlust : " + Globals.p1Bloodlust.ToString();
        pAgility.text = "Agility : " + Globals.p1Agility.ToString();
        //ENEMY
        eName.text = "Name : Demon";
        eStrength.text = "Strength : " + Globals.eTStrength.ToString();
        eIntelligence.text = "Intelligence : " + Globals.eTIntelligence.ToString();
        eBloodlust.text = "Bloodlust : " + Globals.eTBloodlust.ToString();
        eAgility.text = "Agility : " + Globals.eTAgility.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.changeStats)
        {
            //PLAYER
            pName.text = "Name : Knight";
            pStrength.text = "Strength : " + Globals.p1Strength.ToString();
            pIntelligence.text = "Intelligence : " + Globals.p1Intelligence.ToString();
            pBloodlust.text = "Bloodlust : " + Globals.p1Bloodlust.ToString();
            pAgility.text = "Agility : " + Globals.p1Agility.ToString();
            //ENEMY
            eName.text = "Name : Demon";
            eStrength.text = "Strength : " + Globals.eTStrength.ToString();
            eIntelligence.text = "Intelligence : " + Globals.eTIntelligence.ToString();
            eBloodlust.text = "Bloodlust : " + Globals.eTBloodlust.ToString();
            eAgility.text = "Agility : " + Globals.eTAgility.ToString();
        }
    }
}
