using System.ComponentModel.DataAnnotations;

namespace Manifest.Utils
{
    public class MyStringLengthAttribute : StringLengthAttribute
    {
        public MyStringLengthAttribute(int maximumLength)
            : base(maximumLength)
        {
            base.ErrorMessageResourceName = "StringLengthMessage";
            base.ErrorMessageResourceType = typeof(Resource);
        }
    }
}
