using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Linq;
using System;
using System.Text.Json;

namespace PurchaseRecords
{

    public class DataStore
    {
        
        public CustomerRecord[] customerRecords { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public void AddInventoryItem(Item newitem, int quantity)
        {
            for (int i = 0; i < this.Inventory.Count; i++)
            {
                if (this.Inventory[i].StockItem == newitem)
                {
                    this.Inventory[i] = new InventoryItem(this.Inventory[i].StockItem, this.Inventory[i].Quantity + quantity);
                    return;
                    //creates a new item to replace the one you hold a reference to. Otherwise, setting the property directly just sets the copy or the reference, not the 
                    //memory stack value. TIL. Still need someone to explain it better...
                }
            }
            //item does not exist in inventory yet. Create a new one.
            this.Inventory.Add(new InventoryItem(newitem, quantity));
        }
        public void DeleteInventoryItem(Item newitem, int quantity)
        {
            InventoryItem itemtofind = new InventoryItem(newitem, quantity);
            if (this.Inventory.Contains(itemtofind))
            {
                if (this.Inventory.Find(x => x.Equals(itemtofind)).Quantity - quantity <= 0)
                {
                    this.Inventory.Remove(itemtofind); //remove inventory entry if quantity becomes 0
                    return;
                }
                else
                {
                    InventoryItem updateitem = new InventoryItem(newitem, this.Inventory.Find(x => x.Equals(itemtofind)).Quantity - quantity);
                    this.Inventory.Remove(itemtofind);
                    this.Inventory.Add(updateitem);
                    return;
                }
            }
            return;
            //item wasn't found in inventory, so no change needed
        }
        public List<InventoryItem> GetInventory()
        {
            return this.Inventory;
        }
        //public void ChangePrice(InventoryItem invItem, decimal price)
        //public void GetInventoryCount(Item myItem) //returns quantity of Item found in inventory. returns 0 if not found.
        public CustomerRecord GetCustomerRecord(string Name)
        {
            foreach (CustomerRecord record in customerRecords)
            {
                if (record.Name == Name) { return record; }
            }
            return new CustomerRecord(Name);
        }
        public CustomerRecord GetCustomerRecord(CustomerRecord Record)
        {
            foreach (CustomerRecord record in customerRecords)
            {
                if (record.Equals(Record)) { return record; }
            }
            return Record;
        }
        public DataStore()
        {
            customerRecords = new CustomerRecord[0];
            Inventory = new List<InventoryItem>();
        }
        //AddCustomerRecord         yep
        //DeleteCustomerRecord      yep
        //GetCustomerRecord         yep
        //CustomerExists            yep
        //GetCustomerIndex          yep
        //GetAllRecords
        public CustomerRecord[] GetAllRecords()
        {
            return this.customerRecords;
        }
        public bool DeleteCustomerRecord(CustomerRecord record)
        {
            if (record == null || record.Name == "" || record.Name == null || customerRecords.Length == 0) { return false; }
            List<CustomerRecord> temprecords = customerRecords.ToList<CustomerRecord>();
            for (int i = 0; i < temprecords.Count; i++)
            {
                if (temprecords[i].Equals(record)) { temprecords.RemoveAt(i); this.customerRecords = temprecords.ToArray<CustomerRecord>(); return true; }
            }
            return false; //never found a match
        }
        public bool AddCustomerRecord(CustomerRecord record)
        {
            if (record == null || record.Name == "" || record.Name == null) { return false; }
            CustomerRecord[] temprecords = new CustomerRecord[this.customerRecords.Length + 1];
            temprecords[temprecords.Length - 1] = record;
            for (int i = 0; i < this.customerRecords.Length; i++)
            {
                temprecords[i] = this.customerRecords[i];
            }
            this.customerRecords = temprecords;
            return true;
        }
        public bool CustomerExists(string Name)
        {
            for (int i = 0; i < this.customerRecords.Length; i++)
            {
                if (this.customerRecords[i].Name == Name) { return true; }
            }
            return false;
        }
        public bool CustomerExists(CustomerRecord record)
        {
            for (int i = 0; i < this.customerRecords.Length; i++)
            {
                if (this.customerRecords[i].Equals(record)) { return true; }
            }
            return false;
        }
        public int GetCustomerIndex(string Name)
        {
            for (int i = 0; i < this.customerRecords.Length; i++)
            {
                if (customerRecords[i].Name == Name) { return i; }
            }
            return -1; //not found
        }
        public int GetCustomerIndex(CustomerRecord record)
        {
            for (int i = 0; i < this.customerRecords.Length; i++)
            {
                if (customerRecords[i].Equals(record)) { return i; }
            }
            return -1; //not found
        }
    }

    public class CustomerRecord : IEquatable<object>
    {
        
        public Purchase[] purchases { get; set; }
        public CreditCard[] creditCards { get; set; }
        public string Name { get; set; }
        public CustomerRecord(string Name)
        {
            this.Name = Name;
            this.purchases = Array.Empty<Purchase>();
            this.creditCards = Array.Empty<CreditCard>();
        }
        public override bool Equals(object? other)
        {
            if (this == null || other == null) return false;
            if (other.GetType() != typeof(CustomerRecord)) { return false; }
            CustomerRecord otherrec = (CustomerRecord)other;
            if (this.Name != otherrec.Name || this.purchases.Length != otherrec.purchases.Length || this.creditCards.Length != otherrec.creditCards.Length || this.purchases != otherrec.purchases || this.creditCards != otherrec.creditCards) { return false; }
            for (int i = 0; i < this.purchases.Length; i++)
            {
                if (!this.purchases[i].Equals(otherrec.purchases[i])) { return false; }
            }
            for (int j = 0; j < this.creditCards.Length; j++)
            {
                if (!this.creditCards[j].Equals(otherrec.creditCards[j])) { return false; }
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.Name.Length; i++)
            {
                if (i == 0) { hash = (int)this.Name[i]; }
                else { hash ^= (int)this.Name[i]; }
            }
            foreach (Purchase purchase in this.purchases)
            {
                hash ^= purchase.GetHashCode();
            }
            foreach (CreditCard card in this.creditCards)
            {
                hash ^= card.GetHashCode();
            }
            return hash;
        }

        //AddPurchase                   yep
        //DeletePurchase
        //DeleteAllPurchases
        //AddCreditCard                 yep
        //DeleteCreditCard
        //DeleteAllCreditCards
        //GetPurchases                  yep
        //GetPurchasesByItem
        //GetPurchasesByQuantity
        //GetPurchasesByDateOnly
        //GetPurchasesByDateTime
        //GetPurchasesByDateTimeRange

        public bool AddPurchase(Purchase purchase)
        {
            Purchase[] temparr = new Purchase[this.purchases.Length + 1];
            temparr[temparr.Length - 1] = purchase;
            for (int i = 0; i < this.purchases.Length; i++)
            {
                temparr[i] = this.purchases[i];
            }
            this.purchases = temparr;
            return true;
        }
        public Purchase[] GetPurchases()
        {
            return this.purchases;
        }
        public bool AddCreditCard(CreditCard newCard)
        {
            CreditCard[] tempcards = new CreditCard[this.creditCards.Length + 1];
            tempcards[tempcards.Length - 1] = newCard;
            for (int i = 0; i < this.creditCards.Length; i++)
            {
                tempcards[i] = this.creditCards[i];
            }
            this.creditCards = tempcards;
            return true;
        }
    }

    public struct Purchase : IEquatable<object>
    {
        public Item PurchaseItem { get; set; }
        public int PurchaseQuantity { get; set; }
        public DateTime PurchaseTime { get; set; }
        public Purchase(Item PurchaseItem)
        {
            this.PurchaseItem = PurchaseItem;
            this.PurchaseQuantity = 1;
            this.PurchaseTime = DateTime.Now;
        }
        public Purchase(Item PurchaseItem, int PurchaseQuantity)
        {
            this.PurchaseItem = PurchaseItem;
            this.PurchaseQuantity = PurchaseQuantity;
            this.PurchaseTime = DateTime.Now;
        }
        public Purchase(Item PurchaseItem, int PurchaseQuantity, DateTime PurchaseTime)
        {
            this.PurchaseItem = PurchaseItem;
            this.PurchaseQuantity = PurchaseQuantity;
            this.PurchaseTime = PurchaseTime;
        }
        public override bool Equals(object? other)
        {
            if (other == null) { return false; }
            if (other.GetType() != typeof(Purchase)) { return false; }
            Purchase otherp = (Purchase)other;
            if (this.PurchaseItem != otherp.PurchaseItem) { return false; }
            if (this.PurchaseQuantity != otherp.PurchaseQuantity) { return false; }
            if (this.PurchaseTime != otherp.PurchaseTime) { return false; }
            return true;

        }
        public override int GetHashCode()
        {
            int hash = 0;
            hash = this.PurchaseItem.GetHashCode();
            hash ^= this.PurchaseQuantity;
            hash ^= this.PurchaseTime.GetHashCode();
            return hash;
        }
    }

    public struct CreditCard : IEquatable<object>
    {
        public string CardholderName { get; set; }
        public long CardNumber { get; set; }
        public int SecurityCode { get; set; }
        public int ZipCode { get; set; }
        public DateOnly Expiration { get; set; }
        public CreditCard(string CardholderName, long CardNumber, int SecurityCode, int ZipCode, DateOnly Expiration)
        { //Add verification logic for each field
            this.CardNumber = CardNumber;
            this.SecurityCode = SecurityCode;
            this.ZipCode = ZipCode;
            this.Expiration = Expiration;
            this.CardholderName = CardholderName;
        }
        public override bool Equals(object? other)
        {
            if (this == null || other == null) { return false; }
            if (other.GetType() != this.GetType()) { return false; }
            
            CreditCard othercard = (CreditCard)other;
            if (this.CardholderName != othercard.CardholderName || this.CardNumber != othercard.CardNumber || this.SecurityCode != othercard.SecurityCode || this.ZipCode != othercard.ZipCode || this.Expiration != othercard.Expiration) { return false; }
            return true;
        }
        static public bool operator == (CreditCard? leftcard, CreditCard? rightcard)
        {
            if (leftcard == null || rightcard == null) { return false; }
            if (leftcard.GetType() != typeof(CreditCard) || rightcard.GetType() != typeof(CreditCard)) { return false; }
            CreditCard lside = (CreditCard)leftcard;
            CreditCard rside = (CreditCard)rightcard;
            if (lside.Equals(rside)) { return true; }
            else { return false; }
        }
        static public bool operator != (CreditCard? leftcard, CreditCard? rightcard)
        {
            return !(leftcard == rightcard);
        }
        public override int GetHashCode()
        {
            int hashcode = 0;
            for (int i = 0; i < this.CardholderName.Length; i++)
            {
                if (hashcode == 0) { hashcode = (int)this.CardholderName[i]; }
                else { hashcode ^= (int)this.CardholderName[i]; }
            }
            hashcode ^= (int)this.CardNumber;
            hashcode ^= (int)this.SecurityCode;
            hashcode ^= (int)this.ZipCode;
            hashcode ^= (int)this.Expiration.GetHashCode();
            return hashcode;
        }
    }

    public struct Item : IEquatable<object>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Item(string Name, decimal Price = 0.00m)
        {
            this.Name = Name;
            this.Price = Price;
        }
        public override bool Equals(object? other)
        {
            if (other == null) { return false; }
            if (this.GetType() != other.GetType()) { return false; }
            Item othera = (Item)other;
            if (this.Name == null || othera.Name == null || this.Name != othera.Name || this.Price != othera.Price) { return false; }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.Name.Length; i++)
            {
                if (i == 0) { hash = this.Name[i]; }
                else
                {
                    hash ^= this.Name[i];
                }
            }
            hash ^= (int)this.Price;
            return hash;
        }
        public static bool operator == (Item? left, Item? right)
        {
            return left.Equals(right);
        }
        public static bool operator != (Item? left, Item? right)
        {
            return !(left == right);
        }
        public decimal GetPrice()
        {
            return this.Price;
        }
        public void SetPrice(decimal Price)
        {
            this.Price = Price;
            return;
        }
    }

    public struct InventoryItem : IEquatable<object>
    {
        public Item StockItem { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string StockItemName
        {
            get { return this.StockItem.Name; }
        }
        public override bool Equals(object? other)
        {
            if (other == null) { return false; }
            if (this.GetType() != other.GetType()) { return false; }
            if (this.StockItem.GetHashCode() != other.GetHashCode()) { return false; }
            if (this.StockItem != ((InventoryItem)other).StockItem || this.Price != ((InventoryItem)other).Price) { return false; } //this.Equals(o) will not check quantity equality. That would defeat the purpose of the struct.
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            hash = this.StockItem.GetHashCode();
            hash ^= this.Price.GetHashCode();
            return hash;
        }
        public InventoryItem(Item item, int quantity = 1)
        {
            this.StockItem = item;
            this.Price = StockItem.Price;
            this.Quantity = quantity;
        }
    }
}