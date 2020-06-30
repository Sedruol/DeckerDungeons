using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterLife : MonoBehaviour
{
    [SerializeField] private Text txtActualLifePlayer;
    [SerializeField] private Text txtActualLifeEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtActualLifePlayer.text = "" + Globals.p1Life;
        txtActualLifeEnemy.text = "" + Globals.eTLife;
        if (Globals.p1Life <= 0)
            txtActualLifePlayer.text = "" + 0;
        if (Globals.eTLife <= 0)
            txtActualLifeEnemy.text = "" + 0;
    }
}
