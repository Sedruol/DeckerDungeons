using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button btnHit;
    public GameObject menuResult;
    private int temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = Globals.p1Mana;
        btnHit.onClick.AddListener(() => OnHit());
        menuResult.SetActive(false);
    }

    public void OnHit()
    {
        if (Globals.p1CanAttack)
        {
            Globals.e1Life -= 10;
            Globals.p1CanAttack = false;
            Globals.e1CanAttack = true;
            Debug.Log(Globals.e1Life);
        }
        else if (!Globals.p1CanAttack)
        {
            Debug.Log("You can attack, it's enemy's turn");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Globals.menuResult)
        {
            Globals.p1Mana = temp;
            menuResult.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
