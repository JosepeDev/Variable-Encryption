﻿using System;

namespace EncTypes
{
    public struct EncLong
    {
        /// A struct for storing a 64-bit integer while efficiently keeping it encrypted in the memory
        /// Instead of encrypting and decrypting yourself, you can just use the encrypted type (EncType) of the variable you want to be encrypted
        /// The encryption will happen in the background without you worrying about it
        /// In the memory it is saved as a an array of weird bytes that are affected by random values { encryptionKeys array }
        /// Every time the value changes, the encryption keys change too. And it works exactly as a long (Int64)
        ///
        /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

        #region Variables And Properties

        private readonly byte[] encryptionKeys;

        // The encrypted value stored in memory
        private readonly byte[] encryptedValue;

        // Takes an encrypted value and returns it decrypted
        private long Decrypt
        {
            get
            {
                var valueBytes = new byte[8];
                for (int i = 0; i < 8; i++)
                {
                    valueBytes[i] = (byte)(encryptedValue[i] ^ encryptionKeys[i]);
                }
                return BitConverter.ToInt64(valueBytes, 0);
            }
        }

        public static long MaxValue { get => Int64.MaxValue; }
        public static long MinValue { get => Int64.MinValue; }

        #endregion

        #region Methods And Constructors

        private EncLong(long value)
        {
            encryptionKeys = new byte[8];
            encryptedValue = Encrypt(value, encryptionKeys);
        }

        // Encryption Key Generator
        static private Random random = new Random();

        // Takes a given value and returns it encrypted
        private static byte[] Encrypt(long value, byte[] keys)
        {
            random.NextBytes(keys);
            var valueBytes = BitConverter.GetBytes(value);
            for (int i = 0; i < 8; i++)
            {
                valueBytes[i] ^= keys[i];
            }
            return valueBytes;
        }

        // Int64 methods
        public int CompareTo(object value) => Decrypt.CompareTo(value);
        public int CompareTo(long value) => Decrypt.CompareTo(value);
        public bool Equals(long obj) => Decrypt.Equals(obj);
        public override bool Equals(object obj) => Decrypt.Equals(obj);
        public override int GetHashCode() => Decrypt.GetHashCode();
        public TypeCode GetTypeCode() => Decrypt.GetTypeCode();
        public override string ToString() => Decrypt.ToString();
        public string ToString(IFormatProvider provider) => Decrypt.ToString(provider);
        public string ToString(string format) => Decrypt.ToString(format);
        public string ToString(string format, IFormatProvider provider) => Decrypt.ToString(format, provider);

        #endregion

        #region Operators Overloading

        /// & | ^
        public static EncLong operator &(EncLong elong1, EncLong elong2) => new EncLong(elong1.Decrypt & elong2.Decrypt);
        public static EncLong operator |(EncLong elong1, EncLong elong2) => new EncLong(elong1.Decrypt | elong2.Decrypt);
        public static EncLong operator ^(EncLong elong1, EncLong elong2) => new EncLong(elong1.Decrypt ^ elong2.Decrypt);

        public static long operator &(EncLong elong1, long elong2) => elong1.Decrypt & elong2;
        public static long operator |(EncLong elong1, long elong2) => elong1.Decrypt | elong2;
        public static long operator ^(EncLong elong1, long elong2) => elong1.Decrypt ^ elong2;

        /// + - * / %
        public static EncLong operator +(EncLong elong1, EncLong elong2) => new EncLong(elong1.Decrypt + elong2.Decrypt);
        public static EncLong operator -(EncLong elong1, EncLong elong2) => new EncLong(elong1.Decrypt - elong2.Decrypt);
        public static EncLong operator *(EncLong elong1, EncLong elong2) => new EncLong(elong1.Decrypt * elong2.Decrypt);
        public static EncLong operator /(EncLong elong1, EncLong elong2) => new EncLong(elong1.Decrypt / elong2.Decrypt);
        public static EncLong operator %(EncLong elong1, EncLong elong2) => new EncLong(elong1.Decrypt % elong2.Decrypt);

        public static long operator +(EncLong elong1, long elong2) => elong1.Decrypt + elong2;
        public static long operator -(EncLong elong1, long elong2) => elong1.Decrypt - elong2;
        public static long operator *(EncLong elong1, long elong2) => elong1.Decrypt * elong2;
        public static long operator /(EncLong elong1, long elong2) => elong1.Decrypt / elong2;
        public static long operator %(EncLong elong1, long elong2) => elong1.Decrypt % elong2;

        public static long operator +(EncLong elong1, int elong2) => elong1.Decrypt + elong2;
        public static long operator -(EncLong elong1, int elong2) => elong1.Decrypt - elong2;
        public static long operator *(EncLong elong1, int elong2) => elong1.Decrypt * elong2;
        public static long operator /(EncLong elong1, int elong2) => elong1.Decrypt / elong2;
        public static long operator %(EncLong elong1, int elong2) => elong1.Decrypt % elong2;

        public static long operator +(EncLong elong1, short elong2) => elong1.Decrypt + elong2;
        public static long operator -(EncLong elong1, short elong2) => elong1.Decrypt - elong2;
        public static long operator *(EncLong elong1, short elong2) => elong1.Decrypt * elong2;
        public static long operator /(EncLong elong1, short elong2) => elong1.Decrypt / elong2;
        public static long operator %(EncLong elong1, short elong2) => elong1.Decrypt % elong2;

        public static long operator +(EncLong elong1, ushort elong2) => elong1.Decrypt + elong2;
        public static long operator -(EncLong elong1, ushort elong2) => elong1.Decrypt - elong2;
        public static long operator *(EncLong elong1, ushort elong2) => elong1.Decrypt * elong2;
        public static long operator /(EncLong elong1, ushort elong2) => elong1.Decrypt / elong2;
        public static long operator %(EncLong elong1, ushort elong2) => elong1.Decrypt % elong2;

        public static long operator +(EncLong elong1, uint elong2) => elong1.Decrypt + elong2;
        public static long operator -(EncLong elong1, uint elong2) => elong1.Decrypt - elong2;
        public static long operator *(EncLong elong1, uint elong2) => elong1.Decrypt * elong2;
        public static long operator /(EncLong elong1, uint elong2) => elong1.Decrypt / elong2;
        public static long operator %(EncLong elong1, uint elong2) => elong1.Decrypt % elong2;

        public static long operator +(EncLong elong1, byte elong2) => elong1.Decrypt + elong2;
        public static long operator -(EncLong elong1, byte elong2) => elong1.Decrypt - elong2;
        public static long operator *(EncLong elong1, byte elong2) => elong1.Decrypt * elong2;
        public static long operator /(EncLong elong1, byte elong2) => elong1.Decrypt / elong2;
        public static long operator %(EncLong elong1, byte elong2) => elong1.Decrypt % elong2;

        public static long operator +(EncLong elong1, sbyte elong2) => elong1.Decrypt + elong2;
        public static long operator -(EncLong elong1, sbyte elong2) => elong1.Decrypt - elong2;
        public static long operator *(EncLong elong1, sbyte elong2) => elong1.Decrypt * elong2;
        public static long operator /(EncLong elong1, sbyte elong2) => elong1.Decrypt / elong2;
        public static long operator %(EncLong elong1, sbyte elong2) => elong1.Decrypt % elong2;

        /// == != < >
        /// 

        public static bool operator ==(EncLong elong1, byte elong2) => elong1.Decrypt == elong2;
        public static bool operator !=(EncLong elong1, byte elong2) => elong1.Decrypt != elong2;
        public static bool operator >(EncLong elong1, byte elong2) => elong1.Decrypt > elong2;
        public static bool operator <(EncLong elong1, byte elong2) => elong1.Decrypt < elong2;

        public static bool operator ==(EncLong elong1, sbyte elong2) => elong1.Decrypt == elong2;
        public static bool operator !=(EncLong elong1, sbyte elong2) => elong1.Decrypt != elong2;
        public static bool operator >(EncLong elong1, sbyte elong2) => elong1.Decrypt > elong2;
        public static bool operator <(EncLong elong1, sbyte elong2) => elong1.Decrypt < elong2;

        public static bool operator ==(EncLong elong1, short elong2) => elong1.Decrypt == elong2;
        public static bool operator !=(EncLong elong1, short elong2) => elong1.Decrypt != elong2;
        public static bool operator >(EncLong elong1, short elong2) => elong1.Decrypt > elong2;
        public static bool operator <(EncLong elong1, short elong2) => elong1.Decrypt < elong2;

        public static bool operator ==(EncLong elong1, ushort elong2) => elong1.Decrypt == elong2;
        public static bool operator !=(EncLong elong1, ushort elong2) => elong1.Decrypt != elong2;
        public static bool operator >(EncLong elong1, ushort elong2) => elong1.Decrypt > elong2;
        public static bool operator <(EncLong elong1, ushort elong2) => elong1.Decrypt < elong2;

        public static bool operator ==(EncLong elong1, uint elong2) => elong1.Decrypt == elong2;
        public static bool operator !=(EncLong elong1, uint elong2) => elong1.Decrypt != elong2;
        public static bool operator >(EncLong elong1, uint elong2) => elong1.Decrypt > elong2;
        public static bool operator <(EncLong elong1, uint elong2) => elong1.Decrypt < elong2;

        public static bool operator ==(EncLong elong1, int elong2) => elong1.Decrypt == elong2;
        public static bool operator !=(EncLong elong1, int elong2) => elong1.Decrypt != elong2;
        public static bool operator >(EncLong elong1, int elong2) => elong1.Decrypt > elong2;
        public static bool operator <(EncLong elong1, int elong2) => elong1.Decrypt < elong2;

        public static bool operator ==(EncLong elong1, long elong2) => elong1.Decrypt == elong2;
        public static bool operator !=(EncLong elong1, long elong2) => elong1.Decrypt != elong2;
        public static bool operator >(EncLong elong1, long elong2) => elong1.Decrypt > elong2;
        public static bool operator <(EncLong elong1, long elong2) => elong1.Decrypt < elong2;

        public static bool operator ==(EncLong elong1, EncLong elong2) => elong1.Decrypt == elong2.Decrypt;
        public static bool operator !=(EncLong elong1, EncLong elong2) => elong1.Decrypt != elong2.Decrypt;
        public static bool operator <(EncLong elong1, EncLong elong2) => elong1.Decrypt < elong2.Decrypt;
        public static bool operator >(EncLong elong1, EncLong elong2) => elong1.Decrypt > elong2.Decrypt;

        /// assign
        public static explicit operator EncLong(ulong value) => new EncLong((long)value);
        public static implicit operator EncLong(long value) => new EncLong(value);
        public static implicit operator EncLong(int value) => new EncLong(value);
        public static implicit operator EncLong(uint value) => new EncLong(value);
        public static implicit operator EncLong(ushort value) => new EncLong(value);
        public static implicit operator EncLong(short value) => new EncLong(value);
        public static implicit operator EncLong(byte value) => new EncLong(value);
        public static implicit operator EncLong(sbyte value) => new EncLong(value);
        public static explicit operator EncLong(decimal value) => new EncLong((long)value);
        public static explicit operator EncLong(double value) => new EncLong((long)value);
        public static explicit operator EncLong(float value) => new EncLong((long)value);

        public static explicit operator ulong(EncLong elong1) => (ulong)elong1.Decrypt;
        public static implicit operator long(EncLong elong1) => elong1.Decrypt;
        public static explicit operator uint(EncLong elong1) => (uint)elong1.Decrypt;
        public static explicit operator int(EncLong elong1) => (int)elong1.Decrypt;
        public static explicit operator ushort(EncLong elong1) => (ushort)elong1.Decrypt;
        public static explicit operator short(EncLong elong1) => (short)elong1.Decrypt;
        public static explicit operator byte(EncLong elong1) => (byte)elong1.Decrypt;
        public static explicit operator sbyte(EncLong elong1) => (sbyte)elong1.Decrypt;
        public static implicit operator decimal(EncLong elong1) => elong1.Decrypt;
        public static implicit operator double(EncLong elong1) => elong1.Decrypt;
        public static implicit operator float(EncLong elong1) => elong1.Decrypt;

        #endregion
    }
}