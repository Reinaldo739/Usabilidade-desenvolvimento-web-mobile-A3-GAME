using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = 7f;
    private float jumpHeight = 5f;
    public bool onPlatform = true;
    private int notVisibleCount = 0;
    private int tempoDepoisMorte = 0;
    GameObject MainCanvas;
    public Text gameOverText;
    private Color hitColor;
    private Color lastColor;

    void Start()
    {
        MainCanvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
        GameOver();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onPlatform)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce
                (new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            onPlatform = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Reward")
        {
            collision.gameObject.transform.position = new Vector2(100, 100);
            Destroy(collision.gameObject);
            hitColor = collision.gameObject.GetComponent<Renderer>().material.color;
        }

        if(hitColor != lastColor)
        {
            
            MainCanvas.GetComponent<ManageCanvas>().score++;
            MainCanvas.GetComponent<ManageCanvas>().UpdateScore();  
            lastColor = hitColor; 
        }
    }

    void GameOver()
    {
        if (!(GetComponent<Renderer>().isVisible))
        {
            notVisibleCount++;
        }
        if (notVisibleCount > 60)
        {
            Destroy(gameObject);
            GameObject buttonObject = GameObject.Find("gameOverButton");
            Image buttonImage = buttonObject.GetComponent<Image>();
            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 1.0f);
            GameObject.Find("gameOverButtonText").GetComponent<Text>().text = "Reiniciar";
            gameOverText.text = "GAME OVER";
        }
    }
}
