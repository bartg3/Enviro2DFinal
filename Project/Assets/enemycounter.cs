using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class enemycounter : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Enemies Killed: " + scoreValue;

        if (scoreValue >= 5)
        {
            Destroy(this);
            SceneManager.LoadScene(sceneName: "Win");
        }
    }
}
