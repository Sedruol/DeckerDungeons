using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool vOptions;
    private bool vCredits;
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
    public Button btnBackOptions;
    public Button btnMusic;
    public Button btnNoMusic;
    public Button btnBackCredits;

    private float tempVolume;
    // Start is called before the first frame update
    void Start()
    {
        vOptions = false;
        vCredits = false;
        optionsMenu.SetActive(vOptions);
        creditsMenu.SetActive(vCredits);
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
        btnNewAdventure.onClick.AddListener(()=> NewAdventure());
        btnOptions.onClick.AddListener(()=> Options());
        btnBackOptions.onClick.AddListener(() => Options());
        btnCredits.onClick.AddListener(()=> Credits());
        btnBackCredits.onClick.AddListener(() => Credits());
        btnBack.onClick.AddListener(() => Back());
        btnMusic.onClick.AddListener(() => DesactivateMusic());
        btnNoMusic.onClick.AddListener(() => ActivateMusic());
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
        SceneManager.LoadScene("Select Cards");
    }
    public void Options()
    {
        vOptions = !vOptions;
        optionsMenu.SetActive(vOptions);
    }
    public void Credits()
    {
        vCredits = !vCredits;
        creditsMenu.SetActive(vCredits);
    }
    public void Back()
    {
        SceneManager.LoadScene("Splash Screen");
    }
    // Update is called once per frame
    void Update()
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
