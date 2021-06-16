using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveFade : MonoBehaviour
{
    [SerializeField]
    private Text objectiveText;
    [SerializeField]
    private float fadeSpeed;

    void Start()
    {
        StartCoroutine(FaidOutObjective());
    }

    private IEnumerator FaidOutObjective()
    {
        yield return new WaitForSeconds(3);
        while (objectiveText.color.a > 0)
        {
            float fadeAmount = objectiveText.color.a - (fadeSpeed * Time.deltaTime);

            objectiveText.color = new Color(objectiveText.color.r, objectiveText.color.g, objectiveText.color.b, fadeAmount);
            yield return null;
        }
    }
}
