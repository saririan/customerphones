using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerContactWebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneNumber
    {
        public string Number { get; set; }
        public bool Active { get; set; }
        public PhoneNumber(string num, bool act)
        {
            Number = num;
            Active = act;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cName"></param>
        /// <param name="cPhoneNum"></param>
        public Customer(string cName, PhoneNumber cPhoneNum)
        {
            Name = cName;
            List<PhoneNumber> PhoneNumbers = new List<PhoneNumber>();
            PhoneNumbers.Add(cPhoneNum);
            CusPhoneNumbers = PhoneNumbers;

        }

        public Customer()
        {
        }
        public Customer(string cName,List<PhoneNumber> cPhoneNumList)
        {
            Name = cName;           
            CusPhoneNumbers = cPhoneNumList;
        }
        public string Name { get; set; }
     
        public List<PhoneNumber> CusPhoneNumbers { get; set; }   

        public void addPhone(PhoneNumber pn)
        {
            CusPhoneNumbers.Add(pn);
        }
    }
}
