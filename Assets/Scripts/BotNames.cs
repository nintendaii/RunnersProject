using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BotNames : MonoBehaviour
{
    public string[] names=new string[] {"Marry","Rob","Daniel","Rip","Peep","Armagedon","Yummy","Domingo","Omen","Kate","Kitty","Urlr","Zed","Rury","Orchid","Doggy","Ivan","Funny Guy","Dead"};

    public string GetName(){
        int n=names.Length;
        System.Random random= new System.Random();
        return names[random.Next(0,n)];
    }
}
