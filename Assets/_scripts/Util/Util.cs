using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public static class Util
{
    /// <summary>
    /// Encuentra el valor de un angulo a partir de un Vector
    /// </summary>
    /// <param name="lAngle"></param>
    /// <returns></returns>
    public static Vector3 GetVectorFromAngle(float lAngle)
    {
        var angleRad = lAngle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    /// <summary>
    /// Retorna el angulo de un vector
    /// </summary>
    /// <param name="lVector"></param>
    /// <returns></returns>
    public static float GetAngleFromVector(Vector3 lVector)
    {
        lVector = lVector.normalized;
        var n = Mathf.Atan2(lVector.y, lVector.x) * Mathf.Rad2Deg;
        n += n < 0 ? 360 : 0;
        return n;
    }

    /// <summary>
    /// A faster fibonacci recursive function
    /// </summary>
    /// <param name="n">Fibonacci number to get</param>
    /// <returns> f(n) </returns>
    public static int Fibonacci(int n)
    {
        switch (n)
        {
            case 0:
                return 0;
            case 1:
            case 2:
                return 1;
        }

        if (n % 2 == 0) return Fibonacci(n / 2) * (Fibonacci(n / 2 + 1) + Fibonacci(n / 2 - 1));

        int n1, n2;
        n1 = Fibonacci((n + 1) / 2);
        n2 = Fibonacci((n - 1) / 2);

        return n1 * n1 + n2 * n2;
    }

    
}