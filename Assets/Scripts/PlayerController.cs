using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody p_Rigidbody;
    private Vector3 p_Velocity = Vector3.zero;
    private Vector3 b_Velocity = Vector3.zero;
    private Collider p_Collider;
    float move;
    int counter;
    public GameObject Bochka;
    public Text  points;
    public int maxjumps = 2;
    int jumps;
    float jumpforce = 4f;
    bool grounded;
    float movespeed;
    public GameObject restart;
    public GameObject win;
    clickDetector cd;
    public GameObject cocd;

    // Start is called before the first frame update
    void Start()
    {
        p_Rigidbody = GetComponent<Rigidbody>();
        p_Collider = GetComponent<Collider>();
        // And then smoothing it out and applying it to the character
        counter = 0;
        cd = cocd.GetComponent<clickDetector>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bochka")
        {
            p_Rigidbody.gameObject.SetActive(false);
            Bochka.GetComponent<Rigidbody>().velocity = Vector3.zero;
            EndGame();
        }
        if (collision.gameObject.tag == "Ground")
        {
            jumps = maxjumps;
            grounded = true;
            movespeed = 2.0F;
        }
    }

    void EndGame()
    {
        restart.SetActive(true);
        restart.GetComponent<AudioSource>().Play();
    }

    void WinGame()
    {
        win.SetActive(true);
        win.GetComponent<AudioSource>().Play();
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void Jump()
    {
        if (jumps > 0)
        {
            p_Rigidbody.AddForce(new Vector2(0, jumpforce), ForceMode.Impulse);
            grounded = false;
            jumps = jumps - 1;
        }
        if (jumps == 0)
        {
            return;
        } 
    }

        // Update is called once per frame
    void FixedUpdate()
    {
        if (cd.isStarted == true) { 
            move = Input.GetAxisRaw("Horizontal");

            Vector3 targetVelocity = new Vector3(move * 3f, p_Rigidbody.velocity.y, transform.position.z);

            p_Rigidbody.velocity = Vector3.SmoothDamp(p_Rigidbody.velocity, targetVelocity, ref p_Velocity, 0.05f);


            Vector3 bochkaVelocity = new Vector2( -6f, Bochka.GetComponent<Rigidbody>().velocity.y);

            Bochka.GetComponent<Rigidbody>().velocity = Vector3.SmoothDamp(Bochka.GetComponent<Rigidbody>().velocity, bochkaVelocity, ref b_Velocity, 0.05f);

            if (Bochka.transform.position.x < -6.79)
            {
                Bochka.transform.position = new Vector3(6.85f, -5.11f, transform.position.z);
                counter++;
            }

            points.text = counter.ToString();

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
            if (GameObject.FindGameObjectWithTag("Player").transform.position.x > 5)
            {
                p_Rigidbody.gameObject.SetActive(false);
                Bochka.GetComponent<Rigidbody>().velocity = Vector3.zero;
                WinGame();
            }
        }
    }

}