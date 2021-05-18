using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationManager : MonoBehaviour
{
    [SerializeField]
    private Color[] carTypes;
    [SerializeField]
    private SpriteRenderer player;

    private void Start()
    {
        if (PlayerPrefs.GetInt("PlayerCosmetic") == 1)
        {
            player.color = carTypes[PlayerPrefs.GetInt("PlayerCosmetic") - 1];
        }
    }

}
