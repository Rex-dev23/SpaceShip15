using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI TextScore;
    int PlayerScor;

     public void UpdateScore()
    {
        PlayerScor++;
        TextScore.text = "Score: " + PlayerScor;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
