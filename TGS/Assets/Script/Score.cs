using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    /// <summary>
    /// スコアをランダムに取得
    /// </summary>
    /// <returns></returns>
    public ScoreInfo GetScoreInfoRandom()
    {
        return Scores[Random.Range(0, Scores.Length)];
    }

}
