using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Service;

//Fibonacci Spawner
public class SpaceShipSpawner : MonoBehaviour
{

    [SerializeField] private SpaceShip _object;
    [SerializeField] private int _fibbonacci = 10;

    int countFibbonacci = 0;

    private List<SpaceShip> _pool = new List<SpaceShip>();


    private void Awake()
    {
        CreateSpaceShipPool();
    }

    private void CreateSpaceShipPool()
    {
        long result = Fibonacci.GetFibonacci(_fibbonacci);
        if(result > 0)
        {
            PopulatePoolList(result);
        }
    }

    private void PopulatePoolList(long result)
    {
        for (int i = 1; i <= result; i++)
        {
            SpaceShip temp = Instantiate(_object);
            temp.gameObject.SetActive(false);
            _pool.Add(temp);
        }
    }

    /**
     *  POOL:
     *  Os objetos podem ser instanciados primeiro e desativados para serem exibidos por fibonacci;
     *  
     */

    // Start is called before the first frame update
    void Start()
    {
        //GetFibonacciByCoroutine(8);
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
            Instantiate(_object);
            IntantiateSpaceships(quantity);
        }
    }


}
