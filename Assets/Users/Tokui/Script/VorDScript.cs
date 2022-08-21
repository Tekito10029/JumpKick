using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class VorDScript : MonoBehaviour
{
    public bool Settlement = false;
    public bool P1won = false;
    
    [SerializeField] 
    private GameObject _p1WonText = null;
    [SerializeField] 
    private GameObject _p2WonText = null;
    
    // Start is called before the first frame update
    void Start()
    {
        _p1WonText.SetActive(false);
        _p2WonText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Settlement == true)
        {
            if (P1won == true)
            {
                _p1WonText.SetActive(true);
            }
            else
            {
                _p2WonText.SetActive(true);
            }
        }
    }
}
