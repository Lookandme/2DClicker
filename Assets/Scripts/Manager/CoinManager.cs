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
        score.text = $"Current Coin: {coin}"; // ������ ������ ��ȭ ������ ���� // �� �κ��� �и��ؾ� �� �κ�
    }
}
