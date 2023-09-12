using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    bool add_force;
    public GameObject Splash_Prefab;
    
    int score;
    public Text score_txt;

    
    public Text highscore_txt;
    public GameObject GameOverMenu;

    public float force;

    void Start()
    {
        add_force = true;
        highscore_txt.text = "HighScore: " + PlayerPrefs.GetInt("highscore");

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "h_piece" && add_force)
        {
            add_force = false;
            Invoke("fix", 0.5f);

            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 1f, 0f) * Time.deltaTime * force);
            
            GameObject splash = Instantiate(Splash_Prefab);
            Vector3 pos = transform.position;
            pos.y = pos.y - 0.2f;
            splash.transform.position = pos;
            
            splash.transform.SetParent(GameObject.Find("helix").transform);

        }
        else if (col.gameObject.tag == "gameover")
        {
            GameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void fix()
    {
        add_force = true;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "score")
        {
            score++;
            int highscore = PlayerPrefs.GetInt("highscore");
            
            if(score > highscore)
            {
               
                PlayerPrefs.SetInt("highscore",score);
                highscore_txt.text = "HighScore: " + PlayerPrefs.GetInt("highscore");
            }
            score_txt.text = score + "";

        }
    }
    void Update()
    {
        if(transform.position.y + 1.20f < Camera.main.transform.position.y)
        {
            Vector3 pos = Camera.main.transform.position;
            pos.y = transform.position.y + 1.20f;
            Camera.main.transform.position = pos;
        }
    }
    
}