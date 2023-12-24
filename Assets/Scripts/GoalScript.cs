using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public List<GameObject> items;

    [SerializeField]
    GameObject goal;

    [SerializeField]
    GameObject hintGoal;
    // Start is called before the first frame update
    void Start()
    {
        goal.SetActive(false);
        hintGoal.SetActive(false);
    }

    private void Awake() {
        AmbilBarang.score = items.Count;    
    }

    // Update is called once per frame
    void Update()
    {
        if(AmbilBarang.score == 0){
            goal.SetActive(true);
            hintGoal.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Goal"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
