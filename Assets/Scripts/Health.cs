using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public GameObject Canvas;

    private bool showGUI;

  private GUIStyle guiStyle = new GUIStyle();
    void Start()
    {
       Canvas.SetActive(false);
       Time.timeScale = 1f;
       showGUI=true;
    }
  public void RestartLevel(){
    SceneManager.LoadScene("SampleScene");
    Debug.Log("Pressed");
   }
    void Update()
    {
        if (health<=0)
        {
            Debug.Log("Game Over");
            Time.timeScale=0.1f;
            gameObject.SetActive(false);
            Canvas.SetActive(true);
            showGUI=false;
        }
    }
  void OnGUI()
  {
    if(showGUI){
    guiStyle.fontSize = 40;
    guiStyle.normal.textColor = Color.green;
    GUI.Label(new Rect(50, 200, 200, 200), "Health: "+health.ToString(),guiStyle);
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag=="Red")
    {
        Destroy(other.gameObject);
        health=health-1;
    }
    if (other.gameObject.tag == "Green")
    {
      Destroy(other.gameObject);
      health = health + 1;
    }
  }
}
