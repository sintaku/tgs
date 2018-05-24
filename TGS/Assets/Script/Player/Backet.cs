using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが持っている籠クラス
/// </summary>
public class Backet : MonoBehaviour {

    [SerializeField]
    private Score score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        ScoreBall ball = other.gameObject.GetComponent<ScoreBall>();
        if (ball == null)
            return;

        score.TotalScore += ball.Score;
        ball.Dead();
    }


}
