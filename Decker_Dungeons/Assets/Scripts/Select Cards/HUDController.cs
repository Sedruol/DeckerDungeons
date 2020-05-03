using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnSave;
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnOptions;
    [SerializeField] private GameObject optionsMenu;
    [Header("Menus")]
    [SerializeField] private Button btnBackOptions;
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnNoMusic;
    [SerializeField] private Slider slider;
    private bool vOptions;
    private float tempVolume;
    // Start is called before the first frame update
    void Start()
    {
        vOptions = false;
        optionsMenu.SetActive(vOptions);
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
        btnBack.onClick.AddListener(() => Back());
        btnOptions.onClick.AddListener(() => Options());
        btnBackOptions.onClick.AddListener(() => Options());
        btnMusic.onClick.AddListener(() => DesactivateMusic());
        btnNoMusic.onClick.AddListener(() => ActivateMusic());
        btnStart.onClick.AddListener(() => StartGame());
    }
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Options()
    {
        vOptions = !vOptions;
        optionsMenu.SetActive(vOptions);
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
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
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
