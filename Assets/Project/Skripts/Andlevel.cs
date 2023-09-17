using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Andlevel : MonoBehaviour
{
    public ShowInter sI;
    public Text text;
    public GameObject nex;
    public string next;
    public bool reclame;
    private float timer = 3;
    public void Next()
    {
        SceneManager.LoadScene(next);
        SaveAndLoad.Instance.Save();
    }
    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        SaveAndLoad.Instance.Save();
    }
    private void Update()
    {
        if (text != null)
        {
            text.gameObject.SetActive(reclame);
            text.text = "" + (int)timer;
            nex.SetActive(!reclame);
        }
        if (reclame)
        {
            timer -= Time.unscaledDeltaTime;
            if (timer <= 0)
            {
                sI.Showreklame();
                timer = 3;
                reclame = false;
            }
        }
    }
}
