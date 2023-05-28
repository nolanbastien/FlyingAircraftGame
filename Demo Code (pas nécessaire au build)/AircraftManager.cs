using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftManager : MonoBehaviour
{
    public bool[] boughtAircraft;
    public int selectedAircraft = 0;

    void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        DontDestroyThisOnLoad();
        player.GetComponent<HandleAircraftChoice>().chosenAircraftIndex = selectedAircraft;
    }

    private void DontDestroyThisOnLoad() 
    {
        GameObject[] allAircraftManagers = GameObject.FindGameObjectsWithTag("AircraftManager");

        if (allAircraftManagers.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}
