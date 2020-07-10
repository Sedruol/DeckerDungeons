using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button btnHit;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnOptions;
    [SerializeField] private Button btnHelp;
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnNoMusic;
    [SerializeField] private Button btnFx;
    [SerializeField] private Button btnNoFx;
    [Header("GameObjects")]
    [SerializeField] private GameObject menuResult;
    [SerializeField] private GameObject menuOptions;
    [SerializeField] private GameObject menuHelp;
    [SerializeField] private GameObject Cards;
    [SerializeField] private Slider slider;
    [SerializeField] private Slider sliderFx;
    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtLifePlayer;
    [SerializeField] private Text txtLifeEnemy;
    [SerializeField] private AudioSource audioFx;
    private float tempVolume;
    private float tempFxVolume;
    private int temp;
    private AudioSource audioSource;
    private float timeVisibleTitle;
    private float timeVisibleLifeEnemy;
    public float timeVisibleLifePlayer;
    private bool startDuel;
    // Start is called before the first frame update
    private void Awake()
    {
        startDuel = true;
        btnHit.gameObject.SetActive(true);
        Cards.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
        sliderFx.value = Globals.fxVolume;
    }
    void Start()
    {
        temp = Globals.p1Mana;
        btnHit.onClick.AddListener(() => OnHit());
        btnMenu.onClick.AddListener(() => GoMenu());
        btnOptions.onClick.AddListener(() => GoOptions());
        btnHelp.onClick.AddListener(() => GoHelp());
        btnMusic.onClick.AddListener(() => DesactivateMusic());
        btnNoMusic.onClick.AddListener(() => ActivateMusic());
        btnFx.onClick.AddListener(() => DesactivateFx());
        btnNoFx.onClick.AddListener(() => ActivateFx());
        menuResult.SetActive(false);
        menuOptions.SetActive(false);
        menuHelp.SetActive(false);
        timeVisibleTitle = 0f;
        timeVisibleLifeEnemy = 0f;
        timeVisibleLifePlayer = 0f;
        if (startDuel)
        {
            startDuel = false;
            if (Globals.p1Initiative >= Globals.eTInitiative)
            {
                txtTitle.text = "You start the fight";
                txtTitle.gameObject.SetActive(true);
                Globals.p1CanAttack = true;
                Globals.eTCanAttack = false;
            }
            else if(Globals.p1Initiative < Globals.eTInitiative)
            {
                txtTitle.text = "Enemy start the fight";
                txtTitle.gameObject.SetActive(true);
                Globals.p1CanAttack = false;
                Globals.eTCanAttack = true;
            }
        }
        ////
        Globals.volume = slider.value;
        audioSource.volume = Globals.volume;
        Globals.fxVolume = sliderFx.value;
        audioFx.volume = Globals.fxVolume;
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
    public void OnHit()
    {
        if (!Globals.pauseActive)
        {
            if (Globals.p1CanAttack)
            {
                Globals.p1BasicAttack = true;
                Globals.p1CanAttack = false;
                Globals.p1CanUseCard = false;//quitar si no funca
                Globals.p1TimeToUseCard = 0f;//quitar si no funca
                Debug.Log(Globals.eTLife);
            }
            else if (!Globals.p1CanAttack)
            {
                if (Globals.eTCanAttack)
                    txtTitle.text = "You can attack, it's enemy's turn";
                else if (!Globals.eTCanAttack)
                    txtTitle.text = "You only can attack one time during your turn";
                txtTitle.gameObject.SetActive(true);
                //Debug.Log("You can attack, it's enemy's turn");
            }
        }
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void GoOptions()
    {
        Globals.pauseActive = true;
        menuOptions.SetActive(true);
    }
    public void GoHelp()
    {
        Globals.pauseActive = true;
        menuHelp.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Globals.p1CanAttack && !Globals.p1CanUseCard)//quitar si no funca
        {//quitar si no funca
            Globals.p1TimeToUseCard += 0.05f;//quitar si no funca
            if (Globals.p1TimeToUseCard > 2f)//quitar si no funca
                Globals.p1CanUseCard = true;//quitar si no funca
        }//quitar si no funca
        if (!Globals.menuResult)
        {
            menuResult.SetActive(false);
        }
        if (Globals.menuResult)
        {
            Globals.p1Mana = temp;
            Globals.pauseActive = true;
            menuResult.SetActive(true);
        }
        if (Globals.changeVolume)
        {
            Globals.volume = slider.value;
            audioSource.volume = Globals.volume;
            Globals.fxVolume = sliderFx.value;
            audioFx.volume = Globals.fxVolume;
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
        if (txtLifeEnemy.IsActive())
        {
            timeVisibleLifeEnemy += Time.deltaTime;
            if (timeVisibleLifeEnemy >= 1f)
            {
                txtLifeEnemy.gameObject.SetActive(false);
                timeVisibleLifeEnemy = 0f;
            }
        }
        if (txtLifePlayer.IsActive())
        {
            timeVisibleLifePlayer += Time.deltaTime;
            if (timeVisibleLifePlayer >= 1f)
            {
                txtLifePlayer.gameObject.SetActive(false);
                timeVisibleLifePlayer = 0f;
            }
        }
    }
}
