using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public Slider slider;
    [Header("Main Menu")]
    public Button btnNewAdventure;
    public Button btnOptions;
    public Button btnCredits;
    public Button btnBack;
    [Header("Menus")]
    public Button btnMusic;
    public Button btnNoMusic;

    private float tempVolume;
    // Start is called before the first frame update
    private void Awake()
    {
        Globals.e1Died = false;
        Globals.e2Died = false;
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
    }
    void Start()
    {
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        btnNewAdventure.onClick.AddListener(()=> NewAdventure());
        btnOptions.onClick.AddListener(()=> Options());
        btnCredits.onClick.AddListener(()=> Credits());
        btnBack.onClick.AddListener(() => Back());
        btnMusic.onClick.AddListener(() => DesactivateMusic());
        btnNoMusic.onClick.AddListener(() => ActivateMusic());
        ////
        Globals.volume = slider.value;
        audioSource.volume = Globals.volume;
    }
    public void DesactivateMusic()
    {
        tempVolume = slider.value;
        slider.value = 0;
    }

    public void ActivateMusic()
    {
        slider.value = tempVolume;
    }
    public void NewAdventure()
    {
        Globals.p1Life = Globals.p1MaxLife;
        SceneManager.LoadScene("Exploration");
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
    }
    public void Credits()
    {
        creditsMenu.SetActive(true);
    }
    public void Back()
    {
        //SceneManager.LoadScene("Splash Screen");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (Globals.changeVolume)
        {
            Globals.volume = slider.value;
            audioSource.volume = Globals.volume;
            if (audioSource.volume > 0f && audioSource.volume <= 1f)
            {
                btnMusic.gameObject.SetActive(true);
                btnNoMusic.gameObject.SetActive(false);
            }
            else if (audioSource.volume == 0f)
            {
                btnMusic.gameObject.SetActive(false);
                btnNoMusic.gameObject.SetActive(true);
            }
        }
    }
}
