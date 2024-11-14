using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI score;

    public int coin;

    private void Update()
    {
        score.text = $"Current Coin: {coin}"; // 점수가 일종의 재화 역할을 겸함 // 이 부분을 분리해야 할 부분
    }
}
