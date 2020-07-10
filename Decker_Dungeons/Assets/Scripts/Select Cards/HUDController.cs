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
    //[SerializeField] private Button btnStart;
    [SerializeField] private Button btnOptions;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject cards;
    [Header("Menus")]
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnNoMusic;
    [SerializeField] private Button btnFx;
    [SerializeField] private Button btnNoFx;
    [SerializeField] private Slider slider;
    [SerializeField] private Slider sliderFx;
    private float tempVolume;
    private float tempFxVolume;
    private bool canFigth;
    private bool visibleText;
    private float timeVisibleText;

    private void Awake()
    {
        for (int i = 0; i < Globals.decklist.Count; i++)
        {
            Globals.decklist.Remove(Globals.decklist[i]);
        }
        audioSource = GetComponent<AudioSource>();
        slider.value = Globals.volume;
        sliderFx.value = Globals.fxVolume;
    }

    // Start is called before the first frame update
    void Start()
    {
        optionsMenu.SetActive(false);
        btnBack.onClick.AddListener(() => Back());
        btnSave.onClick.AddListener(() => Save());
        btnOptions.onClick.AddListener(() => Options());
        btnMusic.onClick.AddListener(() => DesactivateMusic());
        btnNoMusic.onClick.AddListener(() => ActivateMusic());
        btnFx.onClick.AddListener(() => DesactivateFx());
        btnNoFx.onClick.AddListener(() => ActivateFx());
        //btnStart.onClick.AddListener(() => StartGame());
        canFigth = false;
        timeVisibleText = 0f;
        visibleText = true;
        ///////
        Globals.volume = slider.value;
        audioSource.volume = Globals.volume;
        Globals.fxVolume = sliderFx.value;
    }
    public void Back()
    {
        if (canFigth)
        {
            if (Globals.saveDeck)
            {
                Globals.saveDeck = false;
                Globals.firstLevel = false;
                if(Globals.canHeal)
                    SceneManager.LoadScene("Healing Room");
                else if (!Globals.canHeal)
                    SceneManager.LoadScene("Exploration");
            }
            else if (!Globals.saveDeck)
            {
                timeVisibleText = 0f;
                visibleText = true;
                txtTitle.text = "Please, save the changes in your deck";
            }
        }
        else if (!canFigth)
        {
            if (Globals.saveDeck)
            {
                timeVisibleText = 0f;
                visibleText = true;
                txtTitle.text = "You can't figth with this deck";
            }
            else
            {
                timeVisibleText = 0f;
                visibleText = true;
                txtTitle.text = "Please, save the changes in your deck";
            }
        }
    }
    public void Save()
    {
        int cantCards = 0;
        bool change = true;
        bool remove = true;
        for (int i = 0; i < cards.transform.childCount; i++)
        {
            if (cards.transform.GetChild(i).GetComponent<ScaleCard>().selected)
                cantCards++;
        }
        //Debug.Log("contador" + Globals.decklist.Count);
        while (change)
        {
            if (Globals.decklist.Count == 0) remove = false;
            if (remove) {
                for (int i = 0; i < Globals.decklist.Count; i++)
                {
                    Debug.Log("cartita:" + i);
                    Globals.decklist.Remove(Globals.decklist[i]);
                    Debug.Log("new cont" + Globals.decklist.Count);
                }
                //remove = false;
                Debug.Log("cards con remove:" + Globals.decklist.Count);
            }
            //Debug.Log(cantCards);
            else if (!remove){
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
                    Globals.saveDeck = true;
                    //Debug.Log("You can fight with this deck");
                }
                else if (cantCards < 6)
                {
                    canFigth = false;
                    timeVisibleText = 0f;
                    visibleText = true;
                    txtTitle.text = "You need more cards in your deck to fight";
                    Globals.saveDeck = true;
                    //Debug.Log("You need more cards in your deck to fight");
                }
                else if (cantCards > 10)
                {
                    canFigth = false;
                    timeVisibleText = 0f;
                    visibleText = true;
                    txtTitle.text = "You exceeded the maximum number of cards";
                    Globals.saveDeck = true;
                    //Debug.Log("You exceeded the maximum number of cards to fight");
                }
                change = false;
            }
        }
        //Debug.Log("cards:" + Globals.decklist.Count);
        //Globals.saveDeck = true;
    }
    public void Options()
    {
        Globals.pauseActive = true;
        optionsMenu.SetActive(true);
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

    /*public void StartGame()
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
    }*/

    // Update is called once per frame
    void Update()
    {
        txtTitle.gameObject.SetActive(visibleText);

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
