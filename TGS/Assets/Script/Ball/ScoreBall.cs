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

    private bool isDead;

    [SerializeField, HeaderAttribute("削除する高さ")]
    private float deadHeight;

    private void Start()
    {
        isDead = false;
    }

    private void Update()
    {
        if (!IsDead())
            return;
        Destroy(gameObject);
    }

    public void Dead()
    {
        isDead = true;
    }

    /// <summary>
    /// 死亡条件を満たしているか？
    /// </summary>
    /// <returns>死亡条件を満たしているか</returns>
    private bool IsDead()
    {
        return transform.position.y <= deadHeight || isDead;
    }

}
