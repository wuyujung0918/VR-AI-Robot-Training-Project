using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inverse : MonoBehaviour
{
    

    static void Main()
    {
        Console.WriteLine("Enter the target coordinates (x, y, z):");
        Console.Write("x: ");
        double targetX = double.Parse(Console.ReadLine());

        Console.Write("y: ");
        double targetY = double.Parse(Console.ReadLine());

        Console.Write("z: ");
        double targetZ = double.Parse(Console.ReadLine());

        double[] jointAngles = CalculateInverseKinematics(targetX, targetY, targetZ);


        // 顯示結果
        Console.WriteLine("Joint Angles: Theta1 = {0}, Theta2 = {1}, Theta3 = {2}, Theta4 = {3}, Theta5 = {4}, Theta6 = {5}",
            jointAngles[0], jointAngles[1], jointAngles[2], jointAngles[3], jointAngles[4], jointAngles[5]);
        Console.WriteLine("\n M21 G90 G01 X{0} Y{1} Z{2} A{3} B{4} C{5} F2000.00",
           Math.Round(jointAngles[0]), Math.Round(jointAngles[1]), Math.Round(jointAngles[2]), jointAngles[3], Math.Round(jointAngles[4]+90), jointAngles[5]);
    }

    public static int[] CalcDegree(Vector3 endNodePos) {

        endNodePos.y -= 10;

        Vector3 pos = new Vector3();
        pos.x = endNodePos.x;
        pos.y = -endNodePos.z;
        pos.z = endNodePos.y;


        int[] degreeArr = new int[6];

        double[] jointAngles = CalculateInverseKinematics(pos.x, pos.y, pos.z);

        for (int i=0;i<=5 ;i++ )
        {
            degreeArr[i] = (int)Math.Round(jointAngles[i]);
        }

        return degreeArr;
    }


    static double[] CalculateInverseKinematics(double x, double y, double z)
    {
        double[] angles = new double[6];
        double x1 = x * 10;
        double y1 = y * 10;
        double z1 = z * 10 + 24.29;
        double cs = Math.PI / 180.0;

        // 計算 Theta1
        angles[0] = Math.Atan2(y, x) / cs;

        // 計算 Theta3
        double m1 = x1 * x1 + y1 * y1 + z1 * z1 - 59.38 * (Math.Cos(angles[0] * cs) * x1 + Math.Sin(angles[0] * cs) * y1) - 254 * z1 + 29.69 * 29.69 + 127 * 127;
        double m2 = (m1 - 108 * 108 - 20 * 20 - 168.98 * 168.98) / 216;
        angles[2] = Math.Atan2(m2, Math.Sqrt(20 * 20 + 168.98 * 168.98 - m2 * m2)) / cs - Math.Atan2(20, 168.98) / cs;


        // 計算 Theta2        
        double m3 = Math.Cos(angles[0] * cs) * x1 + Math.Sin(angles[0] * cs) * y1 - 29.69;
        double m4 = 108 * Math.Cos(angles[2] * cs) + 20;
        angles[1] = Math.Atan2(m4, - Math.Sqrt(m3 * m3 + (z1 - 127) * (z1 - 127) - m4 * m4)) / cs - Math.Atan2(m3, z1 - 127) / cs - angles[2] - 90;


        // 計算 Theta4,5,6
        angles[3] = 35;

        angles[4] = - angles[1] - angles[2];

        angles[5] = 0;


        Debug.Log(angles[0]);
        Debug.Log(angles[1]);
        Debug.Log(angles[2]);
        Debug.Log(angles[3]);
        Debug.Log(angles[4]);
        Debug.Log(angles[5]);
        return angles;

    }
 }
