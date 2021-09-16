using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    int[] num = new int[] { 4, 2, 6, 1, 3 };

    private void Start()
    {
        Burburja();
    }

    void Burburja()
    {
        int aux;

        for (int i = 0; i < num.Length; i++)
        {
            for (int j = 0; j < num.Length; j++)
            {
                if (num[j] < num[i])
                {
                    aux = num[j];
                    num[j] = num[i];
                    num[i] = aux;
                }
            }
        }

        for (int i = 0; i < num.Length; i++)
        {
            Debug.Log(num[i]);
        }
    }
}
