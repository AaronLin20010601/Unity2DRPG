using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : Singleton<SceneManagement>
{
    //initialize setting
    public string SceneTransitionName { get; private set; }

    //set scene transition
    public void SetTransitionName(string sceneTransitionName)
    {
        this.SceneTransitionName = sceneTransitionName;
    }
}
