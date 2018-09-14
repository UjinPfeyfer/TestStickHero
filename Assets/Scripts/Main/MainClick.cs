using UnityEngine;
using UnityEngine.UI;

public class MainClick : MonoBehaviour {

    #region Fields

    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject gameObjects;
    [SerializeField]
    private Text playText;
    [SerializeField]
    private Text gameInfo;
    [SerializeField]
    private float speed;

    private bool clicked;

    #endregion

    #region Methods

    private void OnMouseDown()
    {
        if (!clicked)
        {
            MakeBridge.IsGameOver = false;
            clicked = true;
            playText.gameObject.SetActive(false);
            gameInfo.text = "0";
            button.gameObject.SetActive(false);
            StartPosition.Speed = speed;
        }
    }

    #endregion
}
