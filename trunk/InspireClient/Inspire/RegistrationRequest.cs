using System;

namespace Inspire
{
    public class RegistrationRequest
    {
        /// <summary>
        /// Date Requested
        /// </summary>
        public DateTime DateTimeRequested { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Address Line 1
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Address Line 2
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Zip Code
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Registration Guid
        /// </summary>
        public string RegistrationGuid { get; set; }
    }

    public class RegistrationResponse
    {
        /// <summary>
        /// Registration Good Until Date
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Registration Guid
        /// </summary>
        public string RegistrationGuid { get; set; }
    }
}
