using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Buttons")]
    public Button btnHit;
    public Button btnOptions;
    public Button btnBackOptions;
    public Button btnMusic;
    public Button btnNoMusic;
    [Header("GameObjects")]
    public GameObject menuResult;
    public GameObject menuOptions;
    public Slider slider;

    private float tempVolume;
    private int temp;
    private bool vOptions;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        temp = Globals.p1Mana;
        vOptions = false;
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
        btnHit.onClick.AddListener(() => OnHit());
        btnOptions.onClick.AddListener(() => GoOptions());
        btnBackOptions.onClick.AddListener(() => GoOptions());
        btnMusic.onClick.AddListener(() => DesactivateMusic());
        btnNoMusic.onClick.AddListener(() => ActivateMusic());
        menuResult.SetActive(false);
        menuOptions.SetActive(vOptions);
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

    public void OnHit()
    {
        if (Globals.p1CanAttack)
        {
            Globals.e1Life -= 10;
            Globals.p1CanAttack = false;
            Globals.e1CanAttack = true;
            Debug.Log(Globals.e1Life);
        }
        else if (!Globals.p1CanAttack)
        {
            Debug.Log("You can attack, it's enemy's turn");
        }
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
        if (Globals.menuResult)
        {
            Globals.p1Mana = temp;
            menuResult.SetActive(true);
            Time.timeScale = 0f;
        }
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
