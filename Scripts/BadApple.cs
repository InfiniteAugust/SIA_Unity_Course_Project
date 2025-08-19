using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadApple : MonoBehaviour
{
    public int scoreValue;
    public float movingLimit = 1.0f;
    private float max, min;
    public float speed;
    public GameManager gameManager;

    public AudioSource onCollectAudio;

    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + movingLimit;
        speed = 1.0f;
    }


    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);
    }

    private void OnMouseDown() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.GetComponent<CharacterController>() != null) {
            AudioSource.PlayClipAtPoint(onCollectAudio.clip, transform.position);

            Destroy(gameObject);

            gameManager.UpdateScore(scoreValue);
        }
    }
}
