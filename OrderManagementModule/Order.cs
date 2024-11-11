using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // выставление свойств по умолчанию в доменной сущности?
    public class Order
    {
        private bool paymentConfirmation;
        private bool cancellation;
        private bool issuedToClient;

        public Guid Id { get; set; }


        public bool IssuedToClient { get => issuedToClient; set => issuedToClient = false; } // выдан ли заказ

        /// <summary>
        /// если заказ есть, но данный параметр false, то бронь. если удаление заказа при false, то
        /// --count товаров НЕ делаем.
        /// если происходит PaymentConfirmation, то --count делаем
        /// </summary>
        public bool PaymentConfirmation { get => paymentConfirmation; set => paymentConfirmation = false; }
        public bool Cancellation { get => cancellation; set => cancellation = false; } // SoftDeleted
        public int TotalSum { get; set; }
        public int Discount { get; set; }

        public ICollection<Guid>? AutomobilesId { get; set; }
        public Guid? CustomerID { get; set; }
    }
}
