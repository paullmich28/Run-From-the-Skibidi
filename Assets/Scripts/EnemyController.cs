using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerPosition;
    private AudioSource audioSource;
    public AudioClip enemySongClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;


        audioSource.clip = enemySongClip;

        audioSource.spatialBlend = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosVec = playerPosition.position;
        agent.SetDestination(playerPosVec);
    }
}
