using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text score;

    private void Awake() {
        score.text = GameManager.points.ToString();
    }
    void Update()
    {
        score.text = GameManager.points.ToString();
    }
}
