using System;
using System.Runtime.CompilerServices;

namespace LegacyApp
{
    public class UserService
    {

        private int minimumAge;
        private int creditLimit;
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {

            //Validation
            if (!HasValidFullName(firstName, lastName)) {

                return false;
            };

            if (!HasValidEmail(email)) {

                return false;
            };

            if (!HasMinimumAgeRequired(dateOfBirth))
            {

                return false;
            };


            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }

            if (HasCreditLimitBelow500(user)) {

                return false;
            }

            UserDataAccess.AddUser(user);
            return true;

        }
        public bool HasValidFullName(string firstName, string lastName)
        {

            return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);

        }

        public bool HasValidEmail(string email) {

            return email.Contains("@") || email.Contains(".");

        }

        public bool HasMinimumAgeRequired(DateTime dateOfBirth) {

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
                age--;

            return age > minimumAge;

        }

        public bool HasCreditLimitBelow500(User user) {

            return user.HasCreditLimit && user.CreditLimit < creditLimit;            



        }

    }
}
