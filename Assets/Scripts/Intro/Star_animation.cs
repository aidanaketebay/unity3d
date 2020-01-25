using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_animation : MonoBehaviour
{
    public SpriteRenderer star;
    private float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 3f);  //star disappears
    }

    // Update is called once per frame
    void Update()
    {
        star.color = new Color(star.color.r, star.color.g, star.color.b, Mathf.PingPong(Time.time/3f, 1.0f));
        //moving the star
        transform.position = transform.position + transform.position * Time.deltaTime * speed;
    }
}