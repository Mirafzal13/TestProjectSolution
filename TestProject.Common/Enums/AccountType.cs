using System.ComponentModel;

namespace TestProject.Common.Enums
{
    public enum AccountType
    {
        [Description("Administrator")] Administrator = 0,
        [Description("StandardUser")] StandardUser = 1
    }

    public static class AccountTypeHelper
    {
        public static int GetId(this AccountType type)
        {
            return (int)type;
        }

        public static string GetDescription(this AccountType addressType)
        {
            var type = typeof(AccessType);
            var field = type.GetField(addressType.ToString());
            var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attr?.Description;
        }

        public static AccountType GetById(int id)
        {
            return (AccountType)id;
        }
    }
}
