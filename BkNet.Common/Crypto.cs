using System;
using System.Security.Cryptography;
using System.Text;

namespace BkNet.Common
{
	/// <summary>
	/// This class for for Encrypt and Decrypt data.
	/// </summary>
	public class Crypto
	{
		private string myKey = "S4DT4PP";
		private TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
		private MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
		/// <summary>
		/// This function is responsible for decrypt data.
		/// </summary>
		/// <param name="myString"></param>
		/// <returns></returns>
		public string Decrypt(string myString)
		{	
			cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
			cryptDES3.Mode = CipherMode.ECB;
			ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
			byte[] buff = Convert.FromBase64String(myString);
			return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
		}

		/// <summary>
		/// This function is responsible for encrypt data.
		/// </summary>
		/// <param name="myString"></param>
		/// <returns></returns>
		public string Encrypt(string myString)
		{
			cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
			cryptDES3.Mode = CipherMode.ECB;
			ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
			ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
			byte[] buff = ASCIIEncoding.ASCII.GetBytes(myString);
			return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));

		}
	}
}
