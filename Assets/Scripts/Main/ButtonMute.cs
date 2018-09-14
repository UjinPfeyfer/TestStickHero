using UnityEngine;

public class ButtonMute : MonoBehaviour {

    #region Fields

    [SerializeField]
    private GameObject volumeOff;
    private bool volume;

    #endregion

    #region Methods

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(60f, 60f);
    }


    private void OnMouseUp()
    {
        transform.localScale = new Vector3(50f, 50f);
        if (volume)
        {  
            volumeOff.gameObject.SetActive(false);
            AudioListener.volume = 1;
        }
        else
        {
            volumeOff.gameObject.SetActive(true);
            AudioListener.volume = 0;
        }
        volume = !volume;
    }

    #endregion

}
