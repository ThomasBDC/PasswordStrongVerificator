using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrongVerificator
{
    public static class PasswordVerificator
    {
        private static int minLengthPassword = 8;
        private static string alphaMin = "abcdefghijklmnopqrstuvwxyz";
        private static string alphaMaj = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string numerics = "0123456789";
        private static string specialChars = "?:!$@";

        public static Robustesse Evalue(string password)
        {
            int scorePassword = 0;
            
            //longueur
            if (password.Length >= minLengthPassword)
            {
                scorePassword++;
            }

            //Présence du chiffres et de lettres
            bool haveNumerics = password.IsPasswordContainsOneOfThis(numerics);
            bool haveMAJ = password.IsPasswordContainsOneOfThis(alphaMaj);
            bool haveMIN = password.IsPasswordContainsOneOfThis(alphaMin);

            if(haveNumerics && (haveMAJ || haveMIN))
            {
                scorePassword++;

                if(haveMAJ && haveMIN) 
                {
                    scorePassword++;
                }
            }


            //Présence de caractères spéciaux
            bool haveSpecialChars = password.IsPasswordContainsOneOfThis(specialChars);
            if (haveSpecialChars)
            {
                scorePassword++;
            }


            switch (scorePassword)
            {
                case 0:
                case 1:
                case 2:
                    return Robustesse.faible;
                    break;
                case 3:
                    return Robustesse.moyen;
                    break;
                default: 
                    return Robustesse.fort;
            }
        }

        private static bool IsPasswordContainsOneOfThis(this string password, string inputString) 
        {
            return password.Any(ch => inputString.Contains(ch));
        }
    }

    public enum Robustesse
    {
        faible, 
        moyen, 
        fort
    }
}
