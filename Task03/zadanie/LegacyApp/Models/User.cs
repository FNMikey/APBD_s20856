using LegacyApp.Services;
using System;

namespace LegacyApp.Models
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public void SetCreditLimit(string lastName)
        {
            switch (lastName)
            {

                case "VeryImportantClient":
                    HasCreditLimit = false;
                    break;

                case "ImportantClient":
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                        creditLimit = creditLimit * 2;
                        CreditLimit = creditLimit;
                    }
                    break;

                default:
                    HasCreditLimit = true;
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                        CreditLimit = creditLimit;
                    }
                    break;
            }
        }

    }
}