using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class AmbilBarang : MonoBehaviour
{
    public AudioClip songClip;
    public float maxAudibleDistance = 5f;

    private AudioSource audioSource;
    private bool isInRange = false;

    public static int score = 0;
    [SerializeField]
    TextMeshProUGUI scoreText;

     private void Start()
    {
        scoreText.text = "Items Left: " + score;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.clip = songClip;
        audioSource.spatialBlend = 1f;
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            score--;
            scoreText.text = "Items Left: " + score;

            if (audioSource != null && songClip != null){
                audioSource.Play();
            }

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            audioSource.maxDistance = maxAudibleDistance;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            audioSource.maxDistance = float.MaxValue;
        }
    }
}

