using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Splash : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(loadingscene());
    }

    IEnumerator loadingscene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("_main");
    }
    
    // Update is called once per frame
    void Update()
    {
        if(_canvasGroup.alpha < 1)
		{
            _canvasGroup.alpha += (float)0.01;
        }
    }
}
