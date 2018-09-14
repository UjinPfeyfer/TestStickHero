using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {

    #region Fields

    [SerializeField]
    private GameObject newPlatform;

    private Vector3 newLocalScale;
    private Vector3 newPosition;

    #endregion

    #region Properties

    public static float Speed { get; set; }

    #endregion

    #region Methods

    private void Start()
    {
        newLocalScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2);
        newPosition = new Vector3(-1f, transform.localPosition.y - 1.5f / transform.localScale.y);
    }


    void Update()
    {
        if (Speed!=0)
        {
            if (transform.position.x > -2)
            {
                transform.localPosition = transform.localPosition - new Vector3(-Speed*Time.deltaTime, -Speed*Time.deltaTime * 0.75f / newLocalScale.y);
                transform.localScale = Vector3.MoveTowards(transform.localScale, newLocalScale,-Speed * Time.deltaTime * newLocalScale.y*1.1f);
            }
            else
            {
                newPlatform.GetComponent<NewPlatform>().enabled = true;
                transform.localScale = newLocalScale;
                transform.localPosition = newPosition;
                Speed = 0;
            }
        }
    }

    #endregion

}
