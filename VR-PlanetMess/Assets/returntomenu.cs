using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returntomenu : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ReturnToMenu());
    }

    public IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(5f);
        UIManager.Instance.MainMenuUI.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
