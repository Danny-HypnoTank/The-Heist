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
            player.color = carTypes[PlayerPrefs.GetInt("CarSprite")];
    }
}
