using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testone;

namespace Testone
{
    class Program
    {
        static void Main(string[] args)
        {

            int side1, side2;
            int k = 0;
            List<Vector3D> Original = new List<Vector3D>();
            
           

            Console.WriteLine(" Enter the number of sides in face one: ");
            side1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" Enter the number of sides in face two: ");
            side2 = Convert.ToInt32(Console.ReadLine());


            Vector3D a1 = new Vector3D();
            Vector3D a2 = new Vector3D();
            Vector3D a3 = new Vector3D();

            Vector3D b1 = new Vector3D();
            Vector3D b2 = new Vector3D();
            Vector3D b3 = new Vector3D();

            ArrayList d2 = new ArrayList();
            ArrayList Final_Matrix = new ArrayList();

            Vector3D X1 = new Vector3D();
            Vector3D T1 = new Vector3D();
            Vector3D T2 = new Vector3D();
           

            Vector3D[] Updated = new Vector3D[side1 + 2];
            Vector3D[] InterX = new Vector3D[side2 + 2];

            Console.WriteLine(" Enter the sides of the face 1 ( insert only one coordinate at a time and 3 side only as it becomes easy to make a plane: ");

            Console.WriteLine(" Now insert the coordinates for first vertex :");
            a1.x = double.Parse(Console.ReadLine());
          

            

            Console.WriteLine("That's it");
            a1.y = double.Parse(Console.ReadLine());
            a1.z = double.Parse(Console.ReadLine());

            Console.WriteLine(" The sum is : " + (Original[0].x + Original[0].y + Original[0].z));

            Console.WriteLine(" Now insert the coordinates for second vertex :");
            a2.x = double.Parse(Console.ReadLine());
            a2.y = double.Parse(Console.ReadLine());
            a2.z = double.Parse(Console.ReadLine());

            Console.WriteLine(" The sum is : " + (a2.x + a2.y + a2.z));

            Console.WriteLine(" Now insert the coordinates for third vertex :");
            a3.x = double.Parse(Console.ReadLine());
            a3.y = double.Parse(Console.ReadLine());
            a3.z = double.Parse(Console.ReadLine());

            d2.Add(a1);
            d2.Add(a2);
            d2.Add(a3);

            Console.WriteLine(d2.Count);

            double r1 = Vector3D.Cross(a3 - a1, a2 - a1).x;
            Console.Write(" The cross product is: " +r1);

            Console.WriteLine(" Enter the sides of the face 2 ( insert only one coordinate at a time and 3 side only as it becomes easy to make a plane: ");

            Console.WriteLine(" Now insert the coordinates for first vertex :");
            b1.x = double.Parse(Console.ReadLine());
            b1.y = double.Parse(Console.ReadLine());
            b1.z = double.Parse(Console.ReadLine());

            Console.WriteLine(" Now insert the coordinates for second vertex :");
            b2.x = double.Parse(Console.ReadLine());
            b2.y = double.Parse(Console.ReadLine());
            b2.z = double.Parse(Console.ReadLine());

            Console.WriteLine(" Now insert the coordinates for third vertex :");
            b3.x = double.Parse(Console.ReadLine());
            b3.y = double.Parse(Console.ReadLine());
            b3.z = double.Parse(Console.ReadLine());




            Console.Write(" The cross product: ", Vector3D.Cross(a3 - a1, a2 - a1));

            


            



            if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b1) != GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b2))
            {
                X1 = IntersectPoint(b2 - b1, b1, Vector3D.Cross(a3 - a1, a2 - a1), a1);
                Console.WriteLine(" The intersection point is : ", X1);
                /*if (PointInTriangle(InterX[k], a1, a2, a3) == true)
                {
                    d2.Add(X1);
                    k++;

                }*/
            }


            if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b2) != GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b3))
            {
                InterX[k] = IntersectPoint(b3 - b2, b2, Vector3D.Cross(a3 - a1, a2 - a1), a1);
                Console.WriteLine(" The intersection point is : ", InterX[k]);
                if (PointInTriangle(InterX[k], a1, a2, a3) == true)
                {
                    k++;
                }
            }


            if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b3) != GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b1))
            {
                InterX[k] = IntersectPoint(b1 - b3, b3, Vector3D.Cross(a3 - a1, a2 - a1), a1);
                Console.WriteLine(" The intersection point is : ", InterX[k]);
                if (PointInTriangle(InterX[k], a1, a2, a3) == true)
                {
                    k++;
                }
            }




            if (k == 1)
            {
                if (GenerateMatrix(Vector3D.Cross(b3 - b1, b2 - b1), b1, a1) != GenerateMatrix(Vector3D.Cross(b3 - b1, b2 - b1), b1, a2))
                {
                    InterX[k] = IntersectPoint(a2 - a1, a1, Vector3D.Cross(b3 - b1, b2 - b1), b1);
                    Console.WriteLine(" The intersection point is : ", InterX[k]);
                    if (PointInTriangle(InterX[k], b1, b2, b3) == true)
                    {
                        k++;
                    }
                }


                if (GenerateMatrix(Vector3D.Cross(b3 - b1, b2 - b1), b1, a2) != GenerateMatrix(Vector3D.Cross(b3 - b1, b2 - b1), b1, a3))
                {
                    InterX[k] = IntersectPoint(a3 - a2, a2, Vector3D.Cross(b3 - b1, b2 - b1), b1);
                    Console.WriteLine(" The intersection point is : ", InterX[k]);
                    if (PointInTriangle(InterX[k], b1, b2, b3) == true)
                    {
                        k++;
                    }
                }


                if (GenerateMatrix(Vector3D.Cross(b3 - b1, b2 - b1), b1, a3) != GenerateMatrix(Vector3D.Cross(b3 - b1, b2 - b1), b1, a1))
                {
                    InterX[k] = IntersectPoint(a1 - a3, a3, Vector3D.Cross(b3 - b1, b2 - b1), b1);
                    Console.WriteLine(" The intersection point is : ", InterX[k]);
                    if (PointInTriangle(InterX[k], b1, b2, b3) == true)
                    {
                        k++;
                    }
                }



            }

          




            /*
            for (int l = 0; l < 3; l++)
            {
                if (GenerateMatrix(Vector3D.Cross(a1[2] - a1[0], a1[1] - a1[0]), a1[0], a2[l - 1]) != GenerateMatrix(Vector3D.Cross(a1[2] - a1[0], a1[1] - a1[0]), a1[0], a2[l]))
                {
                    InterX[k] = IntersectPoint(a2[l - 1] - a2[l], a2[0], Vector3D.Cross(a1[2] - a1[0], a1[1] - a1[0]), a1[0]);

                    if (PointInTriangle(InterX[k], a1[0], a1[1], a1[2]) == true)
                    {

                        k++;

                        if (pointInside == 0)
                        {
                            while (j <= (l + 2))
                            {
                                if (j == ((z + 1) - k))
                                {
                                    Updated[j] = a1[l - k];
                                    k++;
                                }
                                else
                                {
                                    Updated[j] = a1[z];
                                    z++;
                                }

                                j++;
                            }

                            pointInside++;

                        }

                        else (pointInside == 1)
                        {



                        }


                    }
                }

            }


            if (k == 1)
            {

                for (int l = 0; l < 3; l++)
                {
                    if (GenerateMatrix(Vector3D.Cross(a2[2] - a2[0], a2[1] - a2[0]), a2[0], a1[l - 1]) != GenerateMatrix(Vector3D.Cross(a2[2] - a2[0], a2[1] - a2[0]), a2[0], a1[l]))
                    {
                        InterX[k] = IntersectPoint(a1[l - 1] - a1[l], a1[l], Vector3D.Cross(a2[2] - a2[0], a2[1] - a2[0]), a2[0]);

                        if (PointInTriangle(InterX[k], a1[0], a1[1], a1[2]) == true)
                        {

                            k++;

                            if (pointInside == 0)
                            {
                                while (j <= (l + 2))
                                {
                                    if (j == ((z + 1) - k))
                                    {
                                        Updated[j] = a1[l - k];
                                        k++;
                                    }
                                    else
                                    {
                                        Updated[j] = a1[z];
                                        z++;
                                    }

                                    j++;
                                }

                                pointInside++;

                            }

                            else (pointInside == 1)
                            {



                            }


                       }
                    }

                }

            }*/


            if (k == 1)
            {

                if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b1) == GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b2) == true)
                {
                    Final_Matrix.Add(b3);
                    Final_Matrix.Add(T1);
                    Final_Matrix.Add(T2);

                }

                if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b2) == GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b3) == true)
                {
                    Final_Matrix.Add(b1);
                    Final_Matrix.Add(T1);
                    Final_Matrix.Add(T2);

                }

                if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b3) == GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b1) == true)
                {
                    Final_Matrix.Add(b2);
                    Final_Matrix.Add(T1);
                    Final_Matrix.Add(T2);

                }

            }


            /// The points that lie on the mormal of the plane direction will not be visible, So we can start sorting out 
            /// that portion of surface from very intially
            /// 


            if (k == 3)
            {

                if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b1) == GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b2) == true)
                {
                    Final_Matrix.Add(b3);
                    Final_Matrix.Add(T1);
                    Final_Matrix.Add(T2);

                }

                if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b2) == GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b3) == true)
                {
                    Final_Matrix.Add(b1);
                    Final_Matrix.Add(T1);
                    Final_Matrix.Add(T2);

                }

                if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b3) == GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b1) == true)
                {
                    Final_Matrix.Add(b2);
                    Final_Matrix.Add(T1);
                    Final_Matrix.Add(T2);

                }





            }





            if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b1) == GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b2) == false)
            {
                Final_Matrix.Add(b1);
                Final_Matrix.Add(b2);
                Final_Matrix.Add(T1);
                Final_Matrix.Add(T2);

            }

            if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b2) == GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b3) == false)
            {
                Final_Matrix.Add(b2);
                Final_Matrix.Add(b3);
                Final_Matrix.Add(T1);
                Final_Matrix.Add(T2);

            }

            if (GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b3) == GenerateMatrix(Vector3D.Cross(a3 - a1, a2 - a1), a1, b1) == false)
            {
                Final_Matrix.Add(b3);
                Final_Matrix.Add(b1);
                Final_Matrix.Add(T1);
                Final_Matrix.Add(T2);

            }





            bool GenerateMatrix(Vector3D planeOf, Vector3D v1, Vector3D v4)
            {

                double detValue = 0;

                double A = v4.x - v1.x;
                double B = v4.y - v1.x;
                double C = v4.z - v4.z;

                detValue = A * planeOf.x + B * planeOf.y + C * planeOf.z;

                if (detValue > 0)
                    return true;

                else
                    return false;

            }





            Vector3D IntersectPoint(Vector3D rayVector, Vector3D rayPoint, Vector3D planeNormal, Vector3D planePoint)
            {
                var diff = rayPoint - planePoint;
                var prod1 = Vector3D.Dot(diff, planeNormal);
                var prod2 = Vector3D.Dot(rayVector, planeNormal);
                var prod3 = prod1 / prod2;
                return rayPoint - rayVector * prod3;
            }





            bool SameSide(Vector3D p1, Vector3D p2, Vector3D a, Vector3D b)
            {
                if (Vector3D.Dot(Vector3D.Cross((b - a), (p1 - a)), Vector3D.Cross((b - a), (p2 - a))) >= 0)
                    return true;

                else
                    return false;

                /*   
                cp1 = CrossProduct(b-a, p1-a)
                cp2 = CrossProduct(b-a, p2-a)
                if DotProduct(cp1, cp2) >= 0 then return true
                else return false*/


            }

            bool PointInTriangle(Vector3D p, Vector3D a, Vector3D b, Vector3D c)
            {

                if (SameSide(p, a, b, c) && SameSide(p, b, a, c) && SameSide(p, c, a, b))
                    return true;
                else
                    return false;
            }

            Console.ReadLine();

        }


    
        

    }


}
