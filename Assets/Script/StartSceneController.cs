using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public GameObject story;
    public GameObject rule;
    
    public int btnClick = 0;

    void Start()
    {
        story.SetActive(false);
        rule.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (btnClick == 0)
            {
                // active storyImage
                story.SetActive(true);
            }
            if(btnClick == 1)
            {
                // active ruleImage
                rule.SetActive(true);
            }
            if (btnClick == 2)
            {
                SceneManager.LoadScene("GameScene");
            }
            btnClick++;
        }
    }
}
