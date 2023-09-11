using Serilog;

namespace App;

internal class Operation
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static (string, int) GetSum(string a, string b)
    {
        Log.Information($"Запрос суммы двух чисел: a={a}, b={b}");

        try
        {
            int x = Convert.ToInt32(a);
            int y = Convert.ToInt32(b);

            if (ArePositive(x, y))
            {
                string textResult = "OK";
                int sumResult = x + y;

                Log.Information($"Сумма чисел {x} и {y} равна {sumResult}, Это {textResult}");

                return (textResult, sumResult);
            }
            else
            {
                Log.Warning($"Сумма двух отрицательных чисел: {x} и {y}. Это NOK.");

                return ("NOK", -1);
            }
        }
        catch (Exception exp)
        {
            Log.Fatal($"В качестве параметров переданы не числа: '{a}' & '{b}'. Это ERROR.");
            Log.Fatal($"{exp.Message}/n{exp.StackTrace}");

            return ("ERROR", -2);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mass"></param>
    /// <returns></returns>
    private static bool ArePositive(params int[] mass)
    {
        return mass.All(x => x > 0);
    }
}
