using System.Text.RegularExpressions;

namespace regularexp.Validators
{
    public abstract class Validator
    {
        public abstract bool validate(string toValidate);
    }
}