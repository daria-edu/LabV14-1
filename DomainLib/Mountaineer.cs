using System;

namespace DomainLib
{
    public class Mountaineer : Person, IDrawable
    {
        public int HighestPeak { get; set; } // Найвища вершина у метрах

        public Mountaineer(string firstName, string lastName, string passport, int highestPeak)
            : base(firstName, lastName, passport)
        {
            HighestPeak = highestPeak;
        }

        public override string GetInfo()
        {
            return $"[Альпініст] {base.GetInfo()}, Найвища вершина: {HighestPeak} м";
        }

        public void Draw()
        {
            Console.WriteLine($"{FirstName} {LastName} (Альпініст) малює карту гірського маршруту.");
        }
    }
}