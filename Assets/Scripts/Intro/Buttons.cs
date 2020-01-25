using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Sprite sound_on, sound_off;
    public float rise = 1.1f, decrease = 1.0f;
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(rise, rise, rise);
    
    }
    private void Start()
    {
        if(gameObject.name == "Settings")
        {
            if(PlayerPrefs.GetString("Music") == "off")
            {
                transform.GetChild(0).GetComponent<Image>().sprite = sound_off;
                AudioListener.volume = 0f;
            }
        }
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(decrease, decrease, decrease);
    }
    private void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        switch (gameObject.name){
            case "Instagram":
                Application.OpenURL("https://www.instagram.com");
                break;
            case "Music":
                if (PlayerPrefs.GetString("Music") == "off")
                {
                    GetComponent<Image>().sprite = sound_on;
                    PlayerPrefs.SetString("Music", "on");
                    AudioListener.volume = 1f;
                }
                else { 
                    GetComponent<Image>().sprite = sound_off; 
                    PlayerPrefs.SetString("Music", "off");
                    AudioListener.volume = 0f;
                }
                break;
            case "Settings":
                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
                break;
        }
    }
}
