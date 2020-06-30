using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpMenuAnimation : MonoBehaviour
{
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject help1;
    [SerializeField] private GameObject help2;
    [SerializeField] private GameObject help3;
    [SerializeField] private GameObject help4;
    [SerializeField] private GameObject help5;
    [SerializeField] private Text txtHelpPage;
    [SerializeField] private Button btnLastPage;
    [SerializeField] private Button btnNextPage;
    [SerializeField] private Button btnBackHelp;
    private Animator anim;
    private int numPage;
    // Start is called before the first frame update
    void Start()
    {
        numPage = 1;
        txtHelpPage.text = numPage + "/5";
        anim = GetComponent<Animator>();
        btnBackHelp.onClick.AddListener(() => CloseHelpMenu());
        btnLastPage.onClick.AddListener(() => BeforePage());
        btnNextPage.onClick.AddListener(() => NextPage());
    }
    private void OpenHelpMenu()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == "Help2" || transform.GetChild(i).gameObject.name == "Help3" ||
                transform.GetChild(i).gameObject.name == "Help4" || transform.GetChild(i).gameObject.name == "Help5" ||
                transform.GetChild(i).gameObject.name == "btnLastPage")
                transform.GetChild(i).gameObject.SetActive(false);
            else
                transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    private void BeforePage()
    {
        if (numPage > 1)
        {
            numPage--;
            txtHelpPage.text = numPage + "/5";
            if (numPage == 1)
            {
                help1.SetActive(true);
                help2.SetActive(false);
                help3.SetActive(false);
                help4.SetActive(false);
                help5.SetActive(false);
                btnLastPage.gameObject.SetActive(false);
            }
            else if (numPage == 2)
            {
                help1.SetActive(false);
                help2.SetActive(true);
                help3.SetActive(false);
                help4.SetActive(false);
                help5.SetActive(false);
            }
            else if (numPage == 3)
            {
                help1.SetActive(false);
                help2.SetActive(false);
                help3.SetActive(true);
                help4.SetActive(false);
                help5.SetActive(false);
            }
            else if (numPage == 4)
            {
                help1.SetActive(false);
                help2.SetActive(false);
                help3.SetActive(false);
                help4.SetActive(true);
                help5.SetActive(false);
                btnNextPage.gameObject.SetActive(true);
            }
        }
    }
    private void NextPage()
    {
        if (numPage < 5)
        {
            numPage++;
            txtHelpPage.text = numPage + "/5";
            if (numPage == 2)
            {
                help1.SetActive(false);
                help2.SetActive(true);
                help3.SetActive(false);
                help4.SetActive(false);
                help5.SetActive(false);
                btnLastPage.gameObject.SetActive(true);
            }
            else if (numPage == 3)
            {
                help1.SetActive(false);
                help2.SetActive(false);
                help3.SetActive(true);
                help4.SetActive(false);
                help5.SetActive(false);
            }
            else if (numPage == 4)
            {
                help1.SetActive(false);
                help2.SetActive(false);
                help3.SetActive(false);
                help4.SetActive(true);
                help5.SetActive(false);
            }
            else if (numPage == 5)
            {
                help1.SetActive(false);
                help2.SetActive(false);
                help3.SetActive(false);
                help4.SetActive(false);
                help5.SetActive(true);
                btnNextPage.gameObject.SetActive(false);
            }
        }
    }
    private void CloseHelpMenu()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        anim.SetBool("close", true);
    }
    private void EndCloseHelpMenu()
    {
        numPage = 1;
        helpMenu.SetActive(false);
        anim.SetBool("close", false);
        Globals.pauseActive = false;
    }
}
