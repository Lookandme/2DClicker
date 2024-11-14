using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinManager : MonoBehaviour
{
    private static CoinManager instance;
    [SerializeField] public TextMeshProUGUI score;

    public int coin;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Destroy(gameObject);
    }
    private void Update()
    {
        score.text = $"Current Coin: {coin}"; // ������ ������ ��ȭ ������ ���� // �� �κ��� �и��ؾ� �� �κ�
    }
}
