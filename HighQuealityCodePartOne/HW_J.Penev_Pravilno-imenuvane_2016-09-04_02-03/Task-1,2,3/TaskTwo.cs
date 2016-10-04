class Comunity
{
    enum SexType
    {
        Man,
        Woman
    };

    class Person
    {
        private SexType sex;
        private string name;
        private int age;

        public Person(string name, int age, SexType sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public SexType Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                if (value != null)
                {
                    this.sex = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeExeption();
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != null)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeExeption();
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value != null)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeExeption();
                }
            }
        }
    }

    public void MakeNewPerson(int age)
    {
        var newPersonAge = age;
        var newPersonName = null;
        var newPersonSex = null;

        if (age % 2 == 0)
        {
            newPersonName = "Батката";
            newPersonSex = SexType.Man;
        }
        else
        {
            newPersonName = "Мацето";
            newPersonSex = SexType.Woman;
        }

        Person newPerson = new Person(newPersonName,newPersonAge,newPersonSex);
    }
}
