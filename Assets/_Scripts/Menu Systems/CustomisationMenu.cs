using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationMenu : MonoBehaviour
{


    //Car Customisation - upgrades
    public void equipeCosmetic1()
    {
        PlayerPrefs.SetInt("PlayerCosmetic", 1);
        PlayerPrefs.Save();
    }
    public void equipeCosmetic2()
    {
        PlayerPrefs.SetInt("PlayerCosmetic", 2);
        PlayerPrefs.Save();
    }
    public void equipeCosmetic3()
    {
        PlayerPrefs.SetInt("PlayerCosmetic", 3);
        PlayerPrefs.Save();
    }
    public void equipeCosmetic4()
    {
        PlayerPrefs.SetInt("PlayerCosmetic", 4);
        PlayerPrefs.Save();
    }
    public void equipeCosmetic5()
    {
        PlayerPrefs.SetInt("PlayerCosmetic", 5);
        PlayerPrefs.Save();
    }

    //Crew Customisation - upgrades
    public void CrewUpgrade()
    {
        PlayerPrefs.SetInt("CrewUpgrades", 1);
        PlayerPrefs.Save();
    }

    //Hacking Customisation - upgrades
}
