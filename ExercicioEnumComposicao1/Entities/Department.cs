namespace ExercicioEnumComposicao1.Entities
{
    class Department
    {
        public string Name { get; private set; }

        public Department(string name)
        {
            Name = name;
        }
    }
}