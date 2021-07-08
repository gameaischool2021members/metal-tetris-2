using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextValues : MonoBehaviour
{

    // ORDER PRICES 
    public int priceOrder1, priceOrder2, priceOrder3;
    public Text priceOrder1Text, priceOrder2Text, priceOrder3Text;

    // Number of parts per Order
    public Text partsOrder1Piece1Text, partsOrder1Piece2Text, partsOrder1Piece3Text, partsOrder1Piece4Text;
    public Text partsOrder2Piece1Text, partsOrder2Piece2Text, partsOrder2Piece3Text, partsOrder2Piece4Text;
    public Text partsOrder3Piece1Text, partsOrder3Piece2Text, partsOrder3Piece3Text, partsOrder3Piece4Text;


    // move this to another script?
    public int[] piecesInOrder1 = new int[4]; // 0 = part1, 1 = part2, 2 = part3, 3 = part4
    public int[] piecesInOrder2 = new int[4];
    public int[] piecesInOrder3 = new int[4];



    // Start is called before the first frame update
    void Start()
    {

    


        // PARTS PER ORDER - already generated random num of parts in another script?
        piecesInOrder1 = generateRandomPartValuesForOrder();
        piecesInOrder2 = generateRandomPartValuesForOrder();
        piecesInOrder3 = generateRandomPartValuesForOrder();

        setUITextNumOfPartsPerOrder(1);
        setUITextNumOfPartsPerOrder(2);
        setUITextNumOfPartsPerOrder(3);


        // PRICE OF ORDERS
        priceOrder1 = calculateOrderPrice(piecesInOrder1);
        priceOrder2 = calculateOrderPrice(piecesInOrder2);
        priceOrder3 = calculateOrderPrice(piecesInOrder3);
        setUITextPriceValues();




    }

    // Update is called once per frame
    void Update()
    {

    }


    // TO DO 
    int calculateOrderPrice(int[] partQuantities)  // arguments - order num, num of parts?
    {

        // CALCULATE BASED ON NUM OF PIECES ( + TYPE? ) - TO DO 

        int totalValueOfOrder = 0;

        totalValueOfOrder += (partQuantities[0] * 60);
        totalValueOfOrder += (partQuantities[1] * 50);
        totalValueOfOrder += (partQuantities[2] * 40);
        totalValueOfOrder += (partQuantities[3] * 50);

        // for now - just for testing - TO FIX 
        return totalValueOfOrder;

    }


    void setUITextPriceValues()
    {
        priceOrder1Text.text = priceOrder1.ToString();
        priceOrder2Text.text = priceOrder2.ToString();
        priceOrder3Text.text = priceOrder3.ToString();

    }



    // TO DO - see if should move this to another script 
    int[] generateRandomPartValuesForOrder()
    {
        int[] fourDifferentPartValues = new int[4];


   /*     int val1 = 1;
        int val2 = 1;
        int val3 = 1;
        int val4 = 0;

*/
        int totalValue = 0;


        int randomVal = Random.Range(0, 3); // 0 , 1 or 2

        if (totalValue+randomVal < 4)
        {
            fourDifferentPartValues[0] = randomVal;
            totalValue += randomVal;
        }

        
        randomVal = Random.Range(0, 3); // 0 , 1 or 2

        if (totalValue+randomVal < 4)
        {
            fourDifferentPartValues[1] = randomVal;
            totalValue += randomVal;
        }

        if (totalValue < 4)
        {
            if (totalValue < 3)
            {
                int randomVal2 = Random.Range(0, 2); // 0 , 1 

                if (randomVal2 == 0)
                {
                    fourDifferentPartValues[2] = 1;
                    totalValue += 1;
                }
                else
                {
                    fourDifferentPartValues[2] = 2;
                    totalValue += 2;
                }
            }
            else
            {
                fourDifferentPartValues[2] = 1;
                totalValue += 1;
            }
        }

        if (totalValue < 4)
        {
            fourDifferentPartValues[3] = 4-totalValue;
        }


        return fourDifferentPartValues;
    }


    void setUITextNumOfPartsPerOrder(int orderNum)
    {
        if (orderNum == 1)
        {
            partsOrder1Piece1Text.text = "x" + piecesInOrder1[0].ToString();
            partsOrder1Piece2Text.text = "x" + piecesInOrder1[1].ToString();
            partsOrder1Piece3Text.text = "x" + piecesInOrder1[2].ToString();
            partsOrder1Piece4Text.text = "x" + piecesInOrder1[3].ToString();
        }

        if (orderNum == 2)
        {
            partsOrder2Piece1Text.text = "x" + piecesInOrder2[0].ToString();
            partsOrder2Piece2Text.text = "x" + piecesInOrder2[1].ToString();
            partsOrder2Piece3Text.text = "x" + piecesInOrder2[2].ToString();
            partsOrder2Piece4Text.text = "x" + piecesInOrder2[3].ToString();
        }

        if (orderNum == 2)
        {
            partsOrder3Piece1Text.text = "x" + piecesInOrder3[0].ToString();
            partsOrder3Piece2Text.text = "x" + piecesInOrder3[1].ToString();
            partsOrder3Piece3Text.text = "x" + piecesInOrder3[2].ToString();
            partsOrder3Piece4Text.text = "x" + piecesInOrder3[3].ToString();
        }
    }
}
