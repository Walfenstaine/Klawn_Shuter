using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillserKlic : MonoBehaviour
{
    public Text lvl;
    public int level;
    public GameObject arow, locker;

    public void Upgreid(bool activate)
    {
        arow.SetActive(activate);
        locker.SetActive(!activate);
    }
    private void Update()
    {
        lvl.text = "" + level;
    }
}
