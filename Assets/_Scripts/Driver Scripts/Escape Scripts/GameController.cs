using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hazards;
    [SerializeField]
    private Vector3 spawnValues;
    [SerializeField]
    private int hazardCount;
    [SerializeField]
    private float spawnWait;
    [SerializeField]
    private float startWait;
    [SerializeField]
    private float waveWait;

    [SerializeField]
    private GameObject[] sideHazards;
    [SerializeField]
    private Vector3[] sideSpawnValues;
    [SerializeField]
    private int sideHazardCount;
    [SerializeField]
    private float sideSpawnWait;
    [SerializeField]
    private float sideStartWait;
    [SerializeField]
    private float sideWaveWait;
    [SerializeField]
    private int sideChoice;

    [SerializeField]
    private Slider distanceSlider;
    [SerializeField]
    private int distance;

    private int score;
    [SerializeField]
    private Text scoreText;

    private bool gameover = false;
    private bool victory = false;

    public bool Gameover { get => gameover; set => gameover = value; }
    public int Score { get => score; set => score = value; }

    private void Start()
    {
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnSideWaves());
        StartCoroutine(DistanceCounter());
    }

    private void Update()
    {
        if(distance >= 10)
        {
            victory = true;
        }
        ConditionCheck();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    IEnumerator SpawnSideWaves()
    {

        yield return new WaitForSeconds(sideStartWait);
        while (true)
        {
            StartCoroutine(SideChoiceGenerator());
            if (sideChoice == 1 || sideChoice == 2)
            {
                for (int i = 0; i < sideHazardCount; i++)
                {
                    if (sideChoice == 1) //Two cars on right hand side
                    {
                        GameObject sideHazard = sideHazards[0];

                        Vector3 spawnPosition = new Vector3(sideSpawnValues[0].x, sideSpawnValues[0].y, sideSpawnValues[0].z);
                        Quaternion spawnRotation = Quaternion.identity;

                        Instantiate(sideHazard, spawnPosition, spawnRotation);
                    }
                    else if (sideChoice == 2) //Two cars on left hand side
                    {
                        GameObject sideHazard = sideHazards[1];

                        Vector3 spawnPosition = new Vector3(sideSpawnValues[1].x, sideSpawnValues[1].y, sideSpawnValues[1].z);
                        Quaternion spawnRotation = Quaternion.identity;
                        Instantiate(sideHazard, spawnPosition, spawnRotation);
                    }
                    yield return new WaitForSeconds(sideSpawnWait);
                }
            }
            else if (sideChoice == 3) //One car on either side
            {
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(sideHazards[0], sideSpawnValues[0], spawnRotation);
                Instantiate(sideHazards[1], sideSpawnValues[1], spawnRotation);
            }
            else //No Cars
            {

            }
            yield return new WaitForSeconds(sideWaveWait);
        }
    }

    IEnumerator SideChoiceGenerator()
    {
        sideChoice = Random.Range(0, 4);
        yield return null;
    }

    IEnumerator DistanceCounter()
    {
        yield return new WaitForSeconds(5);
        distance++;
        distanceSlider.value = distance;
        StartCoroutine(DistanceCounter());
    }

    private void ConditionCheck()
    {
        //Check for lose condition
        if (gameover == true)
        {
            Time.timeScale = 0;
        }

        //Check for win condition
        if (victory == true)
        {
            Time.timeScale = 0;
        }
    }
}
