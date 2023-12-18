using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TapetinVaihtajaObjekti : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public static TapetinVaihtajaObjekti instanssi;
    public GameObject tapetti1;
    public GameObject tapetti2;
    public GameObject tapetti3;


    public void Start()
    {
        Debug.Log(tapetti2);
    }

    private void Awake()
    {
        if (instanssi == null)
        {
            instanssi = this;
        }
    }

    [SerializeField] private TMP_Text valintaNumero;


    public void DropDownValinta(int index)
    {
        Debug.Log("tapetti1: " + tapetti1);
        Debug.Log("tapetti2: " + tapetti2);
        Debug.Log("tapetti3: " + tapetti3);


        switch (index)
        {
            case 0:
                vaihtoehtoA();
                break;
            case 1:
                vaihtoehtoB();
                break;
            case 2:
                vaihtoehtoC();
                break;
            default:
                Debug.LogError("Virhe valinta");
                break;
        }


        Debug.Log(ARPainaJaLisaa.instanssi.gameObjectToInstantiateTO);
        PaivitaARObjekti();
    }

    private void PaivitaARObjekti()
    {
        //var valiobjekti = ARPainaJaLisaa.instanssi.spawnedObjectTO;

        if (ARPainaJaLisaa.instanssi.spawnedObjectTO != null)
        {
            Destroy(ARPainaJaLisaa.instanssi.spawnedObjectTO);
            //Destroy(valiobjekti.gameObject);
        }
        Debug.Log("AR paivityksen jälkeinen objekti: " + ARPainaJaLisaa.instanssi.gameObjectToInstantiateTO);

        ARPainaJaLisaa.instanssi.spawnedObjectTO = Instantiate(ARPainaJaLisaa.instanssi.gameObjectToInstantiateTO, Vector3.zero, Quaternion.identity);

        
    }
    //Vika on kai näissä
    public void vaihtoehtoA()
    {
        ARPainaJaLisaa.instanssi.gameObjectToInstantiateTO = tapetti1;

        Debug.Log("2. AR paivityksen jälkeinen objekti: " + ARPainaJaLisaa.instanssi.gameObjectToInstantiateTO);
    }

    public void vaihtoehtoB()
    {
        ARPainaJaLisaa.instanssi.gameObjectToInstantiateTO = tapetti2;
        Debug.Log("2. AR paivityksen jälkeinen objekti: " + ARPainaJaLisaa.instanssi.gameObjectToInstantiateTO);

    }

    public void vaihtoehtoC()
    {
        ARPainaJaLisaa.instanssi.gameObjectToInstantiateTO =tapetti3;
        Debug.Log("2. AR paivityksen jälkeinen objekti: " + ARPainaJaLisaa.instanssi.gameObjectToInstantiateTO);


    }
}
