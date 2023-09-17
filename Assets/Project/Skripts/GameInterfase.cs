using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;

public class GameInterfase : MonoBehaviour
{
    public bool lastlevel;
    [SerializeField] private Language language;
    public Data data;
    public Image hPbar;
    public Text bullets, record, killed, kesh;
    public int killers;
    private float mHalse;
    public static GameInterfase rid { get; set; }
    void Awake()
    {
        killers = data.record;
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void Kill()
    {
        int index = data.record + 10;
        killers += 1;
        if (killers >= index)
        {
            data.record = killers;
            if (lastlevel)
            {
                SaveAndLoad.Instance.Save();
            }
            else
            {
                Interface.rid.AndLVL();
            }
            if (Bridge.platform.language == "ru")
            {
                Subtitres.regit.subtitres = language.ru;
            }
            else
            {
                Subtitres.regit.subtitres = language.en;
            }

        }
    }
    void OnDestroy()
    {
        rid = null;
    }
    void Update()
    {
        hPbar.fillAmount = Gun.rid.helse / 10;
        bullets.text = "" + data.bulets;
        record.text = "" + data.record;
        kesh.text = "" + data.coins;
        killed.text = "" + killers;
    }
}
