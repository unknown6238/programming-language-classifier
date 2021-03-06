using System;
using System.Globalization;
using System.Collections;
/// <summary>
/// Array.Clear
/// </summary>
public class ArrayClear
{
    const int c_MaxValue = 10;
    const int c_MinValue = 0;
    public static int Main()
    {
        ArrayClear ArrayClear = new ArrayClear();

        TestLibrary.TestFramework.BeginTestCase("ArrayClear");
        if (ArrayClear.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }

    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;
        retVal = PosTest4() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negative]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        retVal = NegTest3() && retVal;
        retVal = NegTest4() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1:the type of array  is int ,Sets a range of elements in the Array to zero.");
        try
        {
            Array myArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            for (int i = 0; i < c_MaxValue; i++)
            {
                myArray.SetValue(i, i);
            }
            Array.Clear(myArray, c_MinValue, c_MaxValue);
            for (IEnumerator itr = myArray.GetEnumerator(); itr.MoveNext(); )
            {
                Int32 current = (Int32)itr.Current;
                if (current != 0)
                {
                    TestLibrary.TestFramework.LogError("001", "clear error.");
                    retVal = false;
                    break;
                }
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest2:the type of array  is string ,Sets a range of elements in the Array to null.");
        try
        {
            Array myArray = Array.CreateInstance(typeof(string), c_MaxValue);
            string generator = string.Empty;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = TestLibrary.Generator.GetString(-55, true, c_MinValue, c_MaxValue);
                myArray.SetValue(generator, i);
            }
            Array.Clear(myArray, c_MinValue, c_MaxValue);
            for (IEnumerator itr = myArray.GetEnumerator(); itr.MoveNext(); )
            {
                string current = (string)itr.Current;
                if (current != null)
                {
                    TestLibrary.TestFramework.LogError("003", "clear error.");
                    retVal = false;
                    break;
                }
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest3:the type of array  is bool ,Sets a range of elements in the Array to false.");
        try
        {
            Array myArray = Array.CreateInstance(typeof(bool), c_MaxValue);
            bool generator = true;
            for (int i = 0; i < c_MaxValue; i++)
            {
                myArray.SetValue(generator, i);
            }
            Array.Clear(myArray, c_MinValue, c_MaxValue);
            for (IEnumerator itr = myArray.GetEnumerator(); itr.MoveNext(); )
            {
                bool current = (bool)itr.Current;
                if (current)
                {
                    TestLibrary.TestFramework.LogError("005", "clear error.");
                    retVal = false;
                    break;
                }
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest4()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest4:the elements which near the cleared element that shouldn’t be cleared");
        try
        {
            Array myArray = Array.CreateInstance(typeof(string), c_MaxValue);
            string generator = string.Empty;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = "Hello";
                myArray.SetValue(generator, i);
            }
            int start = c_MaxValue / 2 - 1;
            int length = c_MaxValue / 2;
            Array.Clear(myArray, start, length);
            bool flag = false;
            for (int i = c_MinValue; i < start; i++)
            {
                string current = myArray.GetValue(i) as string;
                if (current == null)
                {
                    flag = true;
                    break;
                }
            }
            for (int j = start + length; j < c_MaxValue; j++)
            {
                string current = myArray.GetValue(j) as string;
                if (current == null)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                TestLibrary.TestFramework.LogError("007", "the elements that shouldn’t be cleared.");
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("008", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest1: array is a null reference.");

        try
        {
            Array myArray = null;
            Array.Clear(myArray, c_MinValue, c_MaxValue);
            TestLibrary.TestFramework.LogError("009", "array is a null reference.");
            retVal = false;
        }
        catch (ArgumentNullException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("010", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest2: index is less than the lower bound of array.");

        try
        {
            Array myArray = Array.CreateInstance(typeof(string), c_MaxValue);
            string generator = string.Empty;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = TestLibrary.Generator.GetString(-55, true, c_MinValue, c_MaxValue);
                myArray.SetValue(generator, i);
            }
            Array.Clear(myArray, c_MinValue - 1, c_MaxValue);
            TestLibrary.TestFramework.LogError("011", "index is less than the lower bound of array.");
            retVal = false;
        }
        catch (IndexOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("012", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest3: length is less than zero.");

        try
        {
            Array myArray = Array.CreateInstance(typeof(string), c_MaxValue);
            string generator = string.Empty;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = TestLibrary.Generator.GetString(-55, true, c_MinValue, c_MaxValue);
                myArray.SetValue(generator, i);
            }
            Array.Clear(myArray, c_MinValue, c_MinValue - 1);
            TestLibrary.TestFramework.LogError("013", "length is less than zero.");
            retVal = false;
        }
        catch (IndexOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("014", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest4()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest4: The sum of index and length is greater than the size of the Array.");

        try
        {
            Array myArray = Array.CreateInstance(typeof(string), c_MaxValue);
            string generator = string.Empty;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = TestLibrary.Generator.GetString(-55, true, c_MinValue, c_MaxValue);
                myArray.SetValue(generator, i);
            }
            Array.Clear(myArray, c_MinValue, c_MaxValue + 1);
            TestLibrary.TestFramework.LogError("015", "The sum of index and length is greater than the size of the Array.");
            retVal = false;
        }
        catch (IndexOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("016", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
}



