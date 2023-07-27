using System.Text.RegularExpressions;
using Flunt.Validations;

namespace simple_record.core
{
    public class DomainContract : Contract
    {
        public DomainContract() { }

        public DomainContract IsCnpjValid(string cnpj, string property, string message)
        {
            if (!IsValidCnpj(cnpj))
                AddNotification(property, message);

            return this;
        }

        public DomainContract IsCpfValid(string cpf, string property, string message)
        {
            if (!IsValidCpf(cpf))
                AddNotification(property, message);

            return this;
        }

        public DomainContract IsMobileNumberValid(string mobileNumber, string property, string message)
        {
            if (!IsValidMobileNumber(mobileNumber))
                AddNotification(property, message);

            return this;
        }

        private static bool IsValidMobileNumber(string mobileNumber)
        {
            string regexPattern = @"^\(\d{2}\) 9\d{4}-\d{4}$";
            return Regex.IsMatch(mobileNumber, regexPattern);
        }

        private bool IsCpfDigitsOnly(string cpf)
        {
            foreach (char c in cpf)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private bool IsValidCpf(string cpf)
        {
            // Remove espaços em branco e pontuações do CPF
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !IsCpfDigitsOnly(cpf))
                return false;

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int remainder;

            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;
            digit = remainder.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;
            digit = digit + remainder.ToString();
            return cpf.EndsWith(digit);
        }

        private bool IsValidCnpj(string cnpj)
        {
            int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum;
            int remainder;
            string digit;
            string tempCnpj;

            // Remove non-numeric characters from the CNPJ
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            // Check if the CNPJ has the correct length
            if (cnpj.Length != 14)
                return false;

            // Calculate the first verification digit
            tempCnpj = cnpj.Substring(0, 12);
            sum = 0;
            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
            remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;
            digit = remainder.ToString();
            tempCnpj = tempCnpj + digit;

            // Calculate the second verification digit
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
            remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;
            digit = digit + remainder.ToString();

            // Check if the CNPJ ends with the calculated verification digits
            return cnpj.EndsWith(digit);
        }


    }

}
