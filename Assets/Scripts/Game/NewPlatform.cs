using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewPlatform : MonoBehaviour {

    #region Fields

    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private GameObject bonusZone;
    [SerializeField]
    private GameObject playerReady;
    [SerializeField]
    private GameObject allGameObject;
    [SerializeField]
    private float speed = 3f;
    private GameObject platformNext, bonusZoneNext;
    private bool shouldUpdate;

    #endregion

    #region Properties

    public static Vector3 PlatformPositionNext { get; set; }
    public static Vector3 PlatformScaleNext { get; set; }

    #endregion

    #region Methods

    void Start ()
    {
        CreatNewPlatform();
    }


    private void Update()
    {
        if (shouldUpdate)
        {
            if (platformNext.transform.position != PlatformPositionNext)
            {
                platformNext.transform.position = Vector3.MoveTowards(platformNext.transform.position, PlatformPositionNext, Time.deltaTime * speed);
                bonusZoneNext.transform.position = Vector3.MoveTowards(bonusZoneNext.transform.position, PlatformPositionNext - new Vector3(0, -1f), Time.deltaTime * speed);
            }
            else
            {
                platformNext.transform.position = PlatformPositionNext;
                bonusZoneNext.transform.position = new Vector3(PlatformPositionNext.x, -3.5f);
                playerReady.GetComponent<MakeBridge>().IsPlayerReady = true;
                shouldUpdate = false;
            }
        }
        if (CameraMove.isAlreadyMoved)
        {
            CreatNewPlatform();
            CameraMove.isAlreadyMoved = false;
        }
    }


    private void CreatNewPlatform()
    {
        platformNext = Instantiate(platform, new Vector3(4f, -4.5f), Quaternion.identity);
        bonusZoneNext = Instantiate(bonusZone, new Vector3(4f, -3.5f), Quaternion.identity);
        platformNext.transform.localScale = PlatformScaleNext = new Vector3(Random.Range(.2f, 1.2f), 2);
        PlatformPositionNext = new Vector3(Random.Range(-1f, 2.5f), -4.5f);
        bonusZoneNext.transform.parent = platformNext.transform.parent = allGameObject.transform;
        shouldUpdate = true;
    }

    #endregion

}