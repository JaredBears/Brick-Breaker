using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    [SerializeField] GameObject ball;

    public void Win(){
        StartCoroutine("Restart");
    }

    public void Lose(){
        StartCoroutine("Restart");
    }

    IEnumerator Restart(){
        Destroy(ball);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
