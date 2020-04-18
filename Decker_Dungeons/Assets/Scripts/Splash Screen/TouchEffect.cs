using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchEffect : MonoBehaviour
{
    //public GameObject music;
    private string sceneName;
    private Text txtPress;
    //private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = "Main Menu";
        txtPress = GetComponent<Text>();
    }

    private void OnMouseEnter()
    {
        txtPress.color = new Color(0f, 255f, 70f);
    }
    private void OnMouseExit()
    {
        txtPress.color = new Color(176f, 242f, 184f);
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            txtPress.color = new Color(0f, 255f, 70f);
            SceneManager.LoadScene(sceneName);
        }
    }
}
