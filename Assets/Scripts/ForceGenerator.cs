﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGenerator : MonoBehaviour
{

    private GameObject seal;

    float dirX, dirY;
    // Use this for initialization
    void Start()
    {
        seal = GameObject.Find("Seal");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Waiting for Input");
        if (Input.GetKeyDown(KeyCode.Space))
        {


            dirX = Random.Range(-3.0f, 3.0f);
            dirY = Random.Range(-3.0f, 3.0f);
            Vector2 waveForceDir = new Vector2(dirX, dirY);

            float magnitude = Random.Range(35f, 50f);
            int aftershock = 3;
            waveForceDir = waveForceDir.normalized;

            StartCoroutine(GenerateForce(waveForceDir, magnitude, aftershock));
        }

    }

    IEnumerator GenerateForce(Vector2 direction, float magnitude, int aftershock)
    {
        float time = 1.5f;
        if (aftershock <= 0)
        {
            yield return new WaitForSeconds(time);
        }
        else
        {
            seal.GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Force);
            yield return new WaitForSeconds(time);
            StartCoroutine(GenerateForce(direction * -1, magnitude * 2f, aftershock - 1));
        }


        Debug.Log("Front force Given and invoking Back Force");
        //Invoke("GenerateBackForce", 1.5f);

    }

}