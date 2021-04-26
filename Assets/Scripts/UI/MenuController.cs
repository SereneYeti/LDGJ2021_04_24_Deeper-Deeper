using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MenuController : MonoBehaviour
{
  
    #region MainMenuButtons
    public Button btnPlay;
    public TextMeshProUGUI txtPlay;
    public Button btnQuit;
    public TextMeshProUGUI txtQuit;   
    //public Button btnInstructions;
    //public TextMeshProUGUI txtInstructions;   
    public TextMeshProUGUI txtInstructionsMessage;
    public Slider seedSlider;
    public TextMeshProUGUI seedText;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(this.PlayGame);
        btnQuit.onClick.AddListener(this.QuitGame);
        //btnInstructions.onClick.AddListener(this.ShowInstructions);
        //btnViewHighScore.onClick.AddListener(this.DisplayScores);
        Back();
        SetVisibility(true, 0);
    }
   
   

    private void Awake()
    {
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SetVisibility(true, 4);
        
    }
    private void Update()
    {
        seedText.text = Convert.ToString(Mathf.RoundToInt(seedSlider.value));

    }
    void Back()
    {
        SetVisibility(true, 0);
        SetVisibility(false, 1);
        SetVisibility(false, 2);        
    }
    public void PlayGame()
    {          
        //Debug.Log("HI");
        gameManager.Instance.depth = Mathf.RoundToInt(seedSlider.value);
        SceneManager.LoadScene(1);     
    }
    public void QuitGame()
    {
        Debug.Log("BI");
        Application.Quit();
    }
    public void ShowInstructions()
    {
        Debug.Log("Inst");
        SetVisibility(false, 0);
        SetVisibility(true, 2);
    }    
    
    public void SetVisibility(bool vis, int set)
    {
        switch(set)
        {
            case 0:
                { //Main Menu
                    btnPlay.gameObject.SetActive(vis);
                    btnQuit.gameObject.SetActive(vis);
                    //btnInstructions.gameObject.SetActive(vis);
                    txtInstructionsMessage.gameObject.SetActive(vis);
                    break;
                }
          
            case 2:
                {  //Instructions
                    break;
                }             
        }
    }
  
}
