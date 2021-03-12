using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string GoTo;
    //public Animator anim;

    public void Outie()
    {
        SceneManager.LoadScene(GoTo);
    }

    public void Escape()
    {
        Application.Quit();
    }

    public void FancyChange(string lode)
    {
        GoTo = lode;
        //if (anim != null) { anim.SetTrigger("FadeOut"); }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            FancyChange(GoTo);
        }
    }
}
