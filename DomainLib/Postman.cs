namespace DomainLib
{
    public class Postman : Person
    {
        public string DeliveryZone { get; set; }

        public Postman(string firstName, string lastName, string passport, string deliveryZone)
            : base(firstName, lastName, passport)
        {
            DeliveryZone = deliveryZone;
        }

        public override string GetInfo()
        {
            return $"[Поштар] {base.GetInfo()}, Зона доставки: {DeliveryZone}";
        }
    }
}