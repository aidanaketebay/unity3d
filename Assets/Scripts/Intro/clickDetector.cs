using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickDetector : MonoBehaviour
{ 
    private GameObject namee, tapStart, buttons,main_cube;
    private bool isClicked = false;
    public GameObject Bochka, Player,ground, music;
    public bool isStarted=false;
    private void OnMouseDown()
    {
        if (isClicked == false)
        {
            GetComponent<AudioSource>().Play();
            tapStart = GameObject.FindGameObjectWithTag("tapStart");

            tapStart.SetActive(false);

            namee = GameObject.FindGameObjectWithTag("gameName");
            namee.GetComponent<Text>().text = "0";

            ground.SetActive(true);

            if (music.activeSelf)
            {
                for (int i = 0; i < music.transform.parent.transform.childCount; i++)
                    music.transform.parent.transform.GetChild(i).gameObject.SetActive(false);
            }

            buttons = GameObject.FindGameObjectWithTag("buttons");
            buttons.GetComponent<ScrollObjects>().speed = -10f;
            buttons.GetComponent<ScrollObjects>().checkPos = -790f;

            main_cube = GameObject.FindGameObjectWithTag("Player");
            main_cube.GetComponent<Animation>().Play("Transform_begin_cube");
            isClicked = true;
            isStarted = true;
        }
        StartCoroutine(waiting());
        Player.GetComponent<Rigidbody>().useGravity=true;


    }
    IEnumerator waiting()
    {
        yield return new WaitForSeconds(6f);
    }
}
