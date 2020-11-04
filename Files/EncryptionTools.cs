using System;

static class EncryptionTools
{
    ///  Not a class you should use.
    ///  But it is a requirement to have it if you want to use most of the classes and structs.
    ///  Just copy it with all the other files and forget about it.
    ///  This is just a static class the classes uses to get a random float.
    /// 
    /// Wiki page: https://github.com/JosepeDev/Variable-Encryption/wiki
    /// Examples and tutorial: https://github.com/JosepeDev/Variable-Encryption/wiki/Examples-&-Tutorial

    #region Methods

    // The Random class for getting the random numbers
    static private Random random = new Random();

    // Returns a random float between 1 and 10
    public static float RandomNumberFloat()
    {
        return (float)(random.NextDouble() * 10);
    }

    // Returns a random double between 1 and 10
    public static double RandomNumberDouble()
    {
        return (random.NextDouble() * 10);
    }

    // Returns a random decimal between 1 and 10
    public static decimal RandomNumberDecimal()
    {
        return (decimal)(random.NextDouble() * 10);
    }

    #endregion
}