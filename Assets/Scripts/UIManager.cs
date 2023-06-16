using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private ScoreManager score;
    [SerializeField]
    private Text textDistance;

    private void Start()
    {
        Debug.Log("Ola");
        textDistance.color = Color.red;
    }
    private void Update()
    {
        int intScore = (int)score.GetDistance();
        textDistance.text =  (intScore.ToString() + " m");
        if(score.IsNewScore())
        {
            textDistance.color = Color.green;
        }
    }
    
}
