using System.Data;
using System.Runtime.CompilerServices;

namespace SupportBank
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }
        
        public string Name
        { get; set; }
        
        public double AccountBalance
        { get; set; }
        
        public double TotalMoneyOwed
        { get; set; }

        public double TotalMoneyToPay
        { get; set; }
    }
    
    
    
    
}