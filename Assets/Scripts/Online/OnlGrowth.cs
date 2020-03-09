using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OnlGrowth : NetworkBehaviour
{
  private BotNames botNames;
  public int score;
  public string Name;
  private TextMesh text;

  public bool isPlayerAlive;

  Growth other_gr;
  Growth enemy_gr;

  void Start()
  {
    if (gameObject.tag=="Player")
    {
        Name="Player";
    }
    else
    {
    botNames = GetComponent<BotNames>();
    Name = botNames.GetName();
    }
      isPlayerAlive=true;
    score = 10;
    text = gameObject.GetComponent<TextMesh>();
  }

  // Update is called once per frame
  void Update()
  {
    if (isLocalPlayer)
    {
      text.text = Name + "\n" + score.ToString();
    }

  }
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Mass")
    {
      Debug.Log("Mass eaten");
      transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
      Destroy(other.gameObject);
      score++;
    }
    if (other.gameObject.tag == "Enemy")
    {
      enemy_gr = other.gameObject.GetComponent<Growth>();
      if (enemy_gr.score < score)
      {
        Debug.Log("Enemy ate enemy");
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        Destroy(other.gameObject);
        score++;
      }
    }
    if (other.gameObject.tag == "Player")
    {
      other_gr = other.gameObject.GetComponent<Growth>();
      if (other_gr.score < score)
      {
        Debug.Log("Enemy ate player");
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        Destroy(other.gameObject);
        isPlayerAlive=false;
        score++;
      }
      if (other_gr.score > score)
      {
          Debug.Log("Player ate enemy");
          other.gameObject.transform.localScale+= new Vector3(0.1f, 0.1f, 0.1f);
          Destroy(gameObject);
          other_gr.score++;
      }
    }
  }
}
