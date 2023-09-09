using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;

public class Loot : MonoBehaviour
{
    [SerializeField] private Language language;
    public enum Tipe { coin, bulet };
    public Tipe tip;
    public AudioClip clip;
    public Data data;
    public Transform mekh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SoundPlayer.regit.sorse.PlayOneShot(clip);
            int mas = Random.Range(1,5);
            if (Bridge.platform.language == "ru")
            {
                Subtitres.regit.subtitres = language.ru + " + " + mas;
            }
            else
            {
                Subtitres.regit.subtitres = language.en + " + " + mas; ;
            }
            if (tip == Tipe.coin)
            {
                data.coins += mas;
            }
            if (tip == Tipe.bulet)
            {
                data.bulets += mas;
            }
            
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        mekh.Rotate(Vector3.up * 2);
        Vector3 posa = Muwer.rid.transform.position;
        transform.position = Vector3.Lerp(transform.position, posa, Time.deltaTime);

    }
}
