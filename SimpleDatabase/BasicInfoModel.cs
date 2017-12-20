using System;

namespace SimpleDatabase
{
    public class BasicInfoModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public int Number { get; set; }

        public BasicInfoModel(string name, Guid id, int number)
        {
            Name = name;
            Id = id;
            Number = number;
        }
    }
}
