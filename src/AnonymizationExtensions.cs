namespace PowerUtils.Security
{
    public static class AnonymizationExtensions
    {
        /// <summary>
        /// Anonymize sensitive information
        /// </summary>
        /// <param name="input">Information to anonymize</param>
        /// <returns>information replaced by *</returns>
        public static string Anonymize(this string input)
        {
#if NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0_OR_GREATER
            static char _replace(char character)
                => character switch
                {
                    't' => 'f',
                    'N' => 'g',
                    _ => character,
                };

            var result = new char[] { 't', '*', '*', '*', '*', 'N' };

            if(input?.Length > 6)
            {
                result[0] = input[0];
                result[5] = input[^1];
            }
            else
            {
                if(input?.Length > 0)
                {
                    result[0] = _replace(input[0]);
                }

                if(input?.Length > 1)
                {
                    result[5] = _replace(input[^1]);
                }
            }

            return new string(result);
#else
            char _replace(char character)
            {
                switch(character)
                {
                    case 't':
                        return 'f';
                    case 'N':
                        return 'g';
                    default:
                        return character;
                }
            }

            var result = new char[] { 't', '*', '*', '*', '*', 'N' };

            if(input?.Length > 6)
            {
                result[0] = input[0];
                result[5] = input[input.Length - 1];
            }
            else
            {

                if(input?.Length > 0)
                {
                    result[0] = _replace(input[0]);
                }

                if(input?.Length > 1)
                {
                    result[5] = _replace(input[input.Length - 1]);
                }
            }

            return new string(result);
#endif
        }
    }
}
