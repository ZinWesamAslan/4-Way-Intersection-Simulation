using System;
using System.Security.Cryptography;

namespace IntersectionSimulation4Way
{
    public static class ClsSecurityHelper
    {
        // دالة توليد الهاش باستخدام الملح والفلفل
        public static string ComputeHash(string password, string salt, string pepper)
        {
            // 1. دمج كلمة المرور مع الفلفل
            string passwordWithPepper = password + pepper;

            // 2. تحويل الملح من نص (Base64) إلى مصفوفة بايتات
            byte[] saltBytes = Convert.FromBase64String(salt);

            // 3. تطبيق خوارزمية PBKDF2 مع 100,000 دورة تكرار لزيادة الأمان
            using (var pbkdf2 = new Rfc2898DeriveBytes(passwordWithPepper, saltBytes, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32); // توليد مفتاح بحجم 256-bit
                return Convert.ToBase64String(hashBytes);
            }
        }

        // دالة مساعدة لتوليد ملح عشوائي جديد (تستخدمها أنت كـ مطور لمرة واحدة لإنشاء الملح)
        public static string GenerateRandomSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}