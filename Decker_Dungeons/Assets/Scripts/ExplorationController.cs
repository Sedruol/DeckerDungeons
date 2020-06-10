using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExplorationController : MonoBehaviour
{
    [SerializeField] private GameObject menuOptions;
    [SerializeField] private Slider slider;
    [SerializeField] private Text txtTitle;
    [SerializeField] private GameObject arrowDeck;
    [SerializeField] private GameObject arrowDoor;
    [SerializeField] private GameObject door;
    [Header("Buttons")]
    [SerializeField] private Button btnDeck;
    [SerializeField] private Button btnOptions;
    [SerializeField] private Button btnBackOptions;
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnNoMusic;
    private float tempVolume;
    private bool vOptions;
    private AudioSource audioSource;
    private float vTitle;
    private SpriteRenderer srA1;
    private SpriteRenderer srA2;
    //fade-parpadeo
    IEnumerator fade(SpriteRenderer sr)
    {
        //cambio el layer a invulnerable, el cual no tiene iteracción con los enemigos
        //gameObject.layer = 10;
        //for (int i = _timesToBlink; i > 0;)
        //{
        while (Globals.firstLevel || !Globals.firstLevel)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.5f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
            //i--;
        //}
        //vuelvo a poner el layer como player, el cual si iteractua con los enemigos
        //gameObject.layer = 8;
    }
    private void Awake()
    {
        srA1 = arrowDeck.GetComponent<SpriteRenderer>();
        srA2 = arrowDoor.GetComponent<SpriteRenderer>();
        //sr = arrowDeck.GetComponent<SpriteRenderer>();
        if (Globals.firstLevel)
        {
            arrowDeck.gameObject.SetActive(true);
            StartCoroutine(fade(srA1));
        }
        else if (!Globals.firstLevel)
        {
            arrowDoor.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + 2.75f,
                door.transform.position.z);
            arrowDoor.gameObject.SetActive(true);
            StartCoroutine(fade(srA2));
            arrowDeck.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        vOptions = false;
        vTitle = 0f;
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
        if (Globals.selectYourDeck)
        {
            txtTitle.gameObject.SetActive(true);
            txtTitle.text = "First, select your deck";
            Globals.selectYourDeck = false;
        }
        if (txtTitle.IsActive())
        {
            vTitle += Time.deltaTime;
            if (vTitle >= 2f)
            {
                txtTitle.gameObject.SetActive(false);
                vTitle = 0;
            }
        }
        //si la señal de flecha es false, flecha de la puerta
    }
}
