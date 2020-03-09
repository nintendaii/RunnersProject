using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject canvas;

    public void Play(){
    SceneManager.LoadScene("Agario3D");
	}

	public void ExitToMainMenu(){
		Time.timeScale = 1;
		Application.LoadLevel ("Menu");
	}

	public void Exit(){
		Application.Quit ();
	}


    public void SetLowQuality(){
        QualitySettings.SetQualityLevel(0);
    }
    public void SetMediumQuality(){
        QualitySettings.SetQualityLevel(2);
    }
    public void SetHighQuality(){
        QualitySettings.SetQualityLevel(3);
    }

  public void SetUltraQuality()
  {
    QualitySettings.SetQualityLevel(4);
  }

}
