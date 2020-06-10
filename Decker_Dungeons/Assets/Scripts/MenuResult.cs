using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuResult : MonoBehaviour
{
    [SerializeField] private Text txtResult;
    [SerializeField] private Text txtInfo;
    [SerializeField] private Button btnChangeDeck;
    [SerializeField] private Button btnTryAgain;
    [SerializeField] private Button btnExit;
    // Start is called before the first frame update
    void Start()
    {
        btnChangeDeck.onClick.AddListener(() => ChangeDeck());
        btnTryAgain.onClick.AddListener(() => TryAgain());
        btnExit.onClick.AddListener(() => Exit());
        if (Globals.p1Win)
        {
            txtResult.text = "YOU WIN";
            txtInfo.text = "Thanks  for  complete  this  prototype,  you  can  go  to  the  main menu  to  play  again";
        }
        else if (!Globals.p1Win)
        {
            txtResult.text = "YOU LOSE";
            txtInfo.text = "Your  journey  ends  here,  try  with  a  different  deck";
        }
    }
    public void ChangeDeck()
    {
        /*for (int i = 0; i < Globals.decklist.Count; i++)
        {
            Globals.decklist.Remove(Globals.decklist[i]);
        }*/
        Time.timeScale = 1f;
        Globals.menuResult = false;
        Globals.p1Life = Globals.p1MaxLife;
        Globals.eTLife = Globals.eTMaxLife;
        SceneManager.LoadScene("Main Menu");
    }
    public void TryAgain()
    {
        Time.timeScale = 1f;
        Globals.menuResult = false;
        Globals.p1Life = Globals.p1MaxLife;
        Globals.eTLife = Globals.eTMaxLife;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
