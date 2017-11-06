using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Opening : MonoBehaviour {

    public VideoPlayer videoPlayer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((ulong)videoPlayer.frame == videoPlayer.frameCount)
        {
            // 
            SceneManager.LoadScene("Main");
            return;
        }
    }
}
