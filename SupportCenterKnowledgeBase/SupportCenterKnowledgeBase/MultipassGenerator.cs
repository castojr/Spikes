using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace DeskMultipassSpike {
  public class MultipassGenerator {
    public MultipassGenerator(string siteKey, string apiKey) {
      mSiteKey = siteKey;
      mApiKey = apiKey;
    }

    private static byte[] Encrypt(string json, byte[] key, byte[] iv) {
      byte[] encrypted;

      using (var aesAlg = new AesManaged()) {

        var encryptor = aesAlg.CreateEncryptor(key, iv);

        using (var msEncrypt = new MemoryStream())
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
          using (var swEncrypt = new StreamWriter(csEncrypt))
            swEncrypt.Write(json);
          return msEncrypt.ToArray();
        }
      }
    }

    private byte[] EncryptionKey() {
      byte[] key;
      var salt = Encoding.UTF8.GetBytes(mApiKey + mSiteKey);

      using (SHA1 sha1 = new SHA1CryptoServiceProvider()) {
        key = sha1.ComputeHash(salt);
        Array.Resize(ref key, 16);
      }

      return key;
    }

    private byte[] Signature(string multipass) {
      byte[] signature;

      using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(mApiKey)))
      using (var msHmac = new MemoryStream(Encoding.UTF8.GetBytes(multipass)))
        signature = hmac.ComputeHash(msHmac);

      return signature;
    }

    public string GenerateLine(string customerName, string customerEmail, string customerRole) {
      return GenerateLine(JsonConvert.SerializeObject(new Dictionary<string, string> {
                                                                                       {"uid", Guid.NewGuid().ToString()},
                                                                                       {"expires", DateTime.UtcNow.AddMinutes(10).ToString("o")},
                                                                                       {"customer_email", customerEmail},
                                                                                       {"customer_name", customerName},
                                                                                       {"customer_custom_level", customerRole}
                                                                                     }));
    }

    public string GenerateLine(string customerName, string customerEmail, string customerRole, string brand) {
      return GenerateLine(JsonConvert.SerializeObject(new Dictionary<string, string> {
                                                                                       {"uid", Guid.NewGuid().ToString()},
                                                                                       {"expires", DateTime.UtcNow.AddMinutes(10).ToString("o")},
                                                                                       {"to", string.Format("https://eqisengineeringtestaccount.desk.com/?b_id={0}",brand)},
                                                                                       {"customer_email", customerEmail},
                                                                                       {"customer_name", customerName},
                                                                                       {"customer_custom_level", customerRole}
                                                                                     }));
    }

    public string GenerateLine(string json) {
      using (var myAes = new AesManaged()) {
        var encrypted = Encrypt(json, EncryptionKey(), myAes.IV);

        var combined = new byte[myAes.IV.Length + encrypted.Length];
        Array.Copy(myAes.IV, 0, combined, 0, myAes.IV.Length);
        Array.Copy(encrypted, 0, combined, myAes.IV.Length, encrypted.Length);

        var multipass = Convert.ToBase64String(combined);

        var encryptedSignature = Signature(multipass);
        var signature = Convert.ToBase64String(encryptedSignature);

        multipass = Uri.EscapeDataString(multipass);
        signature = Uri.EscapeDataString(signature);

        return string.Format(_DeskUrl, mSiteKey, multipass, signature);
      }
    }

    private const string _DeskUrl =
      "https://{0}.desk.com/customer/authentication/multipass/callback?multipass={1}&signature={2}";

    private readonly string mApiKey;
    private readonly string mSiteKey;
  }
}