﻿using UnityEngine;
using System.Collections;

public class DeathManager : MonoBehaviour {

    static Attempts attempts;                                                          //References the scoreManager
    static Vector3 currentPosition;
    static GameObject player;
    static GameObject trailRenderer;
    static GameObject canvas;
    public static bool canShoot;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        attempts = GameObject.Find("Attempts").GetComponent<Attempts>();     //References the scoreManager
        canShoot = true;
    }

    public static void killProjectile()
    {
        canShoot = true;
        player = GameObject.FindGameObjectWithTag("Player");
        trailRenderer = player.transform.FindChild("TrailRenderer").gameObject;
        currentPosition = trailRenderer.transform.position;
        trailRenderer.transform.SetParent(canvas.transform);
        trailRenderer.transform.position = currentPosition;
        Destroy(player.gameObject);                                                  //Destroyes the player and updates the score
        attempts.Attempted();
    }
}