using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRestart : MonoBehaviour {

    #region Fields

    [SerializeField]
    private Text score, bestScore;
    [SerializeField]
    private GameObject mainPlatform, player, buttonHome, screenBackground;
    private SpriteRenderer gameOverScreenBackground;
    private GameObject newMainPlatform;

    #endregion

    #region Methods

    private void OnMouseUpAsButton()
    {
        gameOverScreenBackground = screenBackground.GetComponent<SpriteRenderer>();
        newMainPlatform = Instantiate(mainPlatform, new Vector3(6f, -4.5f), Quaternion.identity);
        newMainPlatform.transform.parent = player.transform.parent;
        player.transform.position = new Vector3(6f, -3f);
        score.text = "0";
        bestScore.gameObject.SetActive(false);
        buttonHome.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        gameOverScreenBackground.color = new Color(255f, 255f, 255f, 0f);
        CameraMove.Distance = 8f;
        CameraMove.isMoved = true;
        MakeBridge.IsGameOver = false;
    }

    #endregion
}
