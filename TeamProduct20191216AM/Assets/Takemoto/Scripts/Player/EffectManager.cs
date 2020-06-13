using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EffectManager : MonoBehaviour
{
    public static EffectManager effectManagerInstance;

    public GameObject effect1;
    public GameObject effect1Parent;
    private List<GameObject> effectList1 = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if(effectManagerInstance == null)
        {
            effectManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);

            for(int i = 0; i < 5; i++)
            {
                GameObject temp = Instantiate(effect1, Vector3.zero, Quaternion.identity);
                temp.SetActive(false);
                temp.transform.parent = effect1Parent.transform;
                effectList1.Add(temp);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Effect1Emission(Vector3 basyo, Quaternion kakudo)
    {
        GameObject temp = effectList1.FirstOrDefault(n => n.activeSelf == false);

        if(temp != null)
        {
            temp.SetActive(true);
            temp.transform.position = basyo;
            temp.transform.rotation = kakudo;
        }
        else
        {
            GameObject temp2 = Instantiate(effect1, basyo, kakudo);
            temp2.transform.parent = effect1Parent.transform;
            effectList1.Add(temp2);
        }
    }
}
