using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageCanvas : MonoBehaviour
{
    GameObject Player;
    public GameObject icePrefab;
    public Text scoreText;
    public int score = 0;

    void Start()
    {
        Instantiate(icePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(icePrefab, new Vector3
            (-6.0f, 3.0f, 0), Quaternion.identity);
        Instantiate(icePrefab, new Vector3
            (6f, -3f, 0), Quaternion.identity);
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void ReiniciarFase() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
        
