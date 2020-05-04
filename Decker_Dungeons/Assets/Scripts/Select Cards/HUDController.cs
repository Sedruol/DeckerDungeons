using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private Text txtTitle;
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnSave;
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnOptions;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject cards;
    [Header("Menus")]
    [SerializeField] private Button btnBackOptions;
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnNoMusic;
    [SerializeField] private Slider slider;
    private bool vOptions;
    private float tempVolume;
    private bool canFigth;
    private bool visibleText;
    private float timeVisibleText;
    // Start is called before the first frame update
    void Start()
    {
        vOptions = false;
        optionsMenu.SetActive(vOptions);
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
        btnBack.onClick.AddListener(() => Back());
        btnSave.onClick.AddListener(() => Save());
        btnOptions.onClick.AddListener(() => Options());
        btnBackOptions.onClick.AddListener(() => Options());
        btnMusic.onClick.AddListener(() => DesactivateMusic());
        btnNoMusic.onClick.AddListener(() => ActivateMusic());
        btnStart.onClick.AddListener(() => StartGame());
        canFigth = false;
        timeVisibleText = 0f;
        visibleText = true;
    }
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Save()
    {
        int cantCards = 0;
        for (int i = 0; i < cards.transform.childCount; i++)
        {
            if (cards.transform.GetChild(i).GetComponent<ScaleCard>().selected)
                cantCards++;
        }
        for (int i = 0; i < Globals.decklist.Count; i++)
        {
            Globals.decklist.Remove(Globals.decklist[i]);
        }
        Debug.Log(cantCards);
        if (cantCards >= 6 && cantCards <= 10)
        {
            for (int i = 0; i < cards.transform.childCount; i++)
            {
                if (cards.transform.GetChild(i).GetComponent<ScaleCard>().selected)
                    Globals.decklist.Add(Globals.PosibleDeckList[i]);
            }
            canFigth = true;
            timeVisibleText = 0f;
            visibleText = true;
            txtTitle.text = "You can fight with this deck";
            //Debug.Log("You can fight with this deck");
        }
        else if (cantCards < 6)
        {
            canFigth = false;
            timeVisibleText = 0f;
            visibleText = true;
            txtTitle.text = "You need more cards in your deck to fight";
            //Debug.Log("You need more cards in your deck to fight");
        }
        else if (cantCards > 10)
        {
            canFigth = false;
            timeVisibleText = 0f;
            visibleText = true;
            txtTitle.text = "You exceeded the maximum number of cards to fight";
            //Debug.Log("You exceeded the maximum number of cards to fight");
        }
        Globals.saveDeck = true;
    }
    public void Options()
    {
        vOptions = !vOptions;
        optionsMenu.SetActive(vOptions);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
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
        if (canFigth)
        {
            if (Globals.saveDeck)
            {
                Globals.saveDeck = false;
                SceneManager.LoadScene("Level 1");
            }
            else if (!Globals.saveDeck)
            {
                timeVisibleText = 0f;
                visibleText = true;
                txtTitle.text = "Please, save the changes in your deck before fight";
            }
        }
        else if (!canFigth)
        {
            if (!Globals.saveDeck)
            {
                timeVisibleText = 0f;
                visibleText = true;
                txtTitle.text = "Please, save the changes in your deck before fight";
            }
            else
            {
                timeVisibleText = 0f;
                visibleText = true;
                txtTitle.text = "You can't figth with this deck";
            }
            //Debug.Log("You can't figth with this deck");
        }
    }

    // Update is called once per frame
    void Update()
    {
        txtTitle.gameObject.SetActive(visibleText);
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
        if (visibleText)
        {
            timeVisibleText += Time.deltaTime;
            if (timeVisibleText >= 3f)
            {
                timeVisibleText = 0;
                visibleText = false;
            }
        }
    }
}
