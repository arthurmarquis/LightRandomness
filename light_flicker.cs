using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_flicker : MonoBehaviour
{
    [SerializeField]
    float minIntensity = 0f; // min intensity
    [SerializeField]
    float maxIntensity = 1f; // max intensity
    [SerializeField]
    Light campfireLight;
    [SerializeField]
    float waitTime = 2f;
    [SerializeField]
    float timer = 0f;
    [SerializeField]
    float startTime = .05f;
    [SerializeField]
    float endTime = .25f;
    [SerializeField]
    float rangeMultiplier;
    static float lerp = 0.0f;
    float startIntensity;
    float endIntensity;
    [SerializeField]
    float minRange;
    [SerializeField]
    float maxRange;
    float currentRange;
    float endRange;
    [SerializeField]
    Vector3 newLocation;
    Vector3 originalLocation;
    [SerializeField]
    float minAllowedMove;
    [SerializeField]
    float maxAllowedMove;

    void Start()
    {
        endIntensity = Random.Range(minIntensity, maxIntensity);
        waitTime = Random.Range(startTime, endTime);
    }
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer <= waitTime)
        {
            flicker();
        }
        else
        {
            endIntensity = Random.Range(minIntensity, maxIntensity);
            endRange = Random.Range(minRange, maxRange);
            newLocation = new Vector3(159.9f + Random.Range(minAllowedMove, maxAllowedMove), 2.71f + Random.Range(minAllowedMove, maxAllowedMove), 163.15f + Random.Range(minAllowedMove, maxAllowedMove));
            timer -= waitTime;
            waitTime = Random.Range(startTime,endTime);
        }

        print("Light Transform " + campfireLight.transform.position);
    }

    void flicker()
    {
        Debug.Log("Flickering!");
        startIntensity = campfireLight.intensity;
        campfireLight.intensity = Mathf.Lerp(startIntensity, endIntensity, Time.deltaTime);

        currentRange = campfireLight.range;
        campfireLight.range = Mathf.Lerp(currentRange, endIntensity * rangeMultiplier, Time.deltaTime);

        campfireLight.transform.position = Vector3.Lerp(campfireLight.transform.position, newLocation, Time.deltaTime);


    } 
}

