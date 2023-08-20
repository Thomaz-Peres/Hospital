using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Doctors.Domain.Utils
{
    public static class Validations
    {
        public static bool IsValidCpf(this string cpf)
        {
            if (cpf == null || string.IsNullOrEmpty(cpf))
                return false;

            cpf = Regex.Replace(cpf, @"[^0-9]", ""); // Remove non-numeric characters

            if (cpf.Length != 11)
                return false;

            int[] digits = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            // Validate first digit
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += digits[i] * (10 - i);

            int firstDigit = (sum * 10) % 11;
            if (firstDigit == 10) firstDigit = 0;

            if (digits[9] != firstDigit)
                return false;

            // Validate second digit
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += digits[i] * (11 - i);

            int secondDigit = (sum * 10) % 11;
            if (secondDigit == 10) secondDigit = 0;

            return digits[10] == secondDigit;
        }

        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;

            phoneNumber = Regex.Replace(phoneNumber, @"[^0-9+]", ""); // Remove non-numeric and non-plus characters

            // Check if the number starts with a plus sign
            if (!phoneNumber.StartsWith("+"))
                return false;

            // E.164 numbers should have a minimum length of 12 (including the plus sign)
            if (phoneNumber.Length < 12)
                return false;

            // Additional validation logic can be added here based on your requirements

            return true;
        }
    }
}