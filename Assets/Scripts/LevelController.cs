using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelController : MonoBehaviour
{
  public GameObject Canvas;
  private GameObject player;
  public GameObject PauseCanv;

  bool isPause;

  private string[] leaders;
  private GameObject currentLeader;
  private List<GameObject> allPlayers= new List<GameObject>();
  private GUIStyle guiStyle = new GUIStyle();

  // private List<int> scores = new List<int>();
    void Start()
    {
    isPause=false;
      PauseCanv.SetActive(false);
    Canvas.SetActive(false);
    Time.timeScale = 1f;
    player=GameObject.FindGameObjectWithTag("Player");
    // allPlayers.Add(player);
    }
  public void RestartLevel()
  {
      Debug.Log("Pressed");
    SceneManager.LoadScene("Agario3D");
  }

    // Update is called once per frame
    void Update()
    {
    // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    // foreach (var en in enemies)
    // {
    //   allPlayers.Add(en);
    // }
    // currentLeader=ShowLeaders(allPlayers);
    // Debug.Log(ShowLeaders(allPlayers));
    
        if (GameObject.FindGameObjectWithTag("Player")==null)
        {
        Time.timeScale = 0.1f;
        Canvas.SetActive(true);
        }
        else{
          Canvas.SetActive(false);
          Time.timeScale = 1f;
        }
        if (isPause)
        {
        Time.timeScale = 0f;
        }
    }

    public void Pause(){
      Time.timeScale = 0f;
      isPause=true;
      PauseCanv.SetActive(true);
    }

  public void ExitToMainMenu()
  {
    Time.timeScale = 1;
    Application.LoadLevel("Menu");
  }

    public void Resume(){
      Time.timeScale=1f;
      isPause=false;
      PauseCanv.SetActive(false);
    }

    
  // void OnGUI()
  // {

  //     guiStyle.fontSize = 20;
  //     guiStyle.normal.textColor = Color.blue;
  //     int sc=currentLeader.GetComponent<Growth>().score;
  //     GUI.Label(new Rect(20, 10, 100, 100), "Leaders Board: " +currentLeader.GetComponent<Growth>().Name , guiStyle);
  //   GUI.Label(new Rect(30, 40, 100, 100), sc.ToString(), guiStyle);
  // }
  // GameObject ShowLeaders(List<GameObject> all)
  // {
  //   GameObject max=all[0];
  //   for (int i = 1; i < all.Count; i++)
  //   {
  //       if (all[i].GetComponent<Growth>().score>max.GetComponent<Growth>().score)
  //       {
  //           max=all[i];
  //       }
  //   }
  //   return max;
  // }
}
