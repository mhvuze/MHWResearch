using System;

namespace WorldEventDataEditor
{
    class Crypto
    {
        // Decrypt tss
        public static byte[] DecryptTss(byte[] Input)
        {
            byte[] Decrypted = new byte[Input.Length];
            Array.Copy(Input, Decrypted, 0x0C);

            for (int Pos = 0x0C, Key = 0x0A; Pos < Input.Length; Pos++)
            {
                int Stored = Input[Pos];
                Decrypted[Pos] = (byte)(Input[Pos] ^ Key);
                Key = Stored;
            }

            return Decrypted;
        }

        // Encrypt tss
        public static byte[] EncryptTSS(byte[] Input)
        {
            byte[] Encrypted = new byte[Input.Length];
            Array.Copy(Input, Encrypted, 0x0C);

            for (int Pos = 0x0C, Key = 0x0A; Pos < Input.Length; Pos++)
            {
                Encrypted[Pos] = (byte)(Input[Pos] ^ Key);
                Key = Encrypted[Pos];
            }

            return Encrypted;
        }
    }
}
