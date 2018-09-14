using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
    
    const float START_POSITION = -1.48f;

    #region Fields

    [SerializeField]
    private float speed;
    [SerializeField]
    private Text playText;

    private float bridgeLength;
    private float stepMove;
    private float middlePlatform;
    private float scalePlatform;

    #endregion

    #region Properties

    public static bool IsNeedMove { get; set; }

    #endregion

    #region Methods

    void Start ()
    {
        stepMove = speed * Time.deltaTime;
    }
	
	
	void Update ()
    {
        if (IsNeedMove)
        {
            if (transform.position.x < MakeBridge.PositionEndMove)
            {
                transform.position += new Vector3(stepMove, 0);
            }
            else
            {
                if (MakeBridge.IsGameOver)
                {
                    if (transform.position.y > -6)
                    {
                        transform.position += new Vector3(0, -stepMove * 5);
                    }
                    else
                    {
                        GetComponent<AudioSource>().Play();
                        GameOver.IsScreenLoad = true;
                        IsNeedMove = false;
                    }
                }
                else
                {
                    IncreaseScore();
                    if (PlayerPrefs.GetInt("BestScore")< int.Parse(playText.text))
                    {
                        PlayerPrefs.SetInt("BestScore", int.Parse(playText.text));
                    }
                    CameraMove.isMoved = true;
                    CameraMove.Distance = MakeBridge.PositionEndMove + 0.4f - START_POSITION;
                    IsNeedMove = false;
                    
                }
            }
        }
	}


    void IncreaseScore()
    {
        playText.text = (int.Parse(playText.text) + 1) + "";
    }

    #endregion

}
