using System;


namespace TestInsuranceServiceAPI.Classes
{
    public class ObjectMapper<T,TU>
    {
        public static TU MapObject(ref T lhs, ref TU rhs)
        {
            try
            {
                var lhsInfo = lhs.GetType().GetProperties();
                var rhsProp = rhs.GetType().GetProperties();
                foreach (var target in rhsProp)
                {
                    foreach (var source in lhsInfo)
                    {
                        if (source.Name.Equals(target.Name))
                        {
                            target.SetValue(rhs, source.GetValue(lhs));
                        }
                    }
                }
                return rhs;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}