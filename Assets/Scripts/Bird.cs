using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D rb2d;
    public static float  upForce ;
    private Animator anim;
    private float yRange = 4.59f;

    //public float 
    // Start is called before the first frame update
    void Start()
    {
        upForce = 200f;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameControl.instance.gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        //rb2d.AddForce(new Vector2(300f, 0));
        if (isDead==false)
        {
            

            if (Input.GetMouseButtonDown(0)||Input.touchCount>0)
            {
                rb2d.velocity=Vector2.zero;
                //GameControl.instance.LevelUpSpeed();
                /*if (GameControl.instance.Score >= (GameControl.instance.level * GameControl.instance.levelUpScore))
                {
                    Bird.upForce *= 100;
                    rb2d.AddForce(new Vector2(0, upForce));
                    Debug.Log("Bird Up Force " + Bird.upForce);
                }*/
                    rb2d.AddForce(new Vector2(0,upForce));
                anim.SetTrigger("Flap");
                /*Vector3 PlayerPos = transform.position;
                PlayerPos.y = Mathf.Clamp(PlayerPos.x, minY, maxY);
                transform.position = PlayerPos;*/
            }
        }
       
    }
    void OnCollisionEnter2D()
    {
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDie();
        rb2d.velocity=Vector2.zero;
    }
}
