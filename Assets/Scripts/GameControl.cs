using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollingSpeed;
    public int Score = 0;
    public Text scoreText;
    public Text levelText;
    public int level;
    public int levelUpScore;
    // Start is called before the first frame update
    void Awake()
    {
        scrollingSpeed = -2;
        level = 1;
        levelUpScore = 10;
        if ((instance == null))
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }        
    }
    /* void Start()
      {        
      }*/

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
    public void BirdScored()
    {
        if(gameOver )
        {
            return;
        }
        Score++;        
        if (Score >= (level * levelUpScore))
        {
            level++;
            Debug.Log("Scrolling Speed Before" + scrollingSpeed);
            scrollingSpeed += 50;
            Debug.Log("Bird Up Force Before " + Bird.upForce);
            Bird.upForce +=30;
            Debug.Log("Bird Up Force " + Bird.upForce);
            Debug.Log("Scrolling Speed " + scrollingSpeed);
            levelText.text = "Level: " + level.ToString();
        }
                            
        scoreText.text ="Score: "+ Score.ToString();               
    }  
   /* public void LevelUpSpeed()
    {
        if (Score >= (level * levelUpScore))
        {
            level++;
            scrollingSpeed *= 2f;
            Bird.upForce *= 100;
            Debug.Log("Bird Up Force " + Bird.upForce);
            Debug.Log("Scrolling Speed " + scrollingSpeed);
            //rb2d.velocity = new Vector2(GameControl.instance.scrollingSpeed, 0);
            //levelText.text = "Level: " + level.ToString();
        }
    }*/
}

