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
        public decimal TotalSum { get; set; }
        public int Discount { get; set; }

        public IList<Guid>? AutomobilesId { get; set; } = new List<Guid>();// AutomobileIDs
        // ранее было написано ICollection без new List<Guid> и оно работало
        // возможно, когда указан ICollection, не надо ссылки -- вопрос решается под капотом
        // но при явном указании надо решать вопрос явно в коде -- инициализировать, прописывать new List<T>();
    }
}
