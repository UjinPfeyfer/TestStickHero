using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


    #region Fields

    [SerializeField]
    private float speed;

    #endregion

    #region Properties

    public static bool isMoved { get; set; }
    public static bool isAlreadyMoved { get; set; } 
    public static float Distance { get; set; }

    #endregion

    #region Methods

	void Update ()
    {
        if (isMoved&&!MakeBridge.IsGameOver)
 
            if (Distance > 0.03f)
            {
                transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0);
                Distance -= speed * Time.deltaTime;
            }
            else
            {
                isAlreadyMoved = true;
                isMoved = false;
            }
	}

    #endregion
}
