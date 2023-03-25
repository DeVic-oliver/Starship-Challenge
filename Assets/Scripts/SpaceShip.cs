using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _speedIncrement = 1.25f;

    private float _delayToIncrementSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutineToDisable();
    }

    private void OnEnable()
    {
        StartCoroutineToDisable();
    }

    private void StartCoroutineToDisable()
    {
        StartCoroutine("BeginCountdownToDisable");
    }

    private IEnumerator BeginCountdownToDisable()
    {
        yield return new WaitForSeconds(_delayToIncrementSpeed);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
