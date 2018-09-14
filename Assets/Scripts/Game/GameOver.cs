using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    #region Fields

    [SerializeField]
    private GameObject screen, restartButton, homeButton;
    [SerializeField]
    private Text score, bestScore;
    private SpriteRenderer spriteRendererScreen;

    #endregion

    #region Properties

    public static bool IsScreenLoad { get; set; }

    #endregion

    #region Methods

    void Start ()
    {
        spriteRendererScreen = screen.GetComponent<SpriteRenderer>();
  	}
	
	
	void Update () {
        if (IsScreenLoad)
        {
            if (spriteRendererScreen.color.a < 0.7)
            {
                spriteRendererScreen.color = new Color(255f, 255f, 255f, spriteRendererScreen.color.a + Time.deltaTime);
            }
            else
            {
                score.text = "Your score: " + score.text;
                bestScore.text = "Best score: " + PlayerPrefs.GetInt("BestScore");
                IsScreenLoad = false;
                restartButton.gameObject.SetActive(true);
                homeButton.gameObject.SetActive(true);
                bestScore.gameObject.SetActive(true);
            }
        }
	}

    #endregion

}
