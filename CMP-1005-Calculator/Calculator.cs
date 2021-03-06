using System;

namespace CMP_1005_Calculator
{
    public static class Calculator
    {
        static public double add(double leftNumber, double rightNumber)
        {
            return leftNumber + rightNumber;
        }

        static public double divide(double leftNumber, double rightNumber)
        {
            if (rightNumber != 0)
                return leftNumber / rightNumber;

            throw new DivideByZeroException(String.Format("Cannot divide {0} by zero", leftNumber));
        }

        static public double subtract(double leftNumber, double rightNumber)
        {
            return leftNumber - rightNumber;
        }

        static public double multiply(double leftNumber, double rightNumber)
        {
            return leftNumber * rightNumber;
        }
    }
}
