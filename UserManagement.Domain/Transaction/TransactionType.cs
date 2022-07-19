using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Transaction
{
    public class TransactionType
    {
        [Key]
        public long TypeId { get;private set; }
        public string Type { get;private set; }

        public List<Transaction> Transactions { get; set; }

        protected TransactionType()
        {
            
        }
        public TransactionType(long typeId,string type)
        {
            TypeId = typeId;
            Type = type;
        }
        public TransactionType(string type)
        {
            Type = type;
        }
    }
}
