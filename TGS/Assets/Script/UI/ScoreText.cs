using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    [SerializeField]
    private Score score;
    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "";
        score.onChangeScore.Add(OnChangeScore);
	}

    void OnChangeScore(int value)
    {
        text.text = value.ToString()
;    }
	
}
