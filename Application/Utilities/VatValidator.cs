using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Utilities;

public static class VatValidator
{
    public static bool ValidateVatNumber(string vatNumber)
    {
        if (string.IsNullOrWhiteSpace(vatNumber) || vatNumber.Length != 9 || !vatNumber.All(char.IsDigit))
        {
            return false;
        }

        int sum = 0;

        for (int i = 0; i < 8; i++)
        {
            int digit = int.Parse(vatNumber[i].ToString());
            sum += digit << (8 - i);
        }

        int remainder = sum % 11;
        int checkDigit = remainder == 10 ? 0 : remainder;

        int lastDigit = int.Parse(vatNumber[8].ToString());

        return checkDigit == lastDigit;
    }
}
