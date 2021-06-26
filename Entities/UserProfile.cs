using System;
using ef_core_compare.Enums;

namespace ef_core_compare.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Followers { get; private set; }
        public string Area { get; private set; }
        public string Bio { get; private set; }
        public VisibilityEnum Visibility { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public UserProfile FillData()
        {
            Name = Faker.Name.FullName();
            Followers = Faker.RandomNumber.Next(0, 1000);
            Area = $"{Faker.Address.Country()}, {Faker.Address.City()}";
            Bio = String.Join(" ", Faker.Lorem.Sentences(3));
            Visibility = Faker.Enum.Random<VisibilityEnum>();

            return this;
        }

        public void ChangeUser()
        {
            Name = Faker.Name.FullName();
            Followers = Faker.RandomNumber.Next(0, 1000);
            Area = $"{Faker.Address.Country()}, {Faker.Address.City()}";
            Bio = String.Join(" ", Faker.Lorem.Sentences(3));
            Visibility = Faker.Enum.Random<VisibilityEnum>();
        }
    }
}