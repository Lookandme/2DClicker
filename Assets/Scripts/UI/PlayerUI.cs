using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;

public class PlayerUI : MonoBehaviour
{
    public Slider slider;
   [SerializeField] private PlayerController controller;
    public TextMeshProUGUI currentGageTxt;
    public float maxGage = 100f;
    public float minGage = 0f;
    public float currentGage = 0f;
   

    private void Awake()
    {
       
        

        
    }
    private void Start()
    {


        UpdateUI();




    }

    private void Update()
    {
        
    }
    public void UpdateUI()
    {
        slider.value = currentGage / maxGage;
       
       
    }
    public void Add(float amount)
    {
        
      if(currentGage < maxGage)
        {
            currentGage += amount;
            
        }
        UpdateUI();
    }
    public void Decrease(float amount)
    {
        if(currentGage > minGage)
        {
            currentGage -= amount;
            
        }
        UpdateUI();
    }
}
