using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Utilities;

public static class VatValidator
{
    public static bool ValidateVatNumber(string vat)
    {
        if (string.IsNullOrWhiteSpace(vat) || vat.Length != 9 || !vat.All(char.IsDigit))
            return false;
        int sum = 0;
        for (int i = 0; i < 8; i++)
        {
            sum += (int)char.GetNumericValue(vat[i]) << (8 - i);
        }

        int remainder = sum % 11;
        int checkDigit = remainder % 10;

        return checkDigit == (int)char.GetNumericValue(vat[8]);
    }
}
