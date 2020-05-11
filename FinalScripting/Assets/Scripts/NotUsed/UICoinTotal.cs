using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinTotal : MonoBehaviour
{
    [SerializeField] Text textCoinTotal;

    void Update()
    {
        textCoinTotal.text = PlayerData.coins.ToString();
    }
}
