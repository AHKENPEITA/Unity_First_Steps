using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    
    public Rigidbody rd;
    public int score;
    public Text ScoreText;
    public Text TipText;
    public Text CoinText;
    public Text FirstTip;
    public Text WinText;
    bool jumped;
    int jumpstage;
    bool jumping;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("游戏开始了");
        rd = GetComponent<Rigidbody>();
        score = 0;
        jumped = false;
        jumpstage = 0;
        jumping = false;
     
    }




    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Mouse X");
        float Y = Input.GetAxis("Mouse Y");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float j = Input.GetAxis("Jump");

        if ((X != 0) || (Y != 0)||(h!=0)||(v!=0))
        {
            FirstTip.text = "";
        }

    
        rd.AddForce(new Vector3(5*h, 0, 5*v));
        rd.AddForce(new Vector3(10*X, 0, 10*Y));
       
        if (j > 0)
        {
            if (jumping == false)
            {
                jumped = true;
                TipText.text = " ";
                jumpstage = 1;
                jumping = true;
            }
        }
        if (jumpstage > 0)
        {
            if (jumpstage < 5)
            {
                rd.AddForce(new Vector3(0, 150, 0));
            }
            jumpstage++;
            
            
        }
        
        if ((score == 11)&&(jumped==false))
        {
            TipText.text = "按“Space”以跳跃！";
        }
        if (score == 32)
        {
            WinText.gameObject.SetActive(true);
        }
       
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Food")
        {
            Destroy(other.gameObject);
            score++;
            ScoreText.text = "  得分：" + score;
            CoinText.text = "金币：" + (32-score) + "/32";
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumping = false;
            jumpstage = 0;
        }
    }

}
