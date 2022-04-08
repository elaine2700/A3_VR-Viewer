using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Views : MonoBehaviour
{
    
    [SerializeField] GameObject bikeStandardView;
    [SerializeField] GameObject bikeExplodedView;


    void Start()
    {
        bikeStandardView.SetActive(true);
        bikeExplodedView.SetActive(!bikeStandardView.activeSelf);
    }

    void Update()
    {
        if (true)
        {
            // Input System
            // Toggle between views (Set active/inactive prefabs)
            bikeStandardView.SetActive(!bikeStandardView.activeSelf);
            bikeExplodedView.SetActive(!bikeStandardView.activeSelf);
        }

    }
}
