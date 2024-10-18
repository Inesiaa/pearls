using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int value;

    public static Counter instance;

    public TMP_Text pearlText;
    public int currentPearls = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pearlText.text = "PEARLS: " + currentPearls.ToString();
    }

    public void IncreasePearls(int v)
    {
        currentPearls += v;
        pearlText.text = "PEARLS: " + currentPearls.ToString();
    }


}
