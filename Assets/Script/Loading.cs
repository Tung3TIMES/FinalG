using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private float waitsecond = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitsecond > 0f) 
            waitsecond -= Time.deltaTime;
        else
            StartCoroutine(LoadNewScene()); 
    }

    private IEnumerator LoadNewScene()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync("SampleScene");

        while(!oper.isDone)
        {
            slider.value = oper.progress / 0.9f;
            yield return new WaitForSeconds(2f);
        }
    }
}
