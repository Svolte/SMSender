using PhoneNumbers;

namespace SMSender
{
    public static class StringExtensions
    {
        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phoneNumber)) return false;
                var util = PhoneNumberUtil.GetInstance();
                var number = util.Parse(phoneNumber, "SE");
                return util.IsValidNumber(number);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}