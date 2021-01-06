using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SymmetriskKryptering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SymmetricAlgorithm selectedSymmetricAlgorithm;
        Stopwatch encryptTime = new Stopwatch();
        Stopwatch decryptTime = new Stopwatch();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateKeyAndVIBTN_Click(object sender, RoutedEventArgs e)
        {
            GenerateKeyAndIV();
        }

        private void EncryptBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                encryptTime.Start();
                byte[] ciphertext = Encrypt(StringToByteArray(plainASCIITXT.Text), HexStringToByteArray(keyTXT.Text), HexStringToByteArray(viTXT.Text));
                encryptTime.Stop();

                chiperASCIITXT.Text = ByteArrayToString(ciphertext);
                chiperHexTXT.Text = ByteArrayToHexString(ciphertext);
                plainHexTXT.Text = ByteArrayToHexString(StringToByteArray(plainASCIITXT.Text));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void DecryptBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decryptTime.Start();
                byte[] plaintext = Decrypt(HexStringToByteArray(chiperHexTXT.Text), HexStringToByteArray(keyTXT.Text), HexStringToByteArray(viTXT.Text));
                decryptTime.Stop();
                MessageBox.Show(ByteArrayToString(plaintext), "Decrypted message");
            }
            catch (Exception)
            {
                MessageBox.Show("Check inputs", "Error");
            }
        }

        private void GetEncryptTimeBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                encryptLBL.Content = "Time/message at encryption: " + encryptTime.Elapsed;
            }
            catch (Exception)
            {
                encryptLBL.Content = "Time/message at encryption: ";
            }
        }

        private void GetDecryptTimeBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decryptLBL.Content = "Time/message at decryption: " + decryptTime.Elapsed.ToString();
            }
            catch (Exception)
            {
                decryptLBL.Content = "Time/message at decryption: ";
            }
        }

        public void GenerateKeyAndIV()
        {
            selectedSymmetricAlgorithm = GetSymmetricAlgorithm(comboBox.Text);

            keyTXT.Text = ByteArrayToHexString(selectedSymmetricAlgorithm.Key);
            viTXT.Text = ByteArrayToHexString(selectedSymmetricAlgorithm.IV);
        }

        public byte[] Encrypt(byte[] mess, byte[] key, byte[] iv)
        {
            selectedSymmetricAlgorithm.Key = key;
            selectedSymmetricAlgorithm.IV = iv;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, selectedSymmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(mess, 0, mess.Length);
            cs.Close();
            return ms.ToArray();
        }

        public byte[] Decrypt(byte[] mess, byte[] key, byte[] iv)
        {
            byte[] plaintext = new byte[mess.Length];
            selectedSymmetricAlgorithm.Key = key;
            selectedSymmetricAlgorithm.IV = iv;
            MemoryStream ms = new MemoryStream(mess);
            CryptoStream cs = new CryptoStream(ms,
            selectedSymmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read); cs.Read(plaintext, 0, mess.Length);
            cs.Close();
            return plaintext;
        }

        public SymmetricAlgorithm GetSymmetricAlgorithm(string cipher)
        {
            SymmetricAlgorithm SymmetricAlgorithm = null;

            switch (cipher)
            {
                case "DES":
                    SymmetricAlgorithm = DES.Create();
                    break;
                case "3DES":
                    SymmetricAlgorithm = TripleDES.Create();
                    break;
                case "Rijndael":
                    SymmetricAlgorithm = Rijndael.Create();
                    break;
            }
            return (SymmetricAlgorithm);
        }
        public byte[] StringToByteArray(string s)
        {
            return CharArrayToByteArray(s.ToCharArray());
        }
        public byte[] CharArrayToByteArray(char[] array)
        {
            return Encoding.ASCII.GetBytes(array, 0, array.Length);
        }
        public string ByteArrayToString(byte[] array)
        {
            return Encoding.ASCII.GetString(array);
        }
        public string ByteArrayToHexString(byte[] array)
        {
            string s = "";
            int i;
            for (i = 0; i < array.Length; i++)
            {
                s = s + NibbleToHexString((byte)((array[i] >> 4) &
               0x0F)) + NibbleToHexString((byte)(array[i] &
               0x0F));
            }
            return s;
        }
        public byte[] HexStringToByteArray(string s)
        {
            byte[] array = new byte[s.Length / 2];
            char[] chararray = s.ToCharArray();
            int i;
            for (i = 0; i < s.Length / 2; i++)
            {
                array[i] = (byte)(((HexCharToNibble(chararray[2 * i]) << 4) & 0xF0) | ((HexCharToNibble(chararray[2 * i + 1]) & 0x0F)));
            }
            return array;
        }
        public string NibbleToHexString(byte nib)
        {
            string s;
            if (nib < 10)
            {
                s = nib.ToString();
            }
            else
            {
                char c = (char)(nib + 55);
                s = c.ToString();
            }
            return s;
        }

        public byte HexCharToNibble(char c)
        {
            byte value = (byte)c;
            if (value < 65)
            {
                value = (byte)(value - 48);
            }
            else
            {
                value = (byte)(value - 55);
            }
            return value;
        }
    }
}
