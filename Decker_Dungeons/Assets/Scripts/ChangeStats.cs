using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private string roomName;
    private void Awake()
    {
        roomName = SceneManager.GetActiveScene().name;
    }
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
        if (roomName == "Level 1")
            eName.text = "Name : Demon";
        else if (roomName == "Level 2")
            eName.text = "Name : Muk";
        else if (roomName == "Level 3")
            eName.text = "Name : Bug";
        else if (roomName == "Level 4")
            eName.text = "Name : Boss";
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
            pStrength.text = "Strength : " + Globals.p1Strength.ToString();
            pIntelligence.text = "Intelligence : " + Globals.p1Intelligence.ToString();
            pBloodlust.text = "Bloodlust : " + Globals.p1Bloodlust.ToString();
            pAgility.text = "Agility : " + Globals.p1Agility.ToString();
            //ENEMY
            eStrength.text = "Strength : " + Globals.eTStrength.ToString();
            eIntelligence.text = "Intelligence : " + Globals.eTIntelligence.ToString();
            eBloodlust.text = "Bloodlust : " + Globals.eTBloodlust.ToString();
            eAgility.text = "Agility : " + Globals.eTAgility.ToString();
            Globals.changeStats = false;
        }
    }
}
