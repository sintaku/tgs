using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollOut : MonoBehaviour {

    public GameObject bollPre;
    public float BollOutTime;
    [SerializeField]
    private Score score;
    private Utility.Timer spawnTimer;

    // Use this for initialization
    void Start () {
        spawnTimer = new Utility.Timer(BollOutTime);
        spawnTimer.OnTimeUpFunc = SpawnBall;
        spawnTimer.Start();
    }

    public void SpawnBall()
    {
        GameObject ball = Instantiate(bollPre, transform.position, Quaternion.identity);
        ScoreInfo scoreInfo = score.GetScoreInfoRandom();
        //スコアを設定
        ball.GetComponent<ScoreBall>().Score = scoreInfo.score;
        //テクスチャを設定
        ball.GetComponent<MeshRenderer>().material.mainTexture = scoreInfo.texture;
        spawnTimer.Start();
    }

    // Update is called once per frame
    void Update () {
        spawnTimer.Update();
	}
}
