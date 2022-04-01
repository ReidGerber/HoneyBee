using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreManager : MonoBehaviour
{
    public static UIScoreManager instance;

    [SerializeField] TextMeshProUGUI honeyText;

    int honeyCount = 0;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        honeyText.text = honeyCount.ToString();
    }
 

    public void AddHoney(int amount)
    {
        honeyCount += amount;
        honeyText.text = honeyCount.ToString();
        //playerprefs for saving data
    }

}
