using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHome : MonoBehaviour {

    #region Methods

    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Main");
    }

    #endregion
}
