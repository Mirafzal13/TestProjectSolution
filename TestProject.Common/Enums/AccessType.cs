using System.ComponentModel;

namespace TestProject.Common.Enums
{
    public enum AccessType
    {
        [Description("Added new product")] Create = 1,
        [Description("Updated this product")] Update = 2,
        [Description("Deleted this product")] Delete = 3
    }
    public static class AccessTypeHelper
    {
        public static int GetId(this AccessType type)
        {
            return (int)type;
        }

        public static string GetDescription(this AccessType addressType)
        {
            var type = typeof(AccessType);
            var field = type.GetField(addressType.ToString());
            var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attr?.Description;
        }

        public static AccessType GetById(int id)
        {
            return (AccessType)id;
        }
    }
}
