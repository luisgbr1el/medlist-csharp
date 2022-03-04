namespace MedTest.Entities {
    class Doctor {
        public string Name { get; set; }
        public string Area { get; set; }
        public string Situation { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Age { get; set; }

        public Doctor(string name, string area, string situation, string city, string state, int age) {
            Name = name;
            Area = area;
            Situation = situation;
            City = city;
            State = state;
            Age = age;
        }
        public override string ToString() {
            return "("
                + Situation
                + ") "
                + Name
                + ", "
                + Area.ToLower()
                + ", living in "
                + City
                + " ("
                + State +
                ") and with "
                + Age
                + " years old.";
        }
    }
}
