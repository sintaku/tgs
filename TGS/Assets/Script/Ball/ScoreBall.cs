using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアを持っているボール
/// </summary>
public class ScoreBall : MonoBehaviour {

    /// <summary>
    /// スコア
    /// </summary>
    public int Score { set; get; }

    [SerializeField, HeaderAttribute("削除する高さ")]
    private float deadHeight;

    private void Update()
    {
        Dead();
    }

    /// <summary>
    /// 死亡処理
    /// </summary>
    private void Dead()
    {
        if (!IsDead())
            return;
        Destroy(gameObject);
    }
    /// <summary>
    /// 死亡条件を満たしているか？
    /// </summary>
    /// <returns>死亡条件を満たしているか</returns>
    private bool IsDead()
    {
        return transform.position.y <= deadHeight;
    }

}
