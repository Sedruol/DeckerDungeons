using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button btnHit;
    public Button btnOptions;
    public Button btnBackOptions;
    public GameObject menuResult;
    public GameObject menuOptions;
    public Slider slider;
    public GameObject imageMusic;
    public GameObject imageNoMusic;
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
        menuResult.SetActive(false);
        imageMusic.SetActive(true);
        imageNoMusic.SetActive(false);
        menuOptions.SetActive(vOptions);
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
            imageMusic.SetActive(true);
            imageNoMusic.SetActive(false);
        }
        else if (audioSource.volume == 0f)
        {
            imageMusic.SetActive(false);
            imageNoMusic.SetActive(true);
        }
    }
}
