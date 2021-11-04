using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    GameObject[,] matrix = new GameObject[5, 5];
    List<GameObject> stack = new List<GameObject>();
    System.Random random = new System.Random();
    int temp;
    State State;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int u = 0; u < 5; u++)
            {
                matrix[i, u] = gameObject.transform.GetChild(temp).gameObject;
                //Debug.Log(matrix[i, u].name + "\t" + temp);
                temp++;
            }
        }

        matrix[2, 2].GetComponent<State>().visited = true;
        stack.Add(matrix[2, 2]);

        while (stack.Count > 0)
        {
            GameObject posicionBacklog;
            GameObject posicionTemp;
            bool valid = false;
            int checks = 0;
            int direction;

            posicionBacklog = stack[stack.Count - 1];
            //Debug.Log(posicionBacklog);
            //Debug.Log(int.Parse(posicionBacklog.name[0].ToString()) + ", " + (int.Parse(posicionBacklog.name[2].ToString()) + 1));

            while (valid == false && checks < 10)
            {
                checks++;
                direction = random.Next(1, 5); // 1 derecha, 2 izquierda, 3 arriba, 4 abajo, 
                
                switch (direction)
                {
                    case 1:
                        if (int.Parse(posicionBacklog.name[2].ToString()) < 4)
                        {
                            posicionTemp = matrix[(int.Parse(posicionBacklog.name[0].ToString())), (int.Parse(posicionBacklog.name[2].ToString()) + 1)];

                            if (posicionTemp.GetComponent<State>().visited == false)
                            {
                                posicionBacklog.GetComponent<State>().walls[0] = false;
                                posicionBacklog.GetComponent<State>().visited = true;
                                posicionTemp.GetComponent<State>().visited = true;
                                stack.Add(posicionTemp);
                                valid = true;
                                //Debug.Log("derecha");
                            }
                        }
                        break;
                    case 2:
                        if (int.Parse(posicionBacklog.name[2].ToString()) > 0)
                        {
                            posicionTemp = matrix[(int.Parse(posicionBacklog.name[0].ToString())), (int.Parse(posicionBacklog.name[2].ToString()) - 1)];

                            if (posicionTemp.GetComponent<State>().visited == false)
                            {
                                posicionBacklog.GetComponent<State>().walls[1] = false;
                                posicionBacklog.GetComponent<State>().visited = true;
                                posicionTemp.GetComponent<State>().visited = true;
                                stack.Add(posicionTemp);
                                valid = true;
                                //Debug.Log("izquierda");
                            }
                        }
                        break;
                    case 3:
                        if (int.Parse(posicionBacklog.name[0].ToString()) > 0)
                        {
                            posicionTemp = matrix[(int.Parse(posicionBacklog.name[0].ToString()) - 1), (int.Parse(posicionBacklog.name[2].ToString()))];

                            if (posicionTemp.GetComponent<State>().visited == false)
                            {
                                posicionBacklog.GetComponent<State>().walls[2] = false;
                                posicionBacklog.GetComponent<State>().visited = true;
                                posicionTemp.GetComponent<State>().visited = true;
                                stack.Add(posicionTemp);
                                valid = true;
                                //Debug.Log("arriba");
                            }
                        }
                        break;
                    case 4:
                        if (int.Parse(posicionBacklog.name[0].ToString()) < 4)
                        {
                            posicionTemp = matrix[(int.Parse(posicionBacklog.name[0].ToString()) + 1), (int.Parse(posicionBacklog.name[2].ToString()))];

                            if (posicionTemp.GetComponent<State>().visited == false)
                            {
                                posicionBacklog.GetComponent<State>().walls[3] = false;
                                posicionBacklog.GetComponent<State>().visited = true;
                                posicionTemp.GetComponent<State>().visited = true;
                                stack.Add(posicionTemp);
                                valid = true;
                                //Debug.Log("abajo");
                            }
                        }
                        break;
                }

            } 
            if (valid == false)
            {
                stack.RemoveAt(stack.Count - 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
