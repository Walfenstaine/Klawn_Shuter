using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Andlevel : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene("Scene1");
        SaveAndLoad.Instance.Save();
    }
}
