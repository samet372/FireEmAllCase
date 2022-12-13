using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject _hirePanel;
    [SerializeField] GameObject _firePanel;

    [SerializeField] float _waitTime;

    bool _contactGirl;
    bool _contactMen;

    private void Start()
    {
        _hirePanel.SetActive(false);
        _firePanel.SetActive(false);

        _contactMen = false;
        _contactGirl = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Girl"))
        {
            _contactGirl = true;

        }
        if (other.gameObject.CompareTag("Men"))
        {
            _contactMen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Girl"))
        {
            _contactGirl = false;

        }
        if (other.gameObject.CompareTag("Men"))
        {
            _contactMen = false;
        }
    }
    private void Update()
    {
        StartCoroutine(nameof(WaitPanel));      
    }
    
   
    public void HirePanel()
    {
        _hirePanel.SetActive(false);
    }

    public void FirePanel()
    {
        _firePanel.SetActive(false);
    }

    IEnumerator WaitPanel()
    {
        if (_contactGirl == true)
        {
            yield return new WaitForSeconds(_waitTime);
            _hirePanel.SetActive(true);
        }

        if (_contactMen == true)
        {
            yield return new WaitForSeconds(_waitTime);
            _firePanel.SetActive(true);
        }
    }

    
}
