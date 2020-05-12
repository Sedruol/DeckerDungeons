using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button btnHit;
    [SerializeField] private Button btnOptions;
    [SerializeField] private Button btnBackOptions;
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnNoMusic;
    [Header("GameObjects")]
    [SerializeField] private GameObject menuResult;
    [SerializeField] private GameObject menuOptions;
    [SerializeField] private Slider slider;
    [SerializeField] private Text txtTitle;
    private float tempVolume;
    private int temp;
    private bool vOptions;
    private AudioSource audioSource;
    private float timeVisibleTitle;
    private bool startDuel;
    // Start is called before the first frame update
    private void Awake()
    {
        startDuel = true;
    }
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
        timeVisibleTitle = 0f;
        if (startDuel)
        {
            startDuel = false;
            if (Globals.p1Initiative >= Globals.e1Initiative)
            {
                txtTitle.text = "You start the fight";
                txtTitle.gameObject.SetActive(true);
                Globals.p1CanAttack = true;
                Globals.e1CanAttack = false;
            }
            else if(Globals.p1Initiative < Globals.e1Initiative)
            {
                txtTitle.text = "Enemy start the fight";
                txtTitle.gameObject.SetActive(true);
                Globals.p1CanAttack = false;
                Globals.e1CanAttack = true;
            }
        }
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
            Globals.p1BasicAttack = true;
            Globals.p1CanAttack = false;
            Debug.Log(Globals.e1Life);
        }
        else if (!Globals.p1CanAttack)
        {
            txtTitle.text = "You can attack, it's enemy's turn";
            txtTitle.gameObject.SetActive(true);
            //Debug.Log("You can attack, it's enemy's turn");
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
        if (txtTitle.IsActive())
        {
            timeVisibleTitle += Time.deltaTime;
            if (timeVisibleTitle >= 1f)
            {
                //Debug.Log("se activo la evasion");
                txtTitle.gameObject.SetActive(false);
                timeVisibleTitle = 0;
            }
        }
    }
}
