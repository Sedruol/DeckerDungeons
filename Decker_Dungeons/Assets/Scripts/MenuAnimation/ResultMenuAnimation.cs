using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultMenuAnimation : MonoBehaviour
{
    [SerializeField] private GameObject resultMenu;
    [SerializeField] private Text txtResult;
    [SerializeField] private Text txtInfo;
    [SerializeField] private Button btnChangeDeck;
    [SerializeField] private Button btnExit;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        btnChangeDeck.onClick.AddListener(() => ChangeDeck());
        btnExit.onClick.AddListener(() => Exit());
        if (Globals.p1Win)
        {
            txtResult.text = "You Win";
            txtInfo.text = "Thanks for complete this prototype, you can go to the main menu to play again";
        }
        else if (!Globals.p1Win)
        {
            txtResult.text = "You Lose";
            txtInfo.text = "Your journey ends here, try with a different deck";
        }
    }
    public void ChangeDeck()
    {
        CloseResultMenu();
    }
    public void Exit()
    {
        Globals.pauseActive = false;
        Application.Quit();
    }
    private void OpenResultMenu()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }
    private void CloseResultMenu()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
        anim.SetBool("close", true);
    }
    private void EndCloseResultMenu()
    {
        resultMenu.SetActive(false);
        anim.SetBool("close", false);
        Globals.pauseActive = false;
        Globals.menuResult = false;
        Globals.p1Life = Globals.p1MaxLife;
        Globals.eTLife = Globals.eTMaxLife;
        SceneManager.LoadScene("Main Menu");
    }
}
