using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuResult : MonoBehaviour
{
    [SerializeField] private Text txtResult;
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
            txtResult.text = "You Win";
        else if (!Globals.p1Win)
            txtResult.text = "You Lose";
    }
    public void ChangeDeck()
    {
        Time.timeScale = 1f;
        Globals.menuResult = false;
        Globals.p1Life = Globals.p1MaxLife;
        Globals.e1Life = Globals.e1MaxLife;
        SceneManager.LoadScene("Select Cards");
    }
    public void TryAgain()
    {
        Time.timeScale = 1f;
        Globals.menuResult = false;
        Globals.p1Life = Globals.p1MaxLife;
        Globals.e1Life = Globals.e1MaxLife;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
