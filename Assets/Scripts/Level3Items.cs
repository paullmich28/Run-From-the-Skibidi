using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3Items : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Items Left: " + AmbilBarang.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Capsule"){
            other.gameObject.SetActive(false);
            AmbilBarang.score--;
            scoreText.text = "Items Left: " + AmbilBarang.score;
        }
    }
}
