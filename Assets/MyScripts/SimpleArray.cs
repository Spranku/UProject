using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = System.Random;


public class SimpleArray : MonoBehaviour
{
    private void Start()
    {
        //int[] array = SetArray(100);
        //WriteArray(array);

        /* Sort */
        // BubbleSort(array);

        //WriteArray(array
        //

        /* Step 1: sum */
        int[] arrSum = {7,8,9,10,11,12,13,14,15,16,17,18,19,20,21 };
        Sum(arrSum);

        /* Step 2: sum of array */
        int[] arrSumArr = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
        SumArr(arrSumArr);

        /* Step 3: index first num */
        int[] firstArr = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        FirstNum(firstArr, 34);
        FirstNum(firstArr, 55);

        /* Step 4: sort of choice */

    }

    private void Sum(int[] arr)
    {
        int result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            //int temp = arr[i] % 2;

            if (arr[i] % 2 == 0)
            {
                result += arr[i];
                continue;
            }

        }
            Debug.Log("Sum = " + result);
    }

    private void SumArr(int[] arr)
    {
        int result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            //int temp = arr[i] % 2;

            if (arr[i] % 2 == 0)
            {
                result += arr[i];
                continue;
            }

        }
        Debug.Log("Sum of array = " + result);
    }

    private void FirstNum(int[] arr, int num)
    {
        int searchNum = num;
        int searchIndex = 0;

        for (int j = 0;j < arr.Length; ++j)
        {
            if (arr[j] == searchNum)
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    if (arr[i] == searchNum)
                    {
                        searchIndex = i;
                        break;
                    }

                }
                break;
            }
            else
            {
                searchIndex = -1;
            }
        }
        Debug.Log("Search index of " + num + " = " + searchIndex);
    }

    //private int[] SetArray(int lenght)
    //{
    //    int[] arr = new int[lenght];

    //    /* */
    //    Random rnd = new Random();

    //    for (int i = 0; i < lenght; i++)
    //    {
    //        arr[i] = rnd.Next(-100,101);
    //    }

    //    return arr;
    //}

    private void WriteArray(int[] arr)
    {
        foreach (int i in arr)
        {
            Debug.Log(i);
        }
    }

    //private void BubbleSort(int[] arr)
    //{
    //    int temp = 0;

    //    for (int i = 0;i < arr.Length;++i)
    //    {
    //        for(int j = 0;j < arr.Length - i - 1; ++j)
    //        {
    //            if (arr[j] > arr[j +1])
    //            {
    //                temp = arr[j];
    //                arr[j] = arr[j + 1];
    //                arr[j + 1] = temp;
    //            }
    //        }
    //    }
    //}
}
