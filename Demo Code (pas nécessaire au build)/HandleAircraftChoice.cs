using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAircraftChoice : MonoBehaviour
{
    [SerializeField] GameObject[] aircrafts;
    public int chosenAircraftIndex = 0;

    void Start()
    {
        GameObject memory = GameObject.FindWithTag("Memory");
        
        chosenAircraftIndex = memory.GetComponent<Memory>().chosenAircraft;

        Instantiate(aircrafts[chosenAircraftIndex], this.transform);
    }

}
