using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Utility
{
    /// <summary>
    /// カウントダウンするタイマークラス
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// タイマーの状態
        /// </summary>
        private enum State
        {
            //カウントダウンをする
            Play,
            //タイマーを止める
            Stop
        }

        [SerializeField, Header("設定時間(秒)")]
        private float secondTime;
        /// <summary>
        /// 設定時間
        /// </summary>
        private float maxTime;
        /// <summary>
        /// 設定時間が過ぎたら実行する関数
        /// </summary>
        public Action OnTimeUpFunc { set; get; }
        private State state;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="secondTime">設定時間</param>
        public Timer(float secondTime)
        {
            this.secondTime = secondTime;
            maxTime = secondTime;
            OnTimeUpFunc = () =>{};
            state = State.Stop;
        }
        /// <summary>
        /// 設定した時間が過ぎたか？
        /// </summary>
        /// <returns>過ぎたか？</returns>
        public bool IsTimeUp()
        {
            return secondTime <= 0.0f;
        }
        /// <summary>
        /// タイマーを進める
        /// </summary>
        public void Start()
        {
            state = State.Play; 
        }
        /// <summary>
        /// タイマーを止める
        /// </summary>
        public void Stop()
        {
            state = State.Stop;
        }
        /// <summary>
        /// 更新・カウントダウン
        /// </summary>
        public void Update()
        {
            if (state == State.Stop)
                return;
            secondTime = Math.Max(secondTime - Time.deltaTime, 0.0f);
            if (IsTimeUp())
            {
                state = State.Stop;
                OnTimeUpFunc();
                secondTime = maxTime;
            }
        }

    }
}
