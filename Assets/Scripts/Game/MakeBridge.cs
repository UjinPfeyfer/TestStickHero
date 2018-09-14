using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MakeBridge : MonoBehaviour {

    const float START_POSITION = -1.5f;

    #region Fields

    [SerializeField]
    private GameObject bridge;
    [SerializeField]
    private float speedGrows;
    [SerializeField]
    private float speedRotate;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text score;
    private float bridgeLength, stepMove, stepRotate;
    private static float positionEndMove;
    private bool isBridgeGrowsUp, isBridgeRotate, isBonusZone = false;
    private GameObject bridgeNew;
    private Vector3 startPoint = new Vector3(-1.51f, -3.5f);

    #endregion

    #region Properties

    public static bool IsGameOver { get; set; }
    public bool IsPlayerReady { get; set; }
    public static float PositionEndMove
    {
        get
        {
            return positionEndMove;
        }
    }

    #endregion

    #region Methods

    private void Update()
    {
        if (isBridgeGrowsUp&&bridgeLength<8f)
        {
            bridgeNew.transform.localScale += new Vector3(0f, stepMove/2);
            bridgeNew.transform.position += new Vector3(0f, stepMove/2 );
            bridgeLength += stepMove;
        }
        if (isBridgeRotate)
        {
            if (bridgeNew.transform.rotation.z > Mathf.Sin(-Mathf.PI / 4))
            {
                bridgeNew.transform.RotateAround(startPoint, Vector3.back, stepRotate );
            }
            else
            {
                isBridgeRotate = false;
                bridgeNew.transform.eulerAngles = new Vector3(0, 0, 90);
                bridgeNew.transform.position = new Vector3(bridgeNew.transform.position.x, -3.5f);
                player.GetComponent<PlayerMove>().enabled = true;
                PlayerMove.IsNeedMove = true;
                if (isBonusZone)
                {
                    score.text = (int.Parse(score.text) + 1) + " ";
                    isBonusZone = false;
                }
                GetComponent<AudioSource>().Play();

            }
        }
    }


    private void OnMouseDown()
    {
        if (IsPlayerReady&&!IsGameOver)
        {
            isBridgeGrowsUp = true;
            bridgeNew = Instantiate(bridge, startPoint, Quaternion.identity);
            bridgeNew.transform.localScale = new Vector3(0.05f, 0);
            stepMove = speedGrows * Time.deltaTime;
            stepRotate = speedRotate * Time.deltaTime;
            bridgeNew.transform.parent = player.transform.parent;
            bridgeLength = 0;
        }
    }


    private void OnMouseUp()
    {

        if (IsPlayerReady&&isBridgeGrowsUp&&!IsGameOver)
        {
            isBridgeGrowsUp = false;
            IsPlayerReady = false;
            isBridgeRotate = true;
            IsGameOver = CheckBridgeEnd(LeftBridgeEdge(), RightBridgeEdge());
            isBonusZone = !CheckBridgeEnd(NewPlatform.PlatformPositionNext.x - 0.05f, NewPlatform.PlatformPositionNext.x + 0.05f);
            positionEndMove = CalcPositionEndMove();
            print(PositionEndBridge()+" "+ NewPlatform.PlatformPositionNext.x);
        }
    }


    bool CheckBridgeEnd(float LeftEdge, float rightEdge)
    {
        if (PositionEndBridge() < LeftEdge || PositionEndBridge() > rightEdge)
        {
            return true;
        }
        return false;
    }


    public float RightBridgeEdge()
    {
        return NewPlatform.PlatformPositionNext.x + NewPlatform.PlatformScaleNext.x / 2;
    }


    float LeftBridgeEdge()
    {
        return NewPlatform.PlatformPositionNext.x - NewPlatform.PlatformScaleNext.x / 2;
    }


    float PositionEndBridge()
    {
        return START_POSITION + bridgeLength;
    }


    float CalcPositionEndMove()
    {
        if (!IsGameOver)
        {
            return RightBridgeEdge() - 0.4f;
        }
        return PositionEndBridge();
    }

    #endregion

}

