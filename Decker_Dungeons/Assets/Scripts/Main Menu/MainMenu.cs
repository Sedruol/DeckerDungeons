using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button btnNewAdventure;
    public Button btnOptions;
    public Button btnCredits;
    public Button btnBack;
    // Start is called before the first frame update
    void Start()
    {
        btnNewAdventure.onClick.AddListener(()=> NewAdventure());
        btnOptions.onClick.AddListener(()=> Options());
        btnCredits.onClick.AddListener(()=> Credits());
        btnBack.onClick.AddListener(() => Back());
    }
    public void NewAdventure()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Options()
    {

    }
    public void Credits()
    {

    }
    public void Back()
    {
        SceneManager.LoadScene("Splash Screen");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
