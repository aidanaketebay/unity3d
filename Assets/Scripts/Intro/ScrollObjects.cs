using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour
{
    public float speed = 10f;
    public float checkPos = 0.0f;
    private RectTransform rec;

    private void Start()
    {
        rec = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if(System.Math.Abs(rec.offsetMin.y - checkPos) > float.Epsilon)
        {
            rec.offsetMin += new Vector2(rec.offsetMin.x, speed);
            rec.offsetMax += new Vector2(rec.offsetMax.x, speed);
        }
    }

}
