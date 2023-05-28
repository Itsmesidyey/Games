using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public GameObject GameOverMenu;

    public void OnEnable(){
      
    }

    public void OnDisable(){
       
    }


   public void EnableGameOverMenu(){
    GameOverMenu.SetActive(true);
   }


}
