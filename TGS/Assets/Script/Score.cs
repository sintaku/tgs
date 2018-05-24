using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * memo
 * 今後ランダムではなく、決められた時間に決められたスコアボールを出す
 * 可能性があるかも。。。
 * 目標スコアに到達しなかったら高スコアのボールをめっちゃ出すとか
 */

/// <summary>
/// スコアに関係する情報をまとめたクラス
/// </summary>
[SerializeField, System.Serializable]
public class ScoreInfo
{
#if UNITY_EDITOR
    [SerializeField]
    private string header;
#endif
    /// <summary>
    /// スコア
    /// </summary>
    public int score;
    /// <summary>
    /// スコアボールのテクスチャ
    /// </summary>
    public Texture texture;
}


/// <summary>
/// スコア関係のクラス
/// </summary>
public class Score : MonoBehaviour {



    [SerializeField, HeaderAttribute("ボールに付けるスコア情報")]
    private ScoreInfo[] Scores;

    public List<Action<int>> onChangeScore;

    private int totalScore;
    public int TotalScore {
        set {
            totalScore = value;
            foreach(var func in onChangeScore) {
                func(totalScore);
            }
        }
        get {
            return totalScore;
        }
    }

    private void Awake()
    {
        totalScore = 0;
        onChangeScore = new List<Action<int>>();
        onChangeScore.Clear();
    }

    /// <summary>
    /// スコアをランダムに取得
    /// </summary>
    /// <returns></returns>
    public ScoreInfo GetScoreInfoRandom()
    {
        return Scores[UnityEngine.Random.Range(0, Scores.Length)];
    }



}
