using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Service;
using Assets.Scripts.Managers;

public class SpaceShipSpawner : MonoBehaviour
{

    [SerializeField] private SpaceShip _object;
    [SerializeField] private int _fibbonacci;

    private List<SpaceShip> _pool = new List<SpaceShip>();
    private long _poolTotal = 0;

    private UIManager _ui;

    public void ReturnToPool()
    {
        _ui.DecrementActiveSpaceShips();
    }

    private void Awake()
    {
        InitComponents();
        SetPoolSizeByFibonacci();
        PopulatePool();
    }

    private void InitComponents()
    {
        _ui = GetComponent<UIManager>();
    }

    private void SetPoolSizeByFibonacci()
    {
        int fibonacciMinTerm = 1;
        AssignFibonacciSumInPoolSize(fibonacciMinTerm);
    }

    private void AssignFibonacciSumInPoolSize(int term){
        if (term <= _fibbonacci)
        {
            _poolTotal += Fibonacci.GetFibonacci(term);
            term++;
            AssignFibonacciSumInPoolSize(term);
        }
    }

    private void PopulatePool()
    {
        int count = 1;
        AddSpaceShipToPoolUntilReachsLimit(count);
    }

    private void AddSpaceShipToPoolUntilReachsLimit(int i)
    {
        if( i <= _poolTotal )
        {
            SpaceShip temp = CreateDeactivatedSpaceShip();
            _pool.Add(temp);
            i++;
            AddSpaceShipToPoolUntilReachsLimit(i);
        }
    }

    private SpaceShip CreateDeactivatedSpaceShip()
    {
        SpaceShip temp = Instantiate(_object);
        temp.AssignSpawner(this);
        temp.gameObject.SetActive(false);
        return temp;
    }

    void Start()
    {
        StartCoroutine("ReplayFibonacci");
    }

    private IEnumerator ReplayFibonacci()
    {
        while (true)
        {
            float delayToReplayMechanicAfterEnds = 10f;
            yield return new WaitForSeconds(delayToReplayMechanicAfterEnds);
            StartFibonacci();
        }
    }

    private void StartFibonacci()
    {
        int initialTerm1 = 0;
        int initialTerm2 = 1;
        int result = initialTerm1 + initialTerm2;
        StartCoroutine(StartCreationOfSpaceShipByFibonacci(initialTerm1, initialTerm1, initialTerm2, result));
    }

    private IEnumerator StartCreationOfSpaceShipByFibonacci(int currentTerm, long n1, long n2, long result)
    {
        currentTerm++;
        
        IntantiateSpaceships(result);

        if (currentTerm < _fibbonacci)
        {
            long nextTerm = n1 + n2;
            n1 = n2;
            n2 = nextTerm;

            float delayToNextIteration = 0.25f;
            yield return new WaitForSeconds(delayToNextIteration);
            StartCoroutine(StartCreationOfSpaceShipByFibonacci(currentTerm, n1, n2, nextTerm));
        }
    }

    private void IntantiateSpaceships(long quantity)
    {
        if (quantity > 0)
        {
            quantity--;
            ActivePooledObjects();
            IntantiateSpaceships(quantity);
        }
    }

    private void ActivePooledObjects()
    {
        long indexListTotal = _poolTotal - 1;
        ActivePooledObject(indexListTotal);
    }

    private void ActivePooledObject(long index)
    {
        if(index >= 0)
        {
            GameObject spaceShip = _pool[(int)index].gameObject;
            if (!spaceShip.activeInHierarchy)
            {
                spaceShip.SetActive(true);
                _ui.IncrementActiveSpaceShips();
            }
            else
            {
                index--;
                ActivePooledObject(index);
            }
        }
    }
}