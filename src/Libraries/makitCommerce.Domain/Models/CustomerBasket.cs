namespace makit.makitCommerce.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using makit.makitCommerce.Domain.DataTypes;

    public class CustomerBasket : PageModel
    {
        public string SessionId { get; set; }

        public BasketItem[] BasketItemsArray
        {
            get
            {
                return BasketItems.Values.ToArray();
            }

            set
            {
                BasketItems = new Dictionary<String, BasketItem>();

                foreach (BasketItem itemToAddToDict in value)
                {
                    BasketItems.Add(itemToAddToDict.ProductId, itemToAddToDict);
                }
            }
        }

        private Dictionary<String, BasketItem> BasketItems { get; set; }

        public CustomerBasket()
        {
            BasketItems = new Dictionary<String, BasketItem>();
            //TODO: make sure case insensitive keys
        }

        public int GetNumberOfItemsInBasket()
        {
            int numberOfItems = 0;

            if (BasketItems != null)
            {
                numberOfItems = BasketItems.Values.Count;
            }

            return numberOfItems;
        }

        public void AddItem(
            BasketItem itemToAddOrUpdate)
        {
            if (BasketItems == null)
            {
                BasketItems = new Dictionary<String, BasketItem>();
                //TODO: make sure case insensitive keys
            }

            if (BasketItems.ContainsKey(itemToAddOrUpdate.ProductId))
            {
                BasketItem itemAlreadyInBasket = BasketItems[itemToAddOrUpdate.ProductId];
                itemToAddOrUpdate.Quantity += itemAlreadyInBasket.Quantity;
            }

            itemToAddOrUpdate.LineTotalPrice = new Currency(itemToAddOrUpdate.UnitPrice, itemToAddOrUpdate.Quantity);

            BasketItems[itemToAddOrUpdate.ProductId] = itemToAddOrUpdate;
        }

        public void RemoveItem(
            string productId)
        {
            BasketItems.Remove(productId);         
        }

        public void UpdateQuantityOfItem(
            string productId, 
            int quantityToChangeTo)
        {
            if (quantityToChangeTo <= 0)
            {
                RemoveItem(productId);
            }
            else
            {
                BasketItem itemToUpdate = BasketItems[productId];
                itemToUpdate.Quantity = quantityToChangeTo;
                BasketItems[productId] = itemToUpdate;
            }
        }
    }

    public class BasketItem
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public Currency UnitPrice { get; set; }
        //TODO: Net or gross?
        public Currency LineTotalPrice { get; set; }
    }
}
