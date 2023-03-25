using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [Header("Speed Limits")]
    [Tooltip("A random number between those limits will be the speed")]
    [SerializeField] private float _min = 5f;
    [Tooltip("A random number between those limits will be the speed")]
    [SerializeField] private float _max = 50f;
    private float _currentSpeed = 0;
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
        _currentSpeed = Random.Range(_min, _max);
    {
        StartCoroutine("BeginCountdownToDisable");
    }

    private IEnumerator BeginCountdownToDisable()
    {
        yield return new WaitForSeconds(_delayToIncrementSpeed);
        gameObject.SetActive(false);
    }

        float _delayToIncrementSpeed = 0.1f;
        while (gameObject.activeSelf)
        {
            _currentSpeed += _speedIncrement;
            yield return new WaitForSeconds(_delayToIncrementSpeed);
        }
    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = transform.position + Vector3.forward * Time.deltaTime * _currentSpeed;
    }
}
