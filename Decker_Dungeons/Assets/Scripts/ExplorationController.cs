using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExplorationController : MonoBehaviour
{
    [SerializeField] private GameObject menuOptions;
    [SerializeField] private Slider slider;
    [Header("Buttons")]
    [SerializeField] private Button btnDeck;
    [SerializeField] private Button btnOptions;
    [SerializeField] private Button btnBackOptions;
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnNoMusic;
    private float tempVolume;
    private bool vOptions;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        vOptions = false;
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
        btnOptions.onClick.AddListener(() => GoOptions());
        btnBackOptions.onClick.AddListener(() => GoOptions());
        btnMusic.onClick.AddListener(() => DesactivateMusic());
        btnNoMusic.onClick.AddListener(() => ActivateMusic());
        btnDeck.onClick.AddListener(() => GoSelectCards());
        menuOptions.SetActive(vOptions);
    }

    public void GoSelectCards()
    {
        Globals.lastRoom = SceneManager.GetActiveScene().name;//posible cambio a script door portal
        SceneManager.LoadScene("Select Cards");
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

    public void GoOptions()
    {
        vOptions = !vOptions;
        menuOptions.SetActive(vOptions);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
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
