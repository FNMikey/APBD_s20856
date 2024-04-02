using System;

namespace LegacyApp
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

        public void SetCreditLimit(String lastName)
        {
            switch (lastName)
            {

                case "VeryImportantClient":
                    this.HasCreditLimit = false;
                    break;

                case "ImportantClient":
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(this.LastName, this.DateOfBirth);
                        creditLimit = creditLimit * 2;
                        this.CreditLimit = creditLimit;
                    }
                    break;

                default:
                    this.HasCreditLimit = true;
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(this.LastName, this.DateOfBirth);
                        this.CreditLimit = creditLimit;
                    }
                    break;
            }
        }

    }
}