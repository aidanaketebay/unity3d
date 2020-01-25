using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAppears : MonoBehaviour
{
    public GameObject star;

    void Start()
    {
        StartCoroutine(appears());
       
    }

    IEnumerator appears()
    {
        while (true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height),Camera.main.farClipPlane/2));
            Instantiate(star, pos, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            yield return new WaitForSeconds(3.01f);
        }
    }
}