using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed = 0.5f;

    public GameObject onCollectEffect;
    public AudioSource onCollectAudio;

    public GameManager gameManager;
    public int scoreValue;

    //private void Awake() {
    //    gameManager = GameObject.Find("GameManger").GetComponent<GameManager>();
    //    onCollectAudio = GetComponent<AudioSource>();
    //}

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.GetComponent<CharacterController>() != null) {

            Instantiate(onCollectEffect, transform.position, transform.rotation);
            //onCollectAudio.Play();
            AudioSource.PlayClipAtPoint(onCollectAudio.clip, transform.position);

            Destroy(gameObject);

            gameManager.UpdateScore(scoreValue);
        }
    }
 }
