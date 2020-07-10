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
    [SerializeField] private Slider sliderFx;
    [Header("Main Menu")]
    public Button btnNewAdventure;
    public Button btnOptions;
    public Button btnCredits;
    public Button btnBack;
    [Header("Menus")]
    public Button btnMusic;
    public Button btnNoMusic;
    [SerializeField] private Button btnFx;
    [SerializeField] private Button btnNoFx;

    private float tempVolume;
    private float tempFxVolume;
    // Start is called before the first frame update
    private void Awake()
    {
        Globals.e1Died = false;
        Globals.e2Died = false;
        Globals.e3Died = false;
        Globals.e4Died = false;
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
        sliderFx.value = Globals.fxVolume;
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
        btnFx.onClick.AddListener(() => DesactivateFx());
        btnNoFx.onClick.AddListener(() => ActivateFx());
        ////
        Globals.volume = slider.value;
        audioSource.volume = Globals.volume;
        Globals.fxVolume = sliderFx.value;
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

    public void DesactivateFx()
    {
        tempFxVolume = sliderFx.value;
        sliderFx.value = 0;
    }

    public void ActivateFx()
    {
        sliderFx.value = tempFxVolume;
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
            Globals.fxVolume = sliderFx.value;
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
            if (sliderFx.value > 0f && sliderFx.value <= 1f)
            {
                btnFx.gameObject.SetActive(true);
                btnNoFx.gameObject.SetActive(false);
            }
            else if (sliderFx.value == 0f)
            {
                btnFx.gameObject.SetActive(false);
                btnNoFx.gameObject.SetActive(true);
            }
        }
    }
}
