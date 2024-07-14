using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FishCotcaMiniGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> fish = new();
    [SerializeField] private int maxFish = 30;
    private int minFish = 0;
    [SerializeField] private Text textNumberFish;
    [SerializeField] private Text textTimeEvent;
    [SerializeField] private GameObject panelText;
    [SerializeField] private float timeSpawnFish = 2.0f;
    [SerializeField] private float timeEvent = 120f;
    [SerializeField] private GameObject objectCreatScene;

    private void OnEnable()
    {
        GetComponent<PointTrigerObject>().trigerE += StartEvent;
    }
    private void OnDisable()
    {
        GetComponent<PointTrigerObject>().trigerE -= StartEvent;
    }

    private void Awake()
    {
        if(objectCreatScene != null)
        {
            if (objectCreatScene.activeInHierarchy)
                objectCreatScene.SetActive(false);
        }
    }

    private bool startEvent = false;
    private void StartEvent()
    {
        if (startEvent)
        {
            startEvent = true;
            if (TryGetComponent(out Notification not))
            {
                not.enabled = false;
            }
            foreach (var f in fish)
            {
                f.GetComponent<FishTrigger>().Dead += FishDead;
            }
            minFish = 0;
            panelText.SetActive(true);
            StartCoroutine("NewFish");
            StartCoroutine("TimeEvent");
            Invoke("ExitEvent", timeEvent);
        }
    }
    private void FishDead()
    {
        minFish++;
        textNumberFish.text = $"{minFish}/{maxFish}";
        if (minFish > maxFish)
        {
            textNumberFish.text = "";
            ExitEvent();
        }
    }
    private void ExitEvent()
    {
        startEvent = false;
        if (TryGetComponent(out Notification not))
        {
            not.enabled = true;
        }
        foreach (var f in fish)
        {
            f.GetComponent<FishTrigger>().Dead -= FishDead;
        }
        panelText.SetActive(false);
        StopCoroutine(NewFish());
        if(minFish > maxFish)
            objectCreatScene.SetActive(true);
    }
    private IEnumerator NewFish()
    {
        while (true)
        {
            for(int i = 0; i < fish.Count; i++)
            {
                GameObject f = fish[UnityEngine.Random.Range(0, fish.Count)];
                if (!f.activeInHierarchy)
                {
                    f.SetActive(true);
                    break;
                }
            }
            yield return new WaitForSeconds(timeSpawnFish);
        }
    }

    float timeEventReal = 0;
    private IEnumerator TimeEvent()
    {
        while (true)
        {
            timeEventReal++;
            textTimeEvent.text = $"{timeEventReal}/{timeEvent}";
            if (timeEventReal > timeEvent)
            {
                timeEventReal = 0;
                ExitEvent();
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
