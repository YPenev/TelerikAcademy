namespace Methods
{
    using System;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private string otherInfo;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.lastName = value;
                }
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.otherInfo = value;
                }
            }
        }

        public bool IsOlderThan(IStudent other)
        {
            DateTime birthDateOfFirstStudent;
            bool successfulParsedFirstDate = DateTime.TryParse(this.OtherInfo.Substring(this.OtherInfo.Length - 10), out birthDateOfFirstStudent);

            DateTime birthDateOfSecondStudent;
            bool successfulParsedSecondDate = DateTime.TryParse(other.OtherInfo.Substring(other.OtherInfo.Length - 10), out birthDateOfSecondStudent);

            if (!successfulParsedFirstDate || !successfulParsedSecondDate)
            {
                throw new Exception("Can not parse date of birth !");
            }

            var result = birthDateOfFirstStudent > birthDateOfSecondStudent;

            return result;
        }
    }
}
