using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    public int chosenAircraft;
    public bool[] acquiredAircrafts;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Memory");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        chosenAircraft = 0;
    }

}
