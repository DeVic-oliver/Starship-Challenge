using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Service;

public class SpaceShipSpawner : MonoBehaviour
{

    [SerializeField] private SpaceShip _spaceShip;
    [SerializeField] private int _fibbonacci = 10;

    int countFibbonacci = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Fibonacci.Fibbonacci(10));
        //Fibbonacci(_fibbonacci);
    }


    private void Fibbonacci(int n)
    {
        int term1 = 0;
        int term2 = 1;
        int result = term1 + term2;
        Debug.Log(result);
        FibbonacciAux(term1, term2, result);
    }

    private void FibbonacciAux(long n1, long n2, long nextTerm){
        countFibbonacci++;
        if(countFibbonacci < _fibbonacci)
        {
            long result = n1 + n2; 
            n1 = n2;
            n2 = result;
            Debug.Log(result);
            FibbonacciAux(n1, n2, result);
        }
    }

    private void IntantiateByFibbonacciValue(long quantity)
    {
        if(quantity > 0)
        {
            quantity--;
            //Instantiate(_spaceShip);
            //Debug.Log($"Space Ship ID: {quantity}");
            IntantiateByFibbonacciValue(quantity);
        }
    }

}
