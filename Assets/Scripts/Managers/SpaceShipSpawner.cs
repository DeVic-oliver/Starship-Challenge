using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Fibonacci Spawner
public class SpaceShipSpawner : MonoBehaviour
{

    [SerializeField] private SpaceShip _spaceShip;
    [SerializeField] private int _fibbonacci = 10;

    int countFibbonacci = 0;


    // Start is called before the first frame update
    void Start()
    {
        GetFibonacciByCoroutine(8);
    }


    //private void GetFibonacci(int n)
    //{
    //    int term1 = 0;
    //    int term2 = 1;
    //    int result = term1 + term2;
    //    GetFibonacciSum(term1, term2, result);
    //}

    //private void GetFibonacciSum(long n1, long n2, long nextTerm){
    //    countFibbonacci++;
    //    IntantiateByFibbonacciValue(nextTerm);
    //    if (countFibbonacci < _fibbonacci)
    //    {
    //        long result = n1 + n2; 
    //        n1 = n2;
    //        n2 = result;
    //        GetFibonacciSum(n1, n2, result);
    //    }
    //}


    private void GetFibonacciByCoroutine(int n)
    {
        int term1 = 0;
        int term2 = 1;
        int result = term1 + term2;
        StartCoroutine(GetFibonacciSumCoroutine(term1, term2, result));
    }

    private IEnumerator GetFibonacciSumCoroutine(long n1, long n2, long nextTerm)
    {
        countFibbonacci++;
        IntantiateSpaceships(nextTerm);
        if (countFibbonacci < _fibbonacci)
        {
            long result = n1 + n2;
            n1 = n2;
            n2 = result;
            yield return new WaitForSeconds(1f);
            StartCoroutine(GetFibonacciSumCoroutine(n1, n2, result));
        }
    }

    private void IntantiateSpaceships(long quantity)
    {
        if (quantity > 0)
        {
            quantity--;
            Instantiate(_spaceShip);
            IntantiateSpaceships(quantity);
        }
    }


}
