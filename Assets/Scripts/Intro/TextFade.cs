using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextFade : MonoBehaviour
{
    private Text text;
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.PingPong(Time.time/3.0f, 1.0f));
        outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, Mathf.PingPong(Time.time / 3.0f, 0.8f));
    }
}
